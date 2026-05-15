using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
    public partial class GestionPreguntas : Form
    {
        private int idModulo; 
        private string nombreModulo; 
        private string cadenaConexion = "Server=localhost;Database=peducativa;Uid=root;Pwd=;";

        public GestionPreguntas(int idRecibido, string nombreRecibido)
        {
            InitializeComponent();
            this.idModulo = idRecibido;
            this.nombreModulo = nombreRecibido;
            CargarPreguntas();
        }

        private void CargarPreguntas()
        {
            try 
            {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) 
                {
                    string consulta = "SELECT id, pregunta_es, pregunta_en FROM pregunta WHERE id_modulo = @id";
                    
                    using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
                    {
                        // Añadimos el parámetro al comando
                        cmd.Parameters.AddWithValue("@id", this.idModulo);
                        
                        // El Adaptador usa el comando 'cmd' que ya tiene la consulta y el parámetro
                        MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        dgvPreguntas.DataSource = dt; 
                    }
                }
            } 
            catch (Exception ex) 
            {
                MessageBox.Show("Error al cargar preguntas: " + ex.Message);
            }
        }
    }
}   
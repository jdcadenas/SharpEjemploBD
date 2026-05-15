using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
    public partial class GestionPreguntas : Form
    {	private string cadenaConexion =  "Server=localhost;Database=peducativa;Uid=root;Pwd=;";
        private int _idModulo;

        public GestionPreguntas(int idModulo, string nombreModulo)
        {
            InitializeComponent();
            _idModulo = idModulo;
            this.Text = "Gestión de Preguntas - " + nombreModulo;
            CargarPreguntas();
        }

        private void CargarPreguntas()
        {
            try {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) {
                    string sql = "SELECT * FROM pregunta WHERE id_modulo = @idModulo";
                    
                    conexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand(sql, conexion)) {
                        cmd.Parameters.AddWithValue("@idModulo", _idModulo);
                        MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adp.Fill(dt);
                        dgvPreguntas.DataSource = dt;
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
} 

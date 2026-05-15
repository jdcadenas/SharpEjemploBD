using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;


namespace ejemploBd
{
    public partial class GestionPreguntas : Form
    {
        private int idModulo; // Variable global para almacenar el ID recibido
       private string cadenaConexion =  "Server=localhost;Database=peducativa;Uid=root;Pwd=;";

        // Constructor que recibe el parámetro
        public GestionPreguntas(int idRecibido)
        {
            InitializeComponent();
            this.idModulo = idRecibido; // Guardamos el ID para usarlo luego
        }

        private void GestionPreguntas_Load(object sender, EventArgs e)
        {
            CargarPreguntasFiltradas();
        }

        private void CargarPreguntasFiltradas()
        {
             using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
            {
                try
                {
                 
                    string sql = "SELECT id, pregunta_es, pregunta_en FROM pregunta WHERE id_modulo = @id";
                       
                    
                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", this.idModulo); // Pasamos la variable al comando SQL

                    MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    
                    dgvPreguntas.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar las preguntas: " + ex.Message);
                }
            }
        }
    }
}


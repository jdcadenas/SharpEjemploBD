using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
	public partial class GestionPreguntas : Form
	{
		
		private string cadenaConexion = "Server=localhost;Database=peducativa;Uid=root;Pwd=;"; 
		private int idModuloInterno;
		 

		public GestionPreguntas(int _idModulo,string nombreMod)
		{
			InitializeComponent();
		
		}

		private void CargarPreguntas()
		{
			try {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) {
                    
                   
                    string sql = "SELECT * FROM pregunta WHERE id_modulo = @id";
                    
                    conexion.Open();
                    
                    
                    MySqlCommand comando = new MySqlCommand(sql, conexion);
                    comando.Parameters.AddWithValue("@id", this.idModuloInterno);
                    
                   
                    MySqlDataAdapter adp = new MySqlDataAdapter(comando);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    
                    
                    dgvPreguntas.DataSource = dt;
                }
            } catch (Exception ex) {
                MessageBox.Show("Error al cargar las preguntas: " + ex.Message);
            }
		}
		
	}
}

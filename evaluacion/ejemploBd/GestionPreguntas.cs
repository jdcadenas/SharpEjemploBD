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
		private int _idModulo;

		// EXAMEN PASO 5: El constructor debe recibir los datos del formulario padre
		public GestionPreguntas(int id, string nombre)
		{
			InitializeComponent();
			this._idModulo = id;
			this.Text = "Preguntas de: " + nombre;
			CargarPreguntas();
		}

		private void CargarPreguntas()
		{
			try {
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) {
					// EXAMEN PASO 6: Filtrar las preguntas por el ID del módulo recibido
					string sql = "SELECT * FROM pregunta WHERE id_modulo = " + ________;
					
					conexion.Open();
					MySqlDataAdapter adp = new MySqlDataAdapter(sql, conexion);
					DataTable dt = new DataTable();
					adp.Fill(dt);
					dgvPreguntas.DataSource = dt;
				}
			} catch (Exception ex) {
				MessageBox.Show("Error: " + ex.Message);
			}
		}
	}
}

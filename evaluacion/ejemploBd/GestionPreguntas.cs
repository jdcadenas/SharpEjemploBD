using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
	public partial class GestionPreguntas : Form
	{
		// EXAMEN PASO 5.1: Esta cadena debe estar vacía. Cópiala de MainForm.cs
		private string cadenaConexion = "Server=localhost;Database=peducativa;Uid=root;Pwd=;"; 
		private int _idModulo;

		// EXAMEN PASO 5.2: El constructor debe recibir el ID y el Nombre del módulo
		public GestionPreguntas(int _idModulo, string cadenaConexion)
		{
			InitializeComponent();
			// El estudiante debe añadir los parámetros y asignar los valores aquí
			
			//
			//lamar a funcion 
		}

		private void CargarPreguntas()
		{
			try {
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) {
					// EXAMEN PASO 6: Filtrar las preguntas por el ID del módulo recibido (_idModulo)
					string sql = "SELECT * FROM pregunta WHERE id_modulo = " + _idModulo;
					
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
		
		void DgvPreguntasCellContentClick(object sender, DataGridViewCellEventArgs e)
		{
			
		}
	}
}

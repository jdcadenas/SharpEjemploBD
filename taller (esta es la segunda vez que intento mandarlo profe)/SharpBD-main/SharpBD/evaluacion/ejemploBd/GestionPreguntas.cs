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
		private string cadenaConexion =  "Server=localhost;Database=taller-luben-angel;Uid=root;Pwd=;";
		private int _IDModulo;

		// EXAMEN PASO 5.2: El constructor debe recibir el ID y el Nombre del módulo
		public GestionPreguntas(int ID, string Name,string Nombre)
		{
			InitializeComponent();
			// El estudiante debe añadir los parámetros y asignar los valores aquí
			this._IDModulo = ID;
			//
			//lamar a funcion 
			CargarPreguntas();
		}

		public void CargarPreguntas()
		{
			try {
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) {
					// EXAMEN PASO 6: Filtrar las preguntas por el ID del módulo recibido (_idModulo)
					string sql = "SELECT * FROM Question WHERE ID_Modulo = " + _IDModulo;
					
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

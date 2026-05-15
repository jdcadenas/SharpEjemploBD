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
		private string _nombreModulo;

		// EXAMEN PASO 5.2: El constructor debe recibir el ID y el Nombre del módulo
		public GestionPreguntas(int id,string nombreModulo)
		{
			InitializeComponent();
			// El estudiante debe añadir los parámetros y asignar los valores aquí
			this._idModulo = id;
			this._nombreModulo = nombreModulo;
			CargarPreguntas();
			//
			//lamar a funcion 
		}

		private void CargarPreguntas()
		{
		    try 
		    {
		        using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) 
		        {

		            string sql = "SELECT * FROM pregunta WHERE id_modulo = @id";
		            
		            MySqlCommand cmd = new MySqlCommand(sql, conexion);
		            cmd.Parameters.AddWithValue("@id", _idModulo);
		
		            conexion.Open();
		
		            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
		            DataTable dt = new DataTable();
		            adp.Fill(dt);
		
		            dgvPreguntas.DataSource = dt;
		        }
		    } 
		    catch (Exception ex) 
		    {
		        MessageBox.Show("Error al cargar datos: " + ex.Message);
		    }
		}
	}
}

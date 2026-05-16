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
		private string _NombreModulo;

		// EXAMEN PASO 5.2: El constructor debe recibir el ID y el Nombre del módulo
		public GestionPreguntas(int idModulo, string modulonombre)
		{
			InitializeComponent();
			this._idModulo = idModulo;
			this._NombreModulo = modulonombre;
			// El estudiante debe añadir los parámetros y asignar los valores aqu
			
			
			CargarPreguntas();
		}

		private void CargarPreguntas()
{
    try {
        using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) {
  
            string sql = "SELECT * FROM pregunta WHERE id_modulo = @idModulo";
            
            conexion.Open();
            
            MySqlCommand cmd = new MySqlCommand(sql, conexion);
            cmd.Parameters.AddWithValue("@idModulo", this._idModulo);
            
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
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

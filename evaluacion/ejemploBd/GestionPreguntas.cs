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
        private int _idModulo = -1;

     // EXAMEN PASO 5.2: El constructor debe recibir el ID y el Nombre del módulo
		public GestionPreguntas(int idModulo, string nombreModulo)
		{
			InitializeComponent();
			this._idModulo = idModulo;
			this.Text = "Preguntas de: " + nombreModulo;
			CargarPreguntas();
		}

		// EXAMEN PASO 6: Crear el método para cargar las preguntas filtradas por el ID del módulo
		private void CargarPreguntas()
		{
			try {
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) {
					// Filtramos usando la variable _idModulo que recibimos en el paso 5.2
					string sql = "SELECT * FROM pregunta WHERE id_modulo = " + _idModulo;
					
					conexion.Open();
					MySqlDataAdapter adp = new MySqlDataAdapter(sql, conexion);
					DataTable dt = new DataTable();
					adp.Fill(dt);
					
					// IMPORTANTE: Verifica que en el diseño tu tabla se llame dgvPreguntas
					dgvPreguntas.DataSource = dt;
				}
			} catch (Exception ex) {
				MessageBox.Show("Error: " + ex.Message);
			}
		}

		void BtnVolverClick(object sender, EventArgs e)
		{
			this.Close();
		}
    }
}
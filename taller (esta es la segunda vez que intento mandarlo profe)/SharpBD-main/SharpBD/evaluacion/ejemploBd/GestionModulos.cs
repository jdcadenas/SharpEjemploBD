using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
	public partial class GestionModulos : Form
	{
		// EXAMEN PASO 1: Esta cadena está vacía. Cópiala de MainForm.cs
		private string cadenaConexion = "Server=localhost;Database=taller-luben-angel;Uid=root;Pwd=;";
		private bool _esEdicion = false;
		private int _ID = -1;

		public GestionModulos()
		{
			InitializeComponent();
			CargarModulos();
		}

		private void CargarModulos()
		{
			try {
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
				{
					string consulta = "SELECT ID, Name, Nombre from Modulo";
					conexion.Open();
					MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
					DataTable tabla = new DataTable();
					adaptador.Fill(tabla);
					dgvModulos.DataSource = tabla;
					
				}
			} catch (Exception ex) {
				MessageBox.Show(string.Format("Error de conexión: {0}", ex.Message));
			}
		}
		void BtnVerPreguntasClick(object sender, EventArgs e)
		{
			if (dgvModulos.SelectedRows.Count == 0) return;

			// EXAMEN PASO 4: Obtener el ID y Nombre del módulo seleccionado para enviarlo al hijo
			int idModulo = Convert.ToInt32(dgvModulos.SelectedRows[0].Cells["ID"].Value);
			string NameMod= dgvModulos.SelectedRows[0].Cells["Name"].Value.ToString();
			string nombreMod = dgvModulos.SelectedRows[0].Cells["Nombre"].Value.ToString();
			
			// Abrir el formulario de preguntas pasando los parámetros
			GestionPreguntas frm = new GestionPreguntas(idModulo, NameMod,nombreMod);
			frm.ShowDialog();

		}
		
		void BtnGuardarClick(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtNombreEn.Text) || string.IsNullOrWhiteSpace(txtNombreEs.Text))
			{
				MessageBox.Show("Complete todos los campos.");
				return;
			}
			
			string consulta = _esEdicion ? 
				"UPDATE Modulo  SET Name=@Name, Nombre=@Nombre" : 
				"INSERT INTO Modulo ( Name, Nombre) VALUES (@Name, @Nombre)";		
			
			try
			{
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
					using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
				{
					cmd.Parameters.AddWithValue("@Name", txtNombreEn.Text.Trim());
					cmd.Parameters.AddWithValue("@Nombre", txtNombreEs.Text);
					
					if (_esEdicion) cmd.Parameters.AddWithValue("@Id", _ID);
					
					conexion.Open();
					cmd.ExecuteNonQuery(); // ESTA LÍNEA ES CLAVE: Ejecuta la acción en la BD
				}
				this.DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error: " + ex.Message);
			}
		
		}
		
		void GestionModulosLoad(object sender, EventArgs e)
		{
			
		}
	}
}

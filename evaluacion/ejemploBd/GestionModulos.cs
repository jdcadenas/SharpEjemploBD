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
		private string cadenaConexion = "Server=localhost;Database=peducativa;Uid=root;Pwd=;"; 

		public GestionModulos()
		{
			InitializeComponent();
			CargarModulos();
		}

		private void CargarModulos()
		{
			try {
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) {
					// EXAMEN PASO 2: Consulta bilingüe incompleta (Seleccione id, nombre_es y nombre_en)
					string consulta = "SELECT id, nombre_es, nombre_en FROM modulo";
					
					conexion.Open();
					MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
					DataTable tabla = new DataTable();
					
					// EXAMEN PASO 3: Falta la instrucción para llenar la tabla (Fill)
					adaptador.Fill(tabla);
					
					dgvModulos.DataSource = tabla;
				}
			} catch (Exception ex) {
				MessageBox.Show("Error al cargar: " + ex.Message);
			}
		}

		void BtnVerPreguntasClick(object sender, EventArgs e)
		{
			if (dgvModulos.SelectedRows.Count == 0) return;

			// EXAMEN PASO 4: Obtener el ID y Nombre del módulo seleccionado para enviarlo al hijo
			int idModulo = Convert.ToInt32(dgvModulos.SelectedRows[0].Cells["id"].Value);
			string nombreMod = dgvModulos.SelectedRows[0].Cells["nombre_es"].Value.ToString();

			// Abrir el formulario de preguntas pasando los parámetros
			GestionPreguntas frm = new GestionPreguntas(idModulo, nombreMod);
			frm.ShowDialog();
		}
		
		void BtnGuardarClick(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtNombreEs.Text) || string.IsNullOrWhiteSpace(txtNombreEn.Text))
			{
				MessageBox.Show("Complete todos los campos.");
				return;
			}
			
			string Guardar = "INSERT INTO modulo (nombre_es,nombre_en) VALUES (@nombre_es, @nombre_en)";		
			
			try
			{
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
					using (MySqlCommand cmd = new MySqlCommand(Guardar, conexion))
				{
					cmd.Parameters.AddWithValue("@nombre_es",txtNombreEs.Text);
					cmd.Parameters.AddWithValue("@nombre_en",txtNombreEn.Text);
					
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
		
		void BtnVpreguntasClick(object sender, EventArgs e)
		{
			if (dgvModulos.CurrentRow == null) 
		    {
		        MessageBox.Show("Por favor, selecciona una fila primero.");
		        return;
		    }
		
		    try 
		    {
		        var fila = dgvModulos.CurrentRow;
		        int id = Convert.ToInt32(fila.Cells["id"].Value);
		        string nombreModulo = fila.Cells["nombre_es"].Value.ToString();
		
		        GestionPreguntas preguntas = new GestionPreguntas(id, nombreModulo);
		        preguntas.ShowDialog();
		    }
		    catch (Exception ex)
		    {
		        MessageBox.Show("Error: " + ex.Message);
		    }
		}
	}
}

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
					string consulta = "SELECT id,nombre_es,nombre_en FROM modulo";
					
					conexion.Open();
					MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
					DataTable tabla = new DataTable();
					
					// EXAMEN PASO 3: Falta la instrucción para llenar la tabla (Fill)
					// ___________________________; 
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
			string nombreMod = dgvModulos.SelectedRows[0].Cells["nombre"].Value.ToString();

			// Abrir el formulario de preguntas pasando los parámetros
			GestionPreguntas frm = new GestionPreguntas(idModulo, nombreMod);
			frm.ShowDialog();
		}
		
		void BtnGuardarClick(object sender, EventArgs e)
		{
			
			
			// Validaciones de campos vacíos
			if (string.IsNullOrWhiteSpace(txtNombre.Text))
			{
				MessageBox.Show("Escriba nombre para el usuario.");
				return;
			}
			if (string.IsNullOrWhiteSpace(txtClave.Text))
			{
				MessageBox.Show("Escriba clave para el usuario.");
				return;
			}
			// Validar que haya un rol seleccionado
			if (cmbRol.SelectedIndex == -1)
			{
				MessageBox.Show("Seleccione un rol.");
				return;
			}
			
			// Paso 1: Obtener el ID del rol usando SelectedValue (entero)
			int idrol = (int)cmbRol.SelectedIndex;
			
			// Definir la consulta según sea edición o nuevo
			string consulta;
			
			// Paso 2: Consulta SQL con parámetros
			if (_esEdicion){
				consulta = "UPDATE usuario SET nombre=@nombre, clave=@clave, rol=@rol WHERE id=@id";
				btnGuardar.Text = "actualizar";
			}
			else
				consulta = "INSERT INTO usuario (nombre, clave, rol) VALUES (@nombre, @clave, @rol)";		
			
			try
			{
				// Paso 3: Crear conexión y comando
				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
					using (MySqlCommand cmd = new MySqlCommand(consulta, conexion))
				{
					// Paso 4: Asignar parámetros
					cmd.Parameters.AddWithValue("@nombre", txtNombre.Text.Trim());
					cmd.Parameters.AddWithValue("@clave", txtClave.Text);
					cmd.Parameters.AddWithValue("@rol", idrol);
					
					if (_esEdicion)
                    	cmd.Parameters.AddWithValue("@id", _id);
					// Paso 5: Abrir y ejecutar
					conexion.Open();
					cmd.ExecuteNonQuery();
				}
				MessageBox.Show(_esEdicion ? "Usuario actualizado correctamente." : "Usuario agregado correctamente.");
				
				this.DialogResult = DialogResult.OK;   // Para que el padre sepa que se agregó
				this.Close();
				
			}
			catch (Exception ex)
			{
				MessageBox.Show(string.Format("Error al agregar: {0}", ex.Message));
			}
		}	
				
				
				
			}
			
		}
	


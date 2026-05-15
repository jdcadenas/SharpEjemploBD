using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
	public partial class GestionModulos : Form
	{
		
		//esta parte fue realizada por jose torrealba
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
			if (dgvModulos.SelectedRows.Count == 0) {
				MessageBox.Show("Seleccione un módulo primero.");
				return;
			}

			// EXAMEN PASO 4: Obtener el ID y el nombre del módulo de la fila seleccionada
			int idModulo = Convert.ToInt32(dgvModulos.SelectedRows[0].Cells["id"].Value);
			string nombreModulo = dgvModulos.SelectedRows[0].Cells["nombre_es"].Value.ToString();

			// Abrir el formulario de preguntas pasando los datos al constructor
			GestionPreguntas frm = new GestionPreguntas(idModulo, nombreModulo);
			frm.ShowDialog();
		}
        
        void BtnGuardarClick(object sender, EventArgs e)
        {
            // Lógica para guardar o actualizar módulos (opcional según el examen)
            if (string.IsNullOrEmpty(txtNombreEs.Text) || string.IsNullOrEmpty(txtNombreEn.Text)) return;
            
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) {
                string sql = "INSERT INTO modulo (nombre_es, nombre_en) VALUES (@es, @en)";
                MySqlCommand cmd = new MySqlCommand(sql, conexion);
                cmd.Parameters.AddWithValue("@es", txtNombreEs.Text);
                cmd.Parameters.AddWithValue("@en", txtNombreEn.Text);
                conexion.Open();
                cmd.ExecuteNonQuery();
            }
            CargarModulos();
        }
	}
}
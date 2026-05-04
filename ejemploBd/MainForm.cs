/*
 * Created by SharpDevelop.
 * User: jdcad
 * Date: 3/5/2026
 * Time: 2:53 p. m.
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
		
	{
		// Paso 1 --> crea una cadena de conexión
		private string cadenaConexion =  "Server=localhost;Database=peducativa;Uid=root;Pwd=;";
		
			
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			CargarUsuarios();
			
		}
		
		public void CargarUsuarios(){
		
			try {
				// paso 2 -  > establece la conexión

				using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) {
					//paso 3 crea la consulta
					string consulta = "SELECT  id, nombre, clave, rol from usuario";
					//paso 4 Abre la conexión
					conexion.Open();
					//paso 5 utiliza adaptador para ejecutar la consulta
					MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
					//paso 5 define objeto tabla y con el uso de adaptador la llenas
					DataTable tabla = new DataTable();
					adaptador.Fill(tabla);
					//paso 6 establece la fuente de datos del dgvUsuarios
					dgvUsuarios.DataSource = tabla;
					lblEstado.Text = string.Format("Cargados {0} usuarios.", tabla.Rows.Count);
					
				}
			} catch (Exception ex) {
				
				MessageBox.Show(string.Format("No se pudo realizar conexion por : {0}",ex.Message));
			}
		}
		
		void BtnAgregarUsuarioClick(object sender, EventArgs e)
		{
			UsuarioNuevo frmnuevo  = new UsuarioNuevo();
		
			if (frmnuevo.ShowDialog() == DialogResult.OK) // para mantener estructura
            {
				CargarUsuarios();
				
            }
		}
	}
}

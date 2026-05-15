using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
    public partial class GestionModulos : Form
    {
       
       private string cadenaConexion =  "Server=localhost;Database=peducativa;Uid=root;Pwd=;";

        public GestionModulos()
        {
            InitializeComponent();
        }

        private void GestionModulos_Load(object sender, EventArgs e)
        {
            CargarModulos();
        }
        
        
		private void CargarModulos()
	{
    using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
	    {
	        // Consulta SQL 
	        string sql = "SELECT id, nombre_es, nombre_en FROM modulo";
	        MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
	        DataTable dt = new DataTable();
	        adapter.Fill(dt);
	        dgvModulos.DataSource = dt;
	    }
	}
		
				
		void BtnPreguntasClick(object sender, EventArgs e)
		{
			            // Verificamos que haya una fila seleccionada en el DataGridView
            if (dgvModulos.SelectedRows.Count > 0)
            {
                // Extraemos el ID del módulo seleccionado
                int idSeleccionado = Convert.ToInt32(dgvModulos.SelectedRows[0].Cells["id"].Value);
                
               
                GestionPreguntas gestionP = new GestionPreguntas(idSeleccionado);
                gestionP.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un módulo de la lista completa.");
            }
		}
    }
}
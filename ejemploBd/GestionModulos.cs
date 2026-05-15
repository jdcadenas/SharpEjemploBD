using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data;

namespace ejemploBd
{
    public partial class GestionModulos : Form
    {
        // EXAMEN PASO 1: Cadena de conexión configurada correctamente
        private string cadenaConexion = "Server=localhost;Database=peducativa;Uid=root;Pwd=;";
        
        // Esta variable se usará para rastrear si es un registro nuevo (-1) o uno existente
        private int id = -1;

        public GestionModulos()
        {
            InitializeComponent();
            CargarModulos();
        }

        private void CargarModulos()
        {
            try {
                using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) {
                    // EXAMEN PASO 2: Consulta bilingüe completa (Selecciona id, nombre_es y nombre_en)
                    string consulta = "SELECT id, nombre_es, nombre_en FROM modulo";
                    
                    conexion.Open();
                    MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
                    DataTable tabla = new DataTable();
                    adaptador.Fill(tabla);
                    dgvModulos.DataSource = tabla;
                }
            } catch (Exception ex) {
                MessageBox.Show("Error al cargar: " + ex.Message);
            }
        }
		
		void BtnVerPreguntaClick(object sender, EventArgs e)
		{
			if (dgvModulos.SelectedRows.Count == 0) return;

		    int idModulo = Convert.ToInt32(dgvModulos.SelectedRows[0].Cells["id"].Value);
		    string nombreMod = dgvModulos.SelectedRows[0].Cells["nombre_es"].Value.ToString();
		
		    GestionPreguntas frm = new GestionPreguntas(idModulo, nombreMod);
		    frm.ShowDialog();
		}
    }
}
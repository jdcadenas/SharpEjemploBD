void BtnEliminarClick(object sender, EventArgs e)
		{
			if (dgvUsuarios.CurrentRow == null)
			{
				MessageBox.Show("Seleccione un usuario para eliminar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			// almacena 
			
			int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["Id"].Value);
			
			
			string nombre = dgvUsuarios.CurrentRow.Cells["Nombre"].Value.ToString();

			DialogResult dr = MessageBox.Show(string.Format("¿Está seguro de eliminar a '{0}'?", nombre), "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (dr == DialogResult.Yes)
			{
				string sql = "DELETE FROM Usuario WHERE Id = @id";
				try {
						using (MySqlConnection conexion = new MySqlConnection(cadenaConexion)) 
				
				using (MySqlCommand cmd = new MySqlCommand(sql, conexion))
				{
					// Paso 4: Asignar parámetros
					
					cmd.Parameters.AddWithValue("@id", id);
					// Paso 5: Abrir y ejecutar
					conexion.Open();
					cmd.ExecuteNonQuery();
				}
				} catch (Exception ex) {
				
				MessageBox.Show(string.Format("No se pudo realizar conexion por : {0}",ex.Message));
			}
						
						
						
				CargarUsuarios();
			}
		}
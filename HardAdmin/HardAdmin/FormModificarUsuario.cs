using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardAdmin
{
    public partial class FormModificarUsuario : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;
        private int idUsuario;

        public FormModificarUsuario(int idUsuario)
        {
            InitializeComponent();
            this.idUsuario = idUsuario;

            CargarRoles();
            CargarDatosUsuario();
        }

        private void CargarRoles()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT id_rol, nombre_rol FROM Rol";
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        cmbRol.DisplayMember = "nombre_rol";
                        cmbRol.ValueMember = "id_rol";
                        cmbRol.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDatosUsuario()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT nombre_usuario, " +
                                   "email, " +
                                   "id_rol, " +
                                   "baja " +
                                   "FROM Usuario " +
                                   "WHERE id_usuario = @id";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@id", this.idUsuario);
                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNombreUsuario.Text = reader["nombre_usuario"].ToString();
                                txtEmail.Text = reader["email"].ToString();
                                cmbRol.SelectedValue = Convert.ToInt32(reader["id_rol"]);

                                int baja = Convert.ToInt32(reader["baja"]);

                                if (baja == 0)
                                {
                                    rbActivoSi.Checked = true;
                                }
                                else
                                {
                                    rbActivoNo.Checked = true;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageBox.Show("Completá los campos requeridos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int baja = rbActivoSi.Checked ? 0 : 1;
            bool cambiaContrasena = !string.IsNullOrWhiteSpace(txtContrasena.Text);

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"UPDATE Usuario 
                             SET nombre_usuario = @usuario, 
                                 email = @email, 
                                 id_rol = @idRol,
                                 baja = @baja"
                             + (cambiaContrasena ? ", contrasena = @pass" : "")
                             + " WHERE id_usuario = @id";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@usuario", txtNombreUsuario.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", txtEmail.Text.Trim());
                        cmd.Parameters.AddWithValue("@idRol", (int)cmbRol.SelectedValue);
                        cmd.Parameters.AddWithValue("@baja", baja);
                        cmd.Parameters.AddWithValue("@id", this.idUsuario);

                        if (cambiaContrasena)
                        {
                            // Hasheamos la nueva contraseña antes de persistir
                            string nuevaContrasenaHash = Seguridad.HashearContrasena(txtContrasena.Text);
                            cmd.Parameters.AddWithValue("@pass", nuevaContrasenaHash);
                        }

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Usuario modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
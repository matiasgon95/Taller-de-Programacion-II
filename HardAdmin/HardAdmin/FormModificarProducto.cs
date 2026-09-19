using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HardAdmin
{
    public partial class FormModificarProducto : Form
    {
        // Traemos la cadena de conexión desde el archivo de configuración (App.config).
        // Es mejor tenerla ahí centralizada por si el día de mañana cambiamos de servidor.
        private string connectionString = ConfigurationManager.ConnectionStrings["HardAdminConnection"].ConnectionString;

        // Se crea por código para no depender de agregarlo desde el diseñador.
        private ErrorProvider errorProvider = new ErrorProvider();

        // Se van completando durante cada intento de guardar (ver Marcar()).
        private bool formularioValido;
        private List<Control> controlesInvalidos = new List<Control>();

        private int idProducto;

        // Ruta de la imagen que el usuario seleccionara mediante el OpenFileDialog.
        // Se mantiene temporalmente hasta que el usuario confirme el registro.
        private string rutaImagenSeleccionada = null;


        // Inicializa el formulario de modificación y recibe el ID
        // del producto que se desea editar.
        public FormModificarProducto(int idProducto)
        {
            InitializeComponent();

            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            // Longitudes máximas
            txtNombre.MaxLength = 80;
            txtCodigo.MaxLength = 50;
            txtDescripcion.MaxLength = 300;

            // Revalida cada campo al salir de él, así el error desaparece apenas se corrige
            // sin tener que volver a apretar Guardar.
            txtNombre.Leave += txtNombre_Leave;
            txtCodigo.Leave += txtCodigo_Leave;
            txtDescripcion.Leave += txtDescripcion_Leave;

            // Revalidación de la categoría
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;

            // Revalidación de los NumericUpDown
            nupPrecio.ValueChanged += nupPrecio_ValueChanged;
            nupStockMinimo.ValueChanged += nupStockMinimo_ValueChanged;
            nupStockActual.ValueChanged += nupStockActual_ValueChanged;

            this.idProducto = idProducto;
        }

        private void FormModificarProducto_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarProducto();
        }

        private void CargarCategorias()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT id_categoria, nombre_categoria FROM Categoria WHERE baja = 0";
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        con.Open();
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            cmbCategoria.DataSource = dt;
                            cmbCategoria.DisplayMember = "nombre_categoria";
                            cmbCategoria.ValueMember = "id_categoria";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorias: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // Marca (o limpia) el error de un control puntual y actualiza el estado general
        // del formulario, sin cortar la ejecución. Así se revisan todos los campos de una.
        private void Marcar(Control control, bool condicionValida, string mensajeError)
        {
            if (condicionValida)
            {
                errorProvider.SetError(control, string.Empty);
                controlesInvalidos.Remove(control);
            }
            else
            {
                errorProvider.SetError(control, mensajeError);
                formularioValido = false;
                if (!controlesInvalidos.Contains(control))
                {
                    controlesInvalidos.Add(control);
                }
            }
        }

        // De todos los controles marcados como inválidos, devuelve el que corresponde
        // según el orden de tabulación (TabIndex) del formulario, no el orden del código.
        private void EnfocarPrimerInvalidoPorTabOrder()
        {
            Control primero = controlesInvalidos.OrderBy(c => c.TabIndex).FirstOrDefault();
            primero?.Focus();
        }

        // Verifica si ya existe un valor cargado en una columna de Producto (nombre/codigo)
        // Y tambien descarta el codigo actualmente usado para la modificacion actual.
        private bool ExisteEnProducto(string columna, string valor)
        {
            string query = $"SELECT COUNT(1) FROM Producto WHERE {columna} = @valor AND id_producto <> @idProducto";
            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@valor", valor);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                con.Open();
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        // ---------- Validación por campo (se usan tanto al salir del campo como al guardar) ----------

        private bool ValidarNombre()
        {
            string valor = txtNombre.Text.Trim();
            bool ok = !string.IsNullOrWhiteSpace(valor)
                      && valor.Length <= 80;
            Marcar(
                txtNombre,
                ok,
                "El nombre del producto es obligatorio y no puede superar los 80 caracteres."
            );
            return ok;
        }

        private bool ValidarDescripcion()
        {
            string valor = txtDescripcion.Text.Trim();
            bool ok = !string.IsNullOrWhiteSpace(valor)
                      && valor.Length <= 300;
            Marcar(
                txtDescripcion,
                ok,
                "La descripción es obligatoria y no puede superar los 300 caracteres."
            );
            return ok;
        }

        private bool ValidarCodigo()
        {
            string valor = txtCodigo.Text.Trim();
            if (string.IsNullOrWhiteSpace(valor))
            {
                Marcar(
                    txtCodigo,
                    false,
                    "El código del producto es obligatorio."
                );
                return false;
            }
            bool disponible = !ExisteEnProducto("codigo", valor);
            Marcar(
                txtCodigo,
                disponible,
                "El código ya se encuentra registrado."
            );

            return disponible;
        }

        private bool ValidarCategoria()
        {
            bool ok = cmbCategoria.SelectedValue != null;
            Marcar(
                cmbCategoria,
                ok,
                "Debe seleccionar una categoría."
            );
            return ok;
        }

        private bool ValidarPrecio()
        {
            bool ok = nupPrecio.Value > 0;
            Marcar(
                nupPrecio,
                ok,
                "El precio debe ser mayor a 0."
            );
            return ok;
        }

        private bool ValidarStockMinimo()
        {
            bool ok = nupStockMinimo.Value >= 0;
            Marcar(
                nupStockMinimo,
                ok,
                "El stock mínimo no puede ser negativo."
            );
            return ok;
        }

        private bool ValidarStockActual()
        {
            bool ok = nupStockActual.Value >= 0;
            Marcar(
                nupStockActual,
                ok,
                "El stock actual no puede ser negativo."
            );
            return ok;
        }


        // Implementacion de los eventos con las validaciones anteriores.
        private void txtNombre_Leave(object sender, EventArgs e)
        {
            ValidarNombre();
        }

        private void txtCodigo_Leave(object sender, EventArgs e)
        {
            ValidarCodigo();
        }

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            ValidarDescripcion();
        }

        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ValidarCategoria();
        }

        private void nupPrecio_ValueChanged(object sender, EventArgs e)
        {
            ValidarPrecio();
        }

        private void nupStockMinimo_ValueChanged(object sender, EventArgs e)
        {
            ValidarStockMinimo();
        }

        private void nupStockActual_ValueChanged(object sender, EventArgs e)
        {
            ValidarStockActual();
        }


        // Busca la imagen del producto a partir de la ruta almacenada
        // en la base de datos y la muestra en el PictureBox.
        private void CargarImagenProducto(string rutaFoto)
        {
            // Si no existe una ruta almacenada, no hay ninguna imagen que cargar.
            if (string.IsNullOrWhiteSpace(rutaFoto))
            {
                return;
            }

            // Comenzamos desde la carpeta donde se está ejecutando
            // la aplicación.
            DirectoryInfo directorioActual = new DirectoryInfo(Application.StartupPath);

            DirectoryInfo carpetaImagenes = null;

            // Buscamos la carpeta ImagenesProductos subiendo
            // por los directorios hasta encontrarla.
            while (directorioActual != null)
            {
                string posibleRuta = Path.Combine(
                    directorioActual.FullName,
                    "ImagenesProductos"
                );

                if (Directory.Exists(posibleRuta))
                {
                    carpetaImagenes = new DirectoryInfo(posibleRuta);
                    break;
                }

                directorioActual = directorioActual.Parent;
            }

            // Si no encontramos la carpeta, mostramos un mensaje
            // y dejamos el PictureBox sin imagen.
            if (carpetaImagenes == null)
            {
                MessageBox.Show(
                    "No se encontró la carpeta ImagenesProductos.",
                    "Imagen no encontrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            // Nos quedamos solamente con el nombre del archivo para
            // combinarlo con la carpeta que acabamos de encontrar.
            string nombreArchivo = Path.GetFileName(rutaFoto);

            string rutaCompleta = Path.Combine(
                carpetaImagenes.FullName,
                nombreArchivo
            );

            // Verificamos que el archivo realmente exista.
            if (!File.Exists(rutaCompleta))
            {
                MessageBox.Show(
                    "No se encontró la imagen del producto.",
                    "Imagen no encontrada",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );

                return;
            }

            try
            {
                // Liberamos la imagen anterior, si existía.
                if (pbImagen.Image != null)
                {
                    pbImagen.Image.Dispose();
                    pbImagen.Image = null;
                }

                // Abrimos el archivo y creamos una copia de la imagen.
                // Esto evita mantener bloqueado el archivo original.
                using (FileStream stream = new FileStream(
                    rutaCompleta,
                    FileMode.Open,
                    FileAccess.Read))
                {
                    using (Image imagenTemporal = Image.FromStream(stream))
                    {
                        pbImagen.Image = new Bitmap(imagenTemporal);
                    }
                }

                // Adaptamos la imagen al tamaño del PictureBox
                // manteniendo sus proporciones.
                pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "No se pudo cargar la imagen del producto: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        // Busca en la base de datos el producto correspondiente al ID recibido
        // y carga sus datos en los controles del formulario.
        private void CargarProducto()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
                SELECT
                    id_producto,
                    codigo,
                    nombre_producto,
                    descripcion,
                    precio,
                    stock,
                    stock_minimo,
                    foto_producto,
                    baja,
                    id_categoria
                FROM Producto
                WHERE id_producto = @idProducto";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@idProducto", idProducto);

                        con.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            // Verificamos que el producto exista.
                            if (reader.Read())
                            {
                                // Cargamos los datos de texto.
                                txtCodigo.Text = reader["codigo"].ToString();
                                txtNombre.Text = reader["nombre_producto"].ToString();
                                txtDescripcion.Text = reader["descripcion"].ToString();

                                // Cargamos los valores numéricos.
                                nupPrecio.Value = Convert.ToDecimal(reader["precio"]);
                                nupStockActual.Value = Convert.ToDecimal(reader["stock"]);
                                nupStockMinimo.Value = Convert.ToDecimal(reader["stock_minimo"]);

                                // Seleccionamos la categoría correspondiente.
                                cmbCategoria.SelectedValue =
                                    Convert.ToInt32(reader["id_categoria"]);

                                // Cargamos el estado del producto.
                                // En la base de datos: baja = 0 significa activo,
                                // mientras que baja = 1 significa dado de baja.
                                bool productoDadoDeBaja = Convert.ToBoolean(reader["baja"]);

                                rbSi.Checked = !productoDadoDeBaja;
                                rbNo.Checked = productoDadoDeBaja;

                                // La imagen la cargaremos por separado.
                                // Primero obtenemos la ruta almacenada en la BD.
                                if (reader["foto_producto"] != DBNull.Value)
                                {
                                    string rutaFoto = reader["foto_producto"].ToString();

                                    CargarImagenProducto(rutaFoto);
                                }
                            }
                            else
                            {
                                MessageBox.Show(
                                    "No se encontró el producto seleccionado.",
                                    "Atención",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );

                                this.DialogResult = DialogResult.Cancel;
                                this.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar el producto: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        // Permite seleccionar una nueva imagen para el producto
        // y la muestra en el PictureBox.
        // La imagen no se copia al proyecto hasta guardar los cambios.
        private void btnSubir_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Title = "Seleccionar imagen del producto";
                dialogo.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.webp";
                dialogo.Multiselect = false;

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    // Guardamos la ruta de la nueva imagen seleccionada.
                    rutaImagenSeleccionada = dialogo.FileName;

                    // Liberamos la imagen anterior que estaba mostrando el PictureBox.
                    if (pbImagen.Image != null)
                    {
                        pbImagen.Image.Dispose();
                        pbImagen.Image = null;
                    }

                    // Cargamos la nueva imagen y creamos una copia.
                    // Esto evita mantener bloqueado el archivo original.
                    using (FileStream stream = new FileStream(
                        rutaImagenSeleccionada,
                        FileMode.Open,
                        FileAccess.Read))
                    {
                        using (Image imagenTemporal = Image.FromStream(stream))
                        {
                            pbImagen.Image = new Bitmap(imagenTemporal);
                        }
                    }

                    pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }

        // Funcion que guarda una copia de la imagen seleccionada dentro de la carpeta
        // destinada a las imágenes de los productos.
        private string GuardarImagenProducto(string codigo)
        {
            // Si el usuario no seleccionó ninguna imagen,
            // no hay nada que guardar.
            if (string.IsNullOrEmpty(rutaImagenSeleccionada))
            {
                return null;
            }

            // Busca la carpeta donde se está ejecutando
            // la aplicación.
            DirectoryInfo directorioActual =
                new DirectoryInfo(Application.StartupPath);
            DirectoryInfo carpetaImagenes = null;

            // Busca la carpeta ImagenesProductos (donde se almacenan las imagenes) subiendo
            // por los directorios hasta encontrarla.
            while (directorioActual != null)
            {
                string posibleRuta = Path.Combine(
                    directorioActual.FullName,
                    "ImagenesProductos"
                );

                if (Directory.Exists(posibleRuta))
                {
                    carpetaImagenes = new DirectoryInfo(posibleRuta);
                    break;
                }

                directorioActual = directorioActual.Parent;
            }

            // Si no encontramos la carpeta, informamos el problema.
            if (carpetaImagenes == null)
            {
                throw new DirectoryNotFoundException(
                    "No se encontró la carpeta ImagenesProductos."
                );
            }

            // Conservamos la extensión original (.jpg, .png, etc.).
            string extension = Path.GetExtension(rutaImagenSeleccionada);

            // Utilizamos el código del producto como nombre del archivo.
            string nombreArchivo = codigo + extension;

            // Construimos la ruta completa donde se copiará la imagen.
            string rutaDestino = Path.Combine(
                carpetaImagenes.FullName,
                nombreArchivo
            );

            // Copiamos la imagen al directorio del proyecto.
            // El parámetro true permite reemplazar una imagen existente
            // con el mismo nombre.
            File.Copy(
                rutaImagenSeleccionada,
                rutaDestino,
                true
            );

            // Devolvemos una ruta relativa para guardar en la base de datos.
            return Path.Combine(
                "ImagenesProductos",
                nombreArchivo
            );
        }

        // El boton Guardar de esta seccion valida los datos ingresados y actualiza el producto existente
        // en la base de datos.
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            formularioValido = true;
            controlesInvalidos.Clear();

            // Ejecutamos las validaciones del formulario.
            ValidarNombre();
            ValidarCodigo();
            ValidarDescripcion();
            ValidarCategoria();
            ValidarPrecio();
            ValidarStockMinimo();
            ValidarStockActual();

            if (!formularioValido)
            {
                EnfocarPrimerInvalidoPorTabOrder();
                return;
            }

            // A partir de acá sabemos que los datos son válidos.

            string nombre = txtNombre.Text.Trim();
            string codigo = txtCodigo.Text.Trim();
            string descripcion = txtDescripcion.Text.Trim();

            int idCategoria = (int)cmbCategoria.SelectedValue;

            decimal precio = nupPrecio.Value;
            int stockMinimo = (int)nupStockMinimo.Value;
            int stockActual = (int)nupStockActual.Value;

            // rbSi significa que el producto está activo.
            // En la base de datos, baja = 0 significa activo.
            int baja = rbNo.Checked ? 1 : 0;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query;

                    // Si el usuario seleccionó una imagen nueva,
                    // primero debemos guardarla y luego actualizar la ruta.
                    if (rutaImagenSeleccionada != null)
                    {
                        string rutaFoto = GuardarImagenProducto(codigo);

                        query = @"
                    UPDATE Producto
                    SET
                        codigo = @codigo,
                        nombre_producto = @nombre,
                        descripcion = @descripcion,
                        precio = @precio,
                        stock = @stock,
                        stock_minimo = @stockMinimo,
                        foto_producto = @foto,
                        baja = @baja,
                        id_categoria = @idCategoria
                    WHERE id_producto = @idProducto";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@codigo", codigo);
                            cmd.Parameters.AddWithValue("@nombre", nombre);
                            cmd.Parameters.AddWithValue("@descripcion", descripcion);
                            cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio;
                            cmd.Parameters.AddWithValue("@stock", stockActual);
                            cmd.Parameters.AddWithValue("@stockMinimo", stockMinimo);
                            cmd.Parameters.AddWithValue("@foto", rutaFoto);
                            cmd.Parameters.AddWithValue("@baja", baja);
                            cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                            cmd.Parameters.AddWithValue("@idProducto", idProducto);

                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        // Si no seleccionamos una imagen nueva,
                        // mantenemos la imagen que ya tenía el producto.
                        query = @"
                    UPDATE Producto
                    SET
                        codigo = @codigo,
                        nombre_producto = @nombre,
                        descripcion = @descripcion,
                        precio = @precio,
                        stock = @stock,
                        stock_minimo = @stockMinimo,
                        baja = @baja,
                        id_categoria = @idCategoria
                    WHERE id_producto = @idProducto";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@codigo", codigo);
                            cmd.Parameters.AddWithValue("@nombre", nombre);
                            cmd.Parameters.AddWithValue("@descripcion", descripcion);
                            cmd.Parameters.Add("@precio", SqlDbType.Decimal).Value = precio;
                            cmd.Parameters.AddWithValue("@stock", stockActual);
                            cmd.Parameters.AddWithValue("@stockMinimo", stockMinimo);
                            cmd.Parameters.AddWithValue("@baja", baja);
                            cmd.Parameters.AddWithValue("@idCategoria", idCategoria);
                            cmd.Parameters.AddWithValue("@idProducto", idProducto);

                            con.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show(
                    "Producto modificado con éxito.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    MessageBox.Show(
                        "El código del producto ya se encuentra registrado.",
                        "Atención",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                }
                else
                {
                    MessageBox.Show(
                        "Error de base de datos: " + ex.Message,
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error inesperado: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }







        // Dejamos vacíos estos métodos temporales para que no se rompa el diseñador si había quedado algún rastro.
        // Después podés borrar estas dos líneas tranquilamente.

        private void label10_Click(object sender, EventArgs e){ }

        private void label11_Click(object sender, EventArgs e){  }

        private void rbNo_CheckedChanged(object sender, EventArgs e){ }

    }
}

using HardAdmin.Entidades;
using HardAdmin.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private ProductoServicio servicio = new ProductoServicio();
        private CategoriaServicio servicioCategoria = new CategoriaServicio();
        private ErrorProvider errorProvider = new ErrorProvider();
        private bool formularioValido;
        private List<Control> controlesInvalidos = new List<Control>();
        private int idProducto;
        private string rutaImagenSeleccionada = null;

        public FormModificarProducto(int idProducto)
        {
            InitializeComponent();

            errorProvider.ContainerControl = this;
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            txtNombre.MaxLength = 80;
            txtCodigo.MaxLength = 50;
            txtDescripcion.MaxLength = 300;

            txtNombre.Leave += txtNombre_Leave;
            txtCodigo.Leave += txtCodigo_Leave;
            txtDescripcion.Leave += txtDescripcion_Leave;
            cmbCategoria.SelectedIndexChanged += cmbCategoria_SelectedIndexChanged;
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
                DataTable dt = servicioCategoria.ObtenerParaGrilla();
                DataView vista = new DataView(dt);
                vista.RowFilter = "activa = true";

                cmbCategoria.DataSource = vista;
                cmbCategoria.DisplayMember = "nombre_categoria";
                cmbCategoria.ValueMember = "id_categoria";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las categorías: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void EnfocarPrimerInvalidoPorTabOrder()
        {
            Control primero = controlesInvalidos.OrderBy(c => c.TabIndex).FirstOrDefault();
            primero?.Focus();
        }

        private bool ValidarNombre()
        {
            string valor = txtNombre.Text.Trim();
            bool ok = !string.IsNullOrWhiteSpace(valor) && valor.Length <= 80;
            Marcar(txtNombre, ok, "El nombre del producto es obligatorio y no puede superar los 80 caracteres.");
            return ok;
        }

        private bool ValidarDescripcion()
        {
            string valor = txtDescripcion.Text.Trim();
            bool ok = !string.IsNullOrWhiteSpace(valor) && valor.Length <= 300;
            Marcar(txtDescripcion, ok, "La descripción es obligatoria y no puede superar los 300 caracteres.");
            return ok;
        }

        private bool ValidarCodigo()
        {
            string valor = txtCodigo.Text.Trim();
            if (string.IsNullOrWhiteSpace(valor))
            {
                Marcar(txtCodigo, false, "El código del producto es obligatorio.");
                return false;
            }
            bool disponible = !servicio.ExisteCodigo(valor, idProducto);
            Marcar(txtCodigo, disponible, "El código ya se encuentra registrado.");
            return disponible;
        }

        private bool ValidarCategoria()
        {
            bool ok = cmbCategoria.SelectedValue != null;
            Marcar(cmbCategoria, ok, "Debe seleccionar una categoría.");
            return ok;
        }

        private bool ValidarPrecio()
        {
            bool ok = nupPrecio.Value > 0;
            Marcar(nupPrecio, ok, "El precio debe ser mayor a 0.");
            return ok;
        }

        private bool ValidarStockMinimo()
        {
            bool ok = nupStockMinimo.Value >= 0;
            Marcar(nupStockMinimo, ok, "El stock mínimo no puede ser negativo.");
            return ok;
        }

        private bool ValidarStockActual()
        {
            bool ok = nupStockActual.Value >= 0;
            Marcar(nupStockActual, ok, "El stock actual no puede ser negativo.");
            return ok;
        }

        private void txtNombre_Leave(object sender, EventArgs e) => ValidarNombre();
        private void txtCodigo_Leave(object sender, EventArgs e) => ValidarCodigo();
        private void txtDescripcion_Leave(object sender, EventArgs e) => ValidarDescripcion();
        private void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e) => ValidarCategoria();
        private void nupPrecio_ValueChanged(object sender, EventArgs e) => ValidarPrecio();
        private void nupStockMinimo_ValueChanged(object sender, EventArgs e) => ValidarStockMinimo();
        private void nupStockActual_ValueChanged(object sender, EventArgs e) => ValidarStockActual();

        private void CargarImagenProducto(string rutaFoto)
        {
            if (string.IsNullOrWhiteSpace(rutaFoto)) return;

            DirectoryInfo directorioActual = new DirectoryInfo(Application.StartupPath);
            DirectoryInfo carpetaImagenes = null;

            while (directorioActual != null)
            {
                string posibleRuta = Path.Combine(directorioActual.FullName, "ImagenesProductos");
                if (Directory.Exists(posibleRuta))
                {
                    carpetaImagenes = new DirectoryInfo(posibleRuta);
                    break;
                }
                directorioActual = directorioActual.Parent;
            }

            if (carpetaImagenes == null)
            {
                MessageBox.Show("No se encontró la carpeta ImagenesProductos.", "Imagen no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreArchivo = Path.GetFileName(rutaFoto);
            string rutaCompleta = Path.Combine(carpetaImagenes.FullName, nombreArchivo);

            if (!File.Exists(rutaCompleta))
            {
                MessageBox.Show("No se encontró la imagen del producto.", "Imagen no encontrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (pbImagen.Image != null)
                {
                    pbImagen.Image.Dispose();
                    pbImagen.Image = null;
                }

                using (FileStream stream = new FileStream(rutaCompleta, FileMode.Open, FileAccess.Read))
                {
                    using (Image imagenTemporal = Image.FromStream(stream))
                    {
                        pbImagen.Image = new Bitmap(imagenTemporal);
                    }
                }

                pbImagen.SizeMode = PictureBoxSizeMode.Zoom;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se pudo cargar la imagen del producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarProducto()
        {
            try
            {
                Producto producto = servicio.ObtenerPorId(idProducto);

                if (producto == null)
                {
                    MessageBox.Show("No se encontró el producto seleccionado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                    return;
                }

                txtCodigo.Text = producto.Codigo;
                txtNombre.Text = producto.NombreProducto;
                txtDescripcion.Text = producto.Descripcion;
                nupPrecio.Value = producto.Precio;
                nupStockActual.Value = producto.Stock;
                nupStockMinimo.Value = producto.StockMinimo;
                cmbCategoria.SelectedValue = producto.IdCategoria;

                bool productoDadoDeBaja = producto.Baja == 1;
                rbSi.Checked = !productoDadoDeBaja;
                rbNo.Checked = productoDadoDeBaja;

                if (!string.IsNullOrWhiteSpace(producto.FotoProducto))
                {
                    CargarImagenProducto(producto.FotoProducto);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar el producto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Title = "Seleccionar imagen del producto";
                dialogo.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.webp";
                dialogo.Multiselect = false;

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    rutaImagenSeleccionada = dialogo.FileName;

                    if (pbImagen.Image != null)
                    {
                        pbImagen.Image.Dispose();
                        pbImagen.Image = null;
                    }

                    using (FileStream stream = new FileStream(rutaImagenSeleccionada, FileMode.Open, FileAccess.Read))
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

        private string GuardarImagenProducto(string codigo)
        {
            if (string.IsNullOrEmpty(rutaImagenSeleccionada))
            {
                return null;
            }

            DirectoryInfo directorioActual = new DirectoryInfo(Application.StartupPath);
            DirectoryInfo carpetaImagenes = null;

            while (directorioActual != null)
            {
                string posibleRuta = Path.Combine(directorioActual.FullName, "ImagenesProductos");
                if (Directory.Exists(posibleRuta))
                {
                    carpetaImagenes = new DirectoryInfo(posibleRuta);
                    break;
                }
                directorioActual = directorioActual.Parent;
            }

            if (carpetaImagenes == null)
            {
                throw new DirectoryNotFoundException("No se encontró la carpeta ImagenesProductos.");
            }

            string extension = Path.GetExtension(rutaImagenSeleccionada);
            string nombreArchivo = codigo + extension;
            string rutaDestino = Path.Combine(carpetaImagenes.FullName, nombreArchivo);

            File.Copy(rutaImagenSeleccionada, rutaDestino, true);

            return Path.Combine("ImagenesProductos", nombreArchivo);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            formularioValido = true;
            controlesInvalidos.Clear();

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

            Producto producto = new Producto
            {
                IdProducto = idProducto,
                Codigo = txtCodigo.Text.Trim(),
                NombreProducto = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Precio = nupPrecio.Value,
                Stock = (int)nupStockActual.Value,
                StockMinimo = (int)nupStockMinimo.Value,
                IdCategoria = (int)cmbCategoria.SelectedValue,
                Baja = rbNo.Checked ? 1 : 0
            };

            try
            {
                if (rutaImagenSeleccionada != null)
                {
                    producto.FotoProducto = GuardarImagenProducto(producto.Codigo);
                }
                else
                {
                    Producto productoActual = servicio.ObtenerPorId(idProducto);
                    producto.FotoProducto = productoActual?.FotoProducto;
                }

                // Delegamos a la capa de Negocio
                servicio.Modificar(producto);

                MessageBox.Show("Producto modificado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                // El error masticado por la capa de negocio se muestra acá
                MessageBox.Show(ex.Message, "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        // Métodos vacíos para no romper el diseñador
        private void label10_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
        private void rbNo_CheckedChanged(object sender, EventArgs e) { }
    }
}
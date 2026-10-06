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
    public partial class FormAgregarProducto : Form
    {
        // Traemos la cadena de conexión desde el archivo de la capa de Servcio de producto.
        private ProductoServicio servicio = new ProductoServicio();

        private CategoriaServicio servicioCategoria = new CategoriaServicio();

        // Se crea por código para no depender de agregarlo desde el diseñador.
        private ErrorProvider errorProvider = new ErrorProvider();

        // Se van completando durante cada intento de guardar (ver Marcar()).
        private bool formularioValido;
        private List<Control> controlesInvalidos = new List<Control>();

        // Ruta de la imagen que el usuario seleccionara mediante el OpenFileDialog.
        // Se mantiene temporalmente hasta que el usuario confirme el registro.
        private string rutaImagenSeleccionada = null;


        public FormAgregarProducto()
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
        }

        private void FormAgregarProducto_Load(object sender, EventArgs e)
        {
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            try
            {
                DataTable dt = servicioCategoria.ObtenerParaGrilla();

                // El método ObtenerParaGrilla() también trae el estado
                // de la categoría, pero para este combobox solamente necesitamos las categorías activas.
                DataView vista = new DataView(dt);
                vista.RowFilter = "activa = true";

                cmbCategoria.DataSource = vista;
                cmbCategoria.DisplayMember = "nombre_categoria";
                cmbCategoria.ValueMember = "id_categoria";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error al cargar las categorías: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
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
            bool disponible = !servicio.ExisteCodigo(valor, 0);
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


        // Permite al usuario seleccionar una imagen desde su computadora
        // y la muestra en el PictureBox del formulario.
        private void btnSubir_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dialogo = new OpenFileDialog())
            {
                dialogo.Title = "Seleccionar imagen del producto";
                dialogo.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.webp";
                dialogo.Multiselect = false;

                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    // Guardamos la ruta original de la imagen seleccionada.
                    rutaImagenSeleccionada = dialogo.FileName;

                    // Liberamos la imagen anterior, si existía.
                    if (pbImagen.Image != null)
                    {
                        pbImagen.Image.Dispose();
                        pbImagen.Image = null;
                    }

                    // Cargamos la imagen seleccionada y creamos una copia.
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

                    // Hace que la imagen se adapte al tamaño del PictureBox
                    // manteniendo sus proporciones.
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

        // La funcion principal de guardar el producto a la base de datos.
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

            // A partir de acá sabemos que los datos son válidos.

            // Armamos la entidad Producto con los datos ingresados en el formulario.
            Producto producto = new Producto
            {
                Codigo = txtCodigo.Text.Trim(),
                NombreProducto = txtNombre.Text.Trim(),
                Descripcion = txtDescripcion.Text.Trim(),
                Precio = nupPrecio.Value,
                Stock = (int)nupStockActual.Value,
                StockMinimo = (int)nupStockMinimo.Value,
                IdCategoria = (int)cmbCategoria.SelectedValue,

                // Un producto nuevo se registra como activo.
                Baja = 0
            };

            try
            {
                // Guarda la imagen seleccionada en el proyecto y obtiene
                // la ruta relativa que será almacenada en la base de datos.
                producto.FotoProducto = GuardarImagenProducto(producto.Codigo);

                // El formulario no ejecuta SQL directamente.
                // El servicio se encarga de validar las reglas de negocio
                // y luego guardar el producto mediante el repositorio.
                servicio.Guardar(producto);

                MessageBox.Show(
                    "Producto registrado con éxito.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Atención",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
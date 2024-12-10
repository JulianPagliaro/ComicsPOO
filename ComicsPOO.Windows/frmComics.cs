using ComicsPOO.Datos;
using ComicsPOO.Entidades;
using ComicsPOO.Windows.Helpers;

namespace ComicsPOO.Windows
{
    public partial class frmComics : Form
    {
        private Comiqueria comiqueria;

        public frmComics()
        {
            InitializeComponent();
            comiqueria = new Comiqueria("JGP comics club");
        }

        private void frmComics_Load(object sender, EventArgs e)
        {
            try
            {
                comiqueria.RecuperarDatos();

                MessageBox.Show("Datos recuperados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GridHelper.MostrarDatosEnGrilla<Producto>(comiqueria.GetProductos(), dgvDatos);
                ActualizarCantidadProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void ActualizarCantidadProductos()
        {
            txtCantidad.Text = $"{comiqueria.GetCantidad()}";
        }
        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmProductoAE frm = new frmProductoAE() { Text = "Nuevo Producto" };
            DialogResult = frm.ShowDialog(this);
            if (DialogResult == DialogResult.Cancel) return;
            Producto? producto = frm.GetProducto();
            if (producto == null) return;

            comiqueria!.Agregar(producto);

            MessageBox.Show($"Se agregó {producto.ToString()}", "Depósito",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
            GridHelper.MostrarDatosEnGrilla<Producto>(comiqueria.GetProductos(), dgvDatos);
            ActualizarCantidadProductos();
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            comiqueria.GuardarDatos();
            Application.Exit();
        }

        private void tsbGuardar_Click(object sender, EventArgs e)
        {
            comiqueria.GuardarDatos();
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un producto.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var filaSeleccionada = dgvDatos.SelectedRows[0];
            var codigoProducto = (Guid)filaSeleccionada.Cells["colCodigo"].Value;

            var respuesta = MessageBox.Show("¿Está seguro de que desea retirar este producto?",
                                            "Confirmar eliminación",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);
            if (respuesta == DialogResult.No)
                return;

            bool exito = comiqueria.RetirarProducto(codigoProducto);

            if (exito)
            {
                MessageBox.Show("Producto eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("El producto no se encontró o no se pudo eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ActualizarCantidadProductos();
            ActualizarGrilla();
        }
        private void ActualizarGrilla()
        {
            dgvDatos.DataSource = null;
            dgvDatos.DataSource = comiqueria.GetProductos();
        }
    }

}

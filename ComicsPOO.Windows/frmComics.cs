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
            comiqueria = new Comiqueria("Juli comics");
        }

        private void frmComics_Load(object sender, EventArgs e)
        {

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
        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {

        }
    }
}

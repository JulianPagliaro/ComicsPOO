using ComicsPOO.Entidades;
using ComicsPOO.Windows.Helpers;

namespace ComicsPOO.Windows
{
    public partial class frmProductoAE : Form
    {
        private Producto? producto;
        private decimal precio;
        private Comic comic;
        private Figurita figurita;

        public frmProductoAE()
        {
            InitializeComponent();
            rbtComic.CheckedChanged += new EventHandler(frmProductoAE_Load);
            rbtFigurita.CheckedChanged += new EventHandler(frmProductoAE_Load);
        }
        public Producto? GetProducto()
        {
            return producto;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            {
                if (!ValidarDatos()) return;

                if (rbtComic.Checked)
                {
                    comic = new Comic()
                    {
                        Descripcion = txtDescripcion.Text,
                        Autor = txtAutor.Text,
                        Stock = (int)nudStock.Value,
                        Precio = decimal.Parse(txtPrecio.Text),
                        TipoComic = (TipoComic)cboTipo.SelectedItem

                    };
                    producto = comic;
                }
                else if (rbtFigurita.Checked)
                {
                    figurita = new Figurita()
                    {
                        Descripcion = txtDescripcion.Text,
                        Altura = float.Parse(txtAltura.Text),
                        Stock = (int)nudStock.Value,
                        Precio = decimal.Parse(txtPrecio.Text),
                        
                    };
                    producto = figurita;
                }
                

                DialogResult = DialogResult.OK;
                Close();
            }
        }



        private void frmProductoAE_Load(object sender, EventArgs e)
        {
            CargarCombo(); 
            ManejarControles(rbtComic.Checked ? TipoProducto.Comic : TipoProducto.Figurita);
        }

        private void CargarCombo()
        {
            if (rbtComic.Checked)
            {
                CombosHelper.CargarComboTipoComic(ref cboTipo);
            }
            else if (rbtFigurita.Checked)
            {
                CombosHelper.CargarComboTipoProducto(ref cboTipo);
            }
        }

        private void DeshabilitarControles()
        {
            txtAltura.Enabled = false;
            txtAutor.Enabled = false;
            txtDescripcion.Enabled = false;
            cboTipo.Enabled = false;
            gbTipo.Enabled = false;
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ManejarControles(TipoProducto tipoProducto)
        {
            if (tipoProducto == TipoProducto.Comic)
            {
                MostrarControles(true);
            }
            else
            {
                MostrarControles(false);
            }

        }

        private void MostrarControles(bool v)
        {
            lblAutor.Visible = v;
            txtAutor.Visible = v;
            lblTipo.Visible = v;
            cboTipo.Visible = v;

            lblAltura.Visible = !v;
            txtAltura.Visible = !v;

        }

        //private void btnCancelar_Click(object sender, EventArgs e)
        //{

        // DialogResult = DialogResult.Cancel;

        //}

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                valido = false;
                errorProvider1.SetError(txtDescripcion, "Debe agregar una descripción.");
            }

            if (rbtComic.Checked && string.IsNullOrWhiteSpace(txtAutor.Text))
            {
                valido = false;
                errorProvider1.SetError(txtAutor, "Debe agregar un autor para el cómic.");
            }

            if (rbtFigurita.Checked && (!decimal.TryParse(txtAltura.Text, out decimal altura) || altura <= 0))
            {
                valido = false;
                errorProvider1.SetError(txtAltura, "Debe ingresar una altura válida para la figurita.");
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio) || precio <= 0)
            {
                valido = false;
                errorProvider1.SetError(txtPrecio, "Debe ingresar un precio válido.");
            }

            return valido;
        }
    }
}

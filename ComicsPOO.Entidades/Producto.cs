using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ComicsPOO.Entidades
{
    [XmlInclude(typeof(Comic))]
    [XmlInclude(typeof(Figurita))]

    public abstract class Producto
    {
		private Guid codigo;
		private string? descripcion;
		private decimal precio;
		private int stock;

		public int Stock
        {
            get { return stock; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("La cantidad no puede ser negativa.");
                stock = value;
            }
        }



        public decimal Precio
        {
            get { return precio; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("El precio no puede ser negativo.");
                precio = value;
            }
        }


        public string? Descripcion
        {
            get { return descripcion; }
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentNullException(nameof(Descripcion), "La descripcion no puede ser nulo o vacío.");
                descripcion = value;
            }
        }



        public Guid Codigo
		{
			get { return codigo; }
			set { codigo = value; }
		}
        public Producto()
        {
            Codigo= Guid.NewGuid();
        }
        public Producto(string descripcion, decimal precio, int stock)
        {
			Descripcion = descripcion;
			Precio = precio;
			Stock = stock;
        }
        public override bool Equals(object obj)
        {
            if (obj is Producto otroProducto)
            {
                return Descripcion == otroProducto.Descripcion;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Descripcion.GetHashCode();
        }

        public override string ToString()
        {
            return $"Codigo: {Codigo}, Nombre: {Descripcion}, Precio: {Precio}, Cantidad: {Stock}";
        }


    }


}

﻿using ComicsPOO.Entidades;

namespace ComicsPOO.Datos
{
    public class Comiqueria
    {
        private readonly List<Producto> productos;
        private SerializadorXml serializadorXml;


        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        public Comiqueria(string nombre)
        {
            productos = new List<Producto>();
            Nombre = nombre;
            serializadorXml = new SerializadorXml();
            productos = serializadorXml.LeerDatos();
        }

        public bool Agregar(Producto producto)
        {
            if (!ExisteProducto(producto))
            {
                productos.Add(producto);
                Console.WriteLine("Producto agregado exitosamente.");
                return true;
            }
            else
            {
                Console.WriteLine("El elemento ya existe en la lista.");
                return false;
            }
        }
        public (bool exito, string mensaje) BuscarProducto(Producto producto)
        {
            var productoEncontrado = productos.FirstOrDefault(a => a.Descripcion == producto.Descripcion);

            if (productoEncontrado != null)
            {

                return (true, $"Producto: {producto.Descripcion}");
            }
            else
            {
                return (false, $"El producto no se encontró en la lista.");
            }
        }
        public bool RetirarProducto(Guid codigo)
        {
            Producto producto = productos.FirstOrDefault(p => p.Codigo == codigo);
            if (producto != null)
            {
                productos.Remove(producto);
                Console.WriteLine("Se retiró el producto.");
                return true;
            }
            Console.WriteLine("El producto no se encontró en la lista");
            return false;
        }

        public List<Producto> GetProductos()
        {
            return new List<Producto>(productos);
        }

        public int GetCantidad()
        {
            return productos.Count;
        }

        public void GuardarDatos()
        {
            serializadorXml.GuardarDatos(productos);

        }
        public void RecuperarDatos()
        {
            var datosRecuperados = serializadorXml.LeerDatos();
            productos.Clear();
            productos.AddRange(datosRecuperados);
        }
        public bool ExisteProducto(Producto producto)
        {
            return productos.Any(p => p.Descripcion == producto.Descripcion &&
            p.Precio == producto.Precio);
        }
    }
}

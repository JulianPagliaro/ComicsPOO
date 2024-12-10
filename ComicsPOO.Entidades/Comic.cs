using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ComicsPOO.Entidades
{
    public class Comic:Producto
    {
		private string autor;

		public string Autor
		{
			get { return autor; }
			set { autor = value; }
		}
		private TipoComic tipoComic;

		public TipoComic TipoComic
		{
			get { return tipoComic; }
			set { tipoComic = value; }
        }
        public Comic()
        {
            
        }
        public Comic(string descripcion, decimal precio, int stock, string autor, TipoComic tipoComic):base(descripcion, precio, stock)
		{
			Autor = autor;
			TipoComic = tipoComic;
		}
        public override string ToString()
        {
            return $"Codigo: {Codigo}, Nombre: {Descripcion}, Precio: {Precio}, Cantidad: {Stock}, Autor: {Autor}, Tipo de Comic: {TipoComic}";
        }
    }
}


namespace ComicsPOO.Entidades
{
    public class Figurita:Producto
    {
		private float altura;

		public float Altura
		{
			get { return altura; }
			set { altura = value; }
		}
        public Figurita()
        {
            
        }
        public Figurita(decimal precio, int stock, float altura):base($"Altura figurita {altura}",
          precio, stock)
        {
            Altura = altura;
        }
        public Figurita(string descripcion, decimal precio, int stock,float altura):base(descripcion,precio, stock)
        {
            
        }
        public override string ToString()
        {
            return $"Codigo: {Codigo}, Nombre: {Descripcion}, Precio: {Precio}, Cantidad: {Stock}, Altura: {Altura}";
        }

        
    }
}

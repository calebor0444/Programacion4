namespace ConsoleApp3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new ContextoBD())
            {
                var producto = new Producto { Nombre = "Producto 1" };
                contexto.Productos.Add(producto);

                contexto.SaveChanges();
                var productos = contexto.Productos.ToList();

                foreach (var p in productos)
                {
                    Console.WriteLine($"Id: {p.Id}, Nombre: {p.Nombre}");
                }
            }
        }
    }
}

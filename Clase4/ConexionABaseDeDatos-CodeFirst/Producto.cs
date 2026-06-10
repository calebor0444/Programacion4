using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ConsoleApp3
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}

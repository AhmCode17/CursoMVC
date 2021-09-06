using System;
using System.ComponentModel.DataAnnotations;

namespace WebAppMVC.Models
{
    public class Producto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es requerido")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "El precio es requerido")]
        public decimal Precio { get; set; }

        public bool Activo { get; set; }
        
        public DateTime FechaAlta { get; set; }
    }
}
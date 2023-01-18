using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Restaurant_Project.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public string Appetizer { get; set; }
        public string MainCourse { get; set; }
        public string Dessert { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}

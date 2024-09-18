using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apiVPP.Models
{
    public class StationeryItem
    {
        [Key]
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Fee { get; set; }
        public string ImageURL { get; set; }
    }
}

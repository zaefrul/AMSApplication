using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMSApplication.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Barcode { get; set; }
        public int Quantity { get; set; }
        public string Remarks { get; set; }
        public double CostPrice { get; set; }
        public string Status { get; set; }
        public string Category { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public string ModifiedBy { get; set; }

        //Foreign Key
        //Color
        public int ColorId { get; set; }
        //Navigation property
        public Color Color { get; set; }

        //Size
        public int SizeId { get; set; }
        //Navigation property
        public Size Size { get; set; }
    }
}
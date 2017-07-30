using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BMSApplication.Models
{
    public class Supplier
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Contact { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string Address { get; set; }
        public int Person { get; set; }
        public bool Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime Created { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime Modified { get; set; }
    }
}
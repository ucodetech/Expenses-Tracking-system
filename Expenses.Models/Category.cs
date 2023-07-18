using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expenses.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Column(TypeName="varchar(50)")]
        public string Name { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Category Icon")]
        [Column(TypeName = "nvarchar(100)")]
        public string? Icon { get; set; } = "";

        [Required]
        [MaxLength(100)]
        [Column(TypeName = "varchar(50)")] 
        public string Type { get; set; } = "Expense";

    }
}

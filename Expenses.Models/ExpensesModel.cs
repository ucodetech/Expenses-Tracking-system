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
    public class ExpensesModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Expense Name")]
        [MaxLength(100)]
        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Expense Description")]
        [MaxLength(200)]
        [Column(TypeName = "text")]
        public string Descriptions { get; set; }
        [Required]
        [DisplayName("Money Spent")]
        [MaxLength(100)]
        [Column(TypeName = "decimal(10,2)")]
        public decimal MoneySpent { get; set; }

        [Required]
        [DisplayName("Expense Date")]
        public DateTime ExpenseDate { get; set; }

        [Required]
        [MaxLength(200)]
        [Column(TypeName = "varchar(100)")]
        public string Category { get; set; }
    }
}

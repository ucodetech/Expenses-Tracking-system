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
    public class Transaction
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string? Descriptions { get; set; }
       
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Amount should be greater thatn 0")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Amount { get; set; }

        [Required]
        [DisplayName("Transaction Date")]
        public DateTime ExpenseDate { get; set; } = DateTime.Now;

      
       

    }
}

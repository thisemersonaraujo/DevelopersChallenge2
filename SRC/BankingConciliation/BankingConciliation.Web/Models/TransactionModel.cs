using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankingConciliation.Web.Models
{
    public class TransactionModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(30)]
        [MaxLength(30)]
        [Display(Name = "Tipo")]
        public string Type { get; set; }

        [Required]
        [Display(Name = "Valor")]
        public decimal Amount { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [Display(Name = "Data")]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(100)]
        [MaxLength(100)]
        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required]
        [StringLength(100)]
        [MaxLength(100)]
        [Display(Name = "Identificador")]
        public string Identifier { get; set; }
    }
}
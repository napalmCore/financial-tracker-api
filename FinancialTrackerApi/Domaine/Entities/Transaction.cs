using System.ComponentModel.DataAnnotations;

namespace Domaine.Entities
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int TransactionTypeId { get; set; }
        public TransactionType TransactionType { get; set; }
    }
}

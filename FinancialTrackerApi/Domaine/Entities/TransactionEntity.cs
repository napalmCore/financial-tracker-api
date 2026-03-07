using System.ComponentModel.DataAnnotations;

namespace Domaine.Entities
{
    public class TransactionEntity
    {
        [Key]
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public CategoryEntity Category { get; set; }
        public int TransactionTypeId { get; set; }
        public TransactionTypeEntity TransactionType { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace FinancialTrackerApi.Entities
{
    public class TransactionType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

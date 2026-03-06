using System.ComponentModel.DataAnnotations;

namespace Domaine.Entities
{
    public class TransactionType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

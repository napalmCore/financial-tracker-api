using System.ComponentModel.DataAnnotations;

namespace Domaine.Entities
{
    public class TransactionTypeEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}

using Domaine.Constants;
using System.ComponentModel.DataAnnotations;

namespace Domaine.Entities
{
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public int TransactionTypeId { get; set; } = TransactionTypes.Income;
    }
}

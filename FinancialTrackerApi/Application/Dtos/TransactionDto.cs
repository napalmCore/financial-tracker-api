namespace Application.Dtos
{
    public class TransactionDto
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }

        public static TransactionDto FromEntity(Domaine.Entities.TransactionEntity entity)
        {
            return new TransactionDto
            {
                Id = entity.Id,
                Amount = entity.Amount,
                Date = entity.Date,
                Description = entity.Description
            };
        }
    }
}

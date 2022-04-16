namespace NewsApp.RabbitMQ.Api.Models
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string IsActive { get; set; }
    }
}
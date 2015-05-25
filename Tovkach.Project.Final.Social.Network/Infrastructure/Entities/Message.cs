namespace Infrastructure.Entities
{
    public class Message : IEntity
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int From { get; set; }
        public int To { get; set; }
    }
}

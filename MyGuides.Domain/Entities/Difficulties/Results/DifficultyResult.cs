namespace MyGuides.Domain.Entities.Difficulties.Results
{
    public class DifficultyResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string ImageId { get; set; }
        public long Order { get; set; }
    }
}

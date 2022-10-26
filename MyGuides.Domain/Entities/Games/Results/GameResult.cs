namespace MyGuides.Domain.Entities.Games.Results
{
    public class GameResult
    {
        public Guid Id { get; set; }
        public string AppId { get; set; }
        public string Name { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}

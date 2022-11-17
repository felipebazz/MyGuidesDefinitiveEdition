namespace MyGuides.Domain.Entities.Games.Results
{
    public class GameResult
    {
        public Guid Id { get; set; }
        public string AppId { get; set; }
        public string Name { get; set; }
        public int Achievements { get; set; }
        public string ImportDate { get; set; }
        public string UpdateDate { get; set; }
    }
}

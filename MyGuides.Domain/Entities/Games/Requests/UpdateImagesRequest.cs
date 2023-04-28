namespace MyGuides.Domain.Entities.Games.Requests
{
    public class UpdateImagesRequest
    {
        public Guid GameId { get; set; }
        public string StoreId { get; set; }
    }
}

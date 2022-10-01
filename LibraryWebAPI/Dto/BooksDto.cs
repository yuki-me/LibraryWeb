namespace LibraryWebAPI.Dto
{
    public class BooksDto
    {
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public int Quantity { get; set; }
    }
}

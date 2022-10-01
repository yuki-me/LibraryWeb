namespace LibraryWebAPI.Model
{
    public class Books
    {
        public string Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public int Quantity { get; set; }
        public ICollection<IssueBook> IssueBooks { get; set; }
        public ICollection<ReturnBook> ReturnBook { get; set; }
    }
}

namespace LibraryWebAPI.Model
{
    public class Status
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public ICollection<IssueBook> IssueBooks { get; set; }
    }
}

namespace LibraryWebAPI.Dto
{
    public class IssueBookDto
    {
        public string Id { get; set; }
        public string StuId { get; set; }
        public string BookId { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public DateTime IssueDate { get; set; }
        public string StatusId { get; set; }
    }
}

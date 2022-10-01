namespace LibraryWebAPI.Model
{
    public class IssueBook
    {
        public string Id { get;set; }
        public string StuId { get;set; }
        public string BookId { get;set; }
        public string UserId { get;set; }
        public int Quantity { get;set; }
        public DateTime IssueDate { get; set; }
        public string StatusId { get; set; }
        public Students Students { get; set; }
        public Books Books { get; set; }
        public Users Users { get; set; }
        public Status Status { get; set; }
    }
}

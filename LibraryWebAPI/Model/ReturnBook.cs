namespace LibraryWebAPI.Model
{
    public class ReturnBook
    {
        public string Id { get; set; }
        public string StuId { get; set; }
        public string BookId { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public DateTime ReturnDate { get; set; }
        public Students Students { get; set; }
        public Books Books { get; set; }
        public Users Users { get; set; }
    }
}

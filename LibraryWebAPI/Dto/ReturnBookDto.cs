namespace LibraryWebAPI.Dto
{
    public class ReturnBookDto
    {
        public string Id { get; set; }
        public string StuId { get; set; }
        public string BookId { get; set; }
        public string UserId { get; set; }
        public int Quantity { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}

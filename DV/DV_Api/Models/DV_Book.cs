namespace DV_Api.Models
{
    public class DV_Book
    {
        public int DV_BookId { get; set; }
        public string? DV_Title { get; set; }
        public int DV_AuthorId { get; set; }
        public DV_Author? DV_Author { get; set; }
    }
}

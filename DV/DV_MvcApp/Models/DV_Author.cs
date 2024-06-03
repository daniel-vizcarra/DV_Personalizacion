namespace DV_MvcApp.Models
{
    public class DV_Author
    {
        public int DV_AuthorId { get; set; }
        public string? DV_FirstName { get; set; }
        public string? DV_LastName { get; set; }
        public ICollection<DV_Book>? DV_Books { get; set; }
    }
}



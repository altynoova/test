using System.ComponentModel.DataAnnotations;

namespace test
{
    public class Book
    {
        [Key]
        public int IdBook { get; set; }
        public string? BookName { get; set; } 
        public string? AuthorName { get; set; }
        public DateTime PublishDate { get; set; }
        public int AmountOfPages { get; set; }
        public float Ratings { get; set; }

    }
}
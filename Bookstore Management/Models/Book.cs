using System.ComponentModel.DataAnnotations;

namespace Bookstore_Management.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Title { get; set; }
        [Required, StringLength(150)]
        public string Author { get; set; }
        [Required, StringLength(100)]
        public string Genre { get; set; }
        [Required,Range(1,100)]
        public double Price { get; set; }
    
    }
}

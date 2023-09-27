using System.ComponentModel.DataAnnotations;

namespace MVCGoogleAuth.Models
{
    public class News
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateModified { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public string Author { get; set; }
    }
}

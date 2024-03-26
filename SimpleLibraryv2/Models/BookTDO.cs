using System.ComponentModel.DataAnnotations;

namespace SimpleLibraryv2.Models
{
    public record BookDTO
    {
        public string Title { get; set; }
        public string Author { get; set; }
        [Range(1900,2024,ErrorMessage = "Write proper date of release.")]
        public int Year { get; set; }
    }
}

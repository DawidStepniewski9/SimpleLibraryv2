using System.ComponentModel.DataAnnotations;

namespace SimpleLibraryv2.Models
{
    public record BookModelPut
    {
        public string Title { get; set; }
        public string Author { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace SimpleLibraryv2.Models
{
    public class Book
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }

        public void ApplyPatch(JsonPatchDocument<Book> patch)
        {
            if (patch == null || patch.Operations == null)
                return;

            patch.ApplyTo(this);
        }

    }
}

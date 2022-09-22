using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter the title of your book")]
        public string Title { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter the author name")]
        public string Author { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(100, MinimumLength = 5)]
        public string Category { get; set; }

        [Display(Name = "Total pages")]
        [Required(ErrorMessage = "Please enter the total pages")]
        public int? TotalPages { get; set; }

        [Display(Name = "Language")]
        [Required(ErrorMessage = "Please choose the language")]
        public int LanguageId { get; set; }

        public string Language { get; set; }

        [Display(Name = "Cover photo")]
        [Required]
        public IFormFile CoverPhoto { get; set; }

        public string CoverImageUrl { get; set; }

        [Display(Name = "Images")]
        [Required]
        public IFormFileCollection GalleryFiles { get; set; }

        public List<GalleryModel> Gallery { get; set; }

        [Display(Name = "Pdf")]
        [Required]
        public IFormFile BookPdf { get; set; }

        public string BookPdfUrl { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace IoT.Capstone.KeyGen.Client.Models
{
    public class RegisterViewModel
    {
        [MinLength(5)]
        [MaxLength(1024)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "You must supply an ID.")]
        [RegularExpression(@"^\S+$", ErrorMessage = "The ID must be characters and numerals without any spaces.")]
        [Display(Description = "Enter the edX ID", Name="Enter edX ID")]
        public string EdxId { get; set; }
    }
}
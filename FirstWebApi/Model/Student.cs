using FirstWebApi.Validator;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace FirstWebApi.Model
{
    public class Student
    {
        [ValidateNever]
        public int Id { get; set; }

        [StringLength(20 , ErrorMessage = "Name should be less than 20 characters.")]
        public string Name { get; set; }

        [Range(12 , 20)]
        [AgeValidator(ErrorMessage = "Age is not valid")]
        public int Age { get; set; }    

        [StringLength(10 , ErrorMessage = "Incorrect Phone Number.")]
        public string PhoneNo { get; set; }

        [Required]
        public string? Password {  get; set; }

        [Compare(nameof(Password))]
        public string ConfirmPassword {  get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VisionRT_WebApp.Models
{
    public class PatientModel
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Display(Name = "Date of birth")]
        [Required(ErrorMessage = "DOB is required.")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Gender is required")]
        [EnumDataType(typeof(GenderList))]
        public string Gender { get; set; }
    }

    public enum GenderList
    {
        Female = 0,
        Male = 1
    }
}
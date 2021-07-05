using System;
using System.ComponentModel.DataAnnotations;

namespace ZavenDotNetInterview.App.ViewModels.Jobs
{
    public class CreateViewModel
    {
        [Required(ErrorMessage = "Name is required", AllowEmptyStrings = false)]
        public string Name { get; set; }
        
        [DataType(DataType.DateTime)]
        public DateTime DoAfter { get; set; }
    }
}
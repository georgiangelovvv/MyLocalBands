using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MyLocalBands.CustomValidation
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int maxSizeInMegabytes;

        public MaxFileSizeAttribute(int maxSizeInMegabytes)
        {
            this.maxSizeInMegabytes = maxSizeInMegabytes;
            this.ErrorMessage = $"Maximum allowed file size is {this.maxSizeInMegabytes} MB.";
        }
        public override bool IsValid(object value)
        {
            if (value is IFormFile file)
            {
                if (file.Length < this.maxSizeInMegabytes * 1024 * 1024)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

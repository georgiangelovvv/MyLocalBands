using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace MyLocalBands.CustomValidation
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly int maxSizeInMegabytes;
        private readonly bool skipIfValueIsNull;

        public MaxFileSizeAttribute(int maxSizeInMegabytes, bool skipIfValueIsNull = false)
        {
            this.skipIfValueIsNull = skipIfValueIsNull;
            this.maxSizeInMegabytes = maxSizeInMegabytes;
            this.ErrorMessage = $"Maximum allowed file size is {this.maxSizeInMegabytes} MB.";
        }
        public override bool IsValid(object value)
        {
            if (this.skipIfValueIsNull && value == null)
            {
                return true;
            }

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

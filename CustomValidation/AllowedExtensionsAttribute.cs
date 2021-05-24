using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyLocalBands.CustomValidation
{
    public class AllowedExtensionsAttribute : ValidationAttribute, IClientModelValidator
    {
        private readonly string[] extensions;

        public AllowedExtensionsAttribute(string[] extensions)
        {
            this.extensions = extensions;
            this.ErrorMessage = $"Only \"{string.Join(", ", this.extensions.Select(x => x.ToUpper()))}\" files are allowed.";
        }

        public override bool IsValid(object value)
        {
            if (value is IFormFile fileValue)
            {
                var extension = Path.GetExtension(fileValue.FileName);

                if (this.extensions.Contains(extension.ToLower()))
                {
                    return true;
                }
            }

            return false;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("accept", string.Join(", ", this.extensions));
        }
    }
}

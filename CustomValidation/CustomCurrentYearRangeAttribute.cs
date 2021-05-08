using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyLocalBands.CustomValidation
{
    public class CustomCurrentYearRangeAttribute : ValidationAttribute, IClientModelValidator
    {
        public CustomCurrentYearRangeAttribute(int minYear)
        {
            this.MinYear = minYear;
            this.MaxYear = DateTime.UtcNow.Year;
        }

        public int MinYear { get; }

        public int MaxYear { get; }

        public override bool IsValid(object value)
        {
            if (value is int intValue)
            {
                if (intValue >= this.MinYear && intValue <= this.MaxYear)
                {
                    return true;
                }
            }

            return false;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-range", $"The field {context.ModelMetadata.Name} must be between {this.MinYear} and {this.MaxYear}.");
            context.Attributes.Add("data-val-range-max", this.MaxYear.ToString());
            context.Attributes.Add("data-val-range-min", this.MinYear.ToString());
        }
    }
}

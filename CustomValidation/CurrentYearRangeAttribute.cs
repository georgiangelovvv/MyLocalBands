using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyLocalBands.CustomValidation
{
    public class CurrentYearRangeAttribute : ValidationAttribute, IClientModelValidator
    {
        public CurrentYearRangeAttribute(int minYear)
        {
            this.MinYear = minYear;
            this.MaxYear = DateTime.UtcNow.Year;
            this.ErrorMessage = $"Year must be between {this.MinYear} and {this.MaxYear}.";
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
            context.Attributes.Add("data-val-range", this.ErrorMessage != null ?
                                                     this.ErrorMessage :
                                                     $"The field {context.ModelMetadata.Name} must be between {this.MinYear} and {this.MaxYear}.");
            context.Attributes.Add("data-val-range-max", this.MaxYear.ToString());
            context.Attributes.Add("data-val-range-min", this.MinYear.ToString());
        }
    }
}

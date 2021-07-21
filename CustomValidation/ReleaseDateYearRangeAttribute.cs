using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyLocalBands.CustomValidation
{
    public class ReleaseDateYearRangeAttribute : ValidationAttribute
    {
        public ReleaseDateYearRangeAttribute(int minYear, int yearsAfterCurrentYear)
        {
            this.MinYear = minYear;
            this.MaxYear = DateTime.UtcNow.Year + yearsAfterCurrentYear;
            this.ErrorMessage = $"Year must be between {this.MinYear} and {this.MaxYear}.";
        }

        public int MinYear { get; }

        public int MaxYear { get; }

        public override bool IsValid(object value)
        {
            if (value is DateTime date)
            {
                if (date.Year >= this.MinYear && date.Year <= this.MaxYear)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

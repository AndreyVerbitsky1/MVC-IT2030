﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace EnrollmentApplication.Models
{
    public class InvalidCharsAttribute : ValidationAttribute
    {
        readonly string invalidChars;

        public InvalidCharsAttribute(string invalidChars) : base("Notes contains unacceptable characters!")
        {
            this.invalidChars = invalidChars;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var valueAsString = value.ToString();
                if (valueAsString.Contains(invalidChars))
                {
                    var errormessage = FormatErrorMessage(validationContext.DisplayName);

                    return new ValidationResult(errormessage);
                }
            }

            return ValidationResult.Success;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using KPOCOS.Domain.Errors;
using Newtonsoft.Json;

namespace KPCOS.Api.Untils
{
    public class ErrorUtil
    {
        public static string GetErrorString(string fieldName, string errorStr)
        {
            List<ErrorDetail> errors = new List<ErrorDetail>();

            ErrorDetail errorDetail = new ErrorDetail()
            {
                FieldNameError = fieldName,
                DescriptionError = errorStr
            };

            errors.Add(errorDetail);

            return JsonConvert.SerializeObject(errors);
        }

        public static string GetErrorString(List<ErrorDetail> errorDetails)
        {
            return JsonConvert.SerializeObject(errorDetails);
        }

        public static string GetErrorString(List<string> errorStr)
        {
            List<ErrorDetail> errors = new List<ErrorDetail>();

            foreach (var error in errorStr)
            {
                ErrorDetail errorDetail = new ErrorDetail()
                {
                    FieldNameError = "Exception",
                    DescriptionError = error
                };

                errors.Add(errorDetail);
            }

            return JsonConvert.SerializeObject(errors);
        }

        public static string GetErrorsString(ValidationResult validationResult)
        {
            List<ErrorDetail> errors = new List<ErrorDetail>();
            foreach (var error in validationResult.Errors)
            {
                ErrorDetail errorDetail = errors.FirstOrDefault(x => x.FieldNameError.Equals(error.PropertyName));
                if (errorDetail == null)
                {
                    ErrorDetail newErrorDetail = new ErrorDetail()
                    {
                        FieldNameError = error.PropertyName,
                        DescriptionError = error.ErrorMessage
                    };

                    errors.Add(newErrorDetail);
                }
                else
                {
                    // If you want to keep only the first error message for each field
                    // Do nothing here, as we've already added the first error
                }
            }

            var message = JsonConvert.SerializeObject(errors);
            return message;
        }

        public static List<string> GetErrorsOnObject(ValidationResult validationResult)
        {
            List<string> errors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(error.ErrorMessage);
            }

            return errors;
        }
    }
}
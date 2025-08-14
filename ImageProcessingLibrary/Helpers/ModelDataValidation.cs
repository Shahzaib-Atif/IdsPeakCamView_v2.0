using System.ComponentModel.DataAnnotations;

namespace ImageProcessingLibrary.Helpers
{
    public class ModelDataValidation
    {
        public static bool Validate(Object model)
        {
            string errorMessage = "";
            var errors = new List<ValidationResult>();
            ValidationContext context = new(model);
            bool isValid = Validator.TryValidateObject(model, context, errors, true);
            if (!isValid)
            {
                foreach (var item in errors)
                    errorMessage += "- " + item.ErrorMessage + "\n";
                ExceptionHelper.DisplayErrorMessage(errorMessage);
            }
            return isValid;
        }
    }
}

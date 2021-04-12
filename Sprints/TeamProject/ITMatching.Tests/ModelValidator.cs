using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ITMatching.Tests
{
    public class ModelValidator
    {
        public List<ValidationResult> Validations { get; private set; }
        public bool Valid { get; private set; } = false;

        public ModelValidator(object model)
        {
            Validations = new List<ValidationResult>();
            ValidationContext vctx = new ValidationContext(model);
            Valid = Validator.TryValidateObject(model, vctx, Validations, true);
        }


        public bool ContainsFailureFor(string member) =>
            Validations.Select(vr => vr.MemberNames).Select(member => member.Where(term => member.Equals(term))).Any();

        
        // Get all errors in a single string
        public string GetAllErrors() =>
            Validations.Aggregate("", (accumulator, validation) => accumulator + $",{validation.ErrorMessage}");


    }
}

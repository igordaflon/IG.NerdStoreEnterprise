using System.ComponentModel.DataAnnotations;

namespace NSE.Core.Messages.Integration
{
    public class ReponseMessage : Message
    {
        public ValidationResult ValidationResult { get; set; }

        public ReponseMessage(ValidationResult validationResult)
        {
            ValidationResult = validationResult;
        }
    }
}

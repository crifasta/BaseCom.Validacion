
using System.Collections.Generic;
using System.Text;

namespace BaseCom.Validacion
{
    public class ValidationUtils
    {
        /// <summary>
        /// Check the parameter isValidCondition for validation condition.
        /// If it is not valid, adds the errmessage to the list of errors.
        /// </summary>
        /// <param name="isValidCondition"></param>
        /// <param name="errors"></param>
        /// <param name="errMessage"></param>
        public static bool Validate(bool isError, IList<string> errors, string message)
        {
            if (isError) { errors.Add(message); }
            return !isError;
        }


        /// <summary>
        /// Validates the bool condition and adds the string error
        /// to the error list if the condition is invalid.
        /// </summary>
        /// <param name="isValid">Flag indicating if invalid.</param>
        /// <param name="error">Error message</param>
        /// <param name="results"><see cref="ValidationResults"/></param>
        /// <returns>True if isError is false, indicating no error.</returns>
        public static bool Validate(bool isError, IStatusResults results, string key, string message, object target)
        {
            if (isError)
            {
                results.Add(key, message, target);
            }
            return !isError;
        }



        /// <summary>
        /// Validates the bool condition and adds the string error
        /// to the error list if the condition is invalid.
        /// </summary>
        /// <param name="isValid">Flag indicating if invalid.</param>
        /// <param name="error">Error message</param>
        /// <param name="results"><see cref="ValidationResults"/></param>
        /// <returns>True if isError is false, indicating no error.</returns>
        public static bool Validate(bool isError, IStatusResults results, string message)
        {
            if (isError)
            {
                results.Add(string.Empty, message, null);
            }
            return !isError;
        }


        /// <summary>
        /// Transfers all the messages from the source to the validation results.
        /// </summary>
        /// <param name="messages"></param>
        /// <param name="results"></param>
        public static void TransferMessages(IList<string> messages, IStatusResults results)
        {
            foreach (string message in messages)
            {
                results.Add(string.Empty, message, null);
            }
        }


        /// <summary>
        ///Valdiates todas las reglas de validación en la lista.
        /// </summary>
        /// <param name="validationRules">List of validation rules to validate</param>
        /// <param name="validationErrors">List of validation results to populate.
        /// This list is populated with the errors from the validation rules.</param>
        /// <returns>True if all rules passed, false otherwise.</returns>
        public static bool Validate(IList<IValidator> validators, IValidationResults destinationResults)
        {
            if (validators == null || validators.Count == 0)
                return true;
            // Get the the initial error count;		
            int initialErrorCount = destinationResults.Count;
            // Iterate through all the validation rules and validate them.
            foreach (IValidator validator in validators)
            {
                validator.Validate(destinationResults);
            }
            // Determine validity if errors were added to collection.
            return initialErrorCount == destinationResults.Count;
        }


        /// <summary>
        /// Valida la regla y devuelve un boolMessage
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public static BoolMessage Validate(IValidator validator)
        {
            IValidationResults results = validator.Validate() as IValidationResults;
            // Empty message if Successful.
            if (results.IsValid) return new BoolMessage(true, string.Empty);

            // Error            
            string multiLineError = BuildSingleErrorMessage(results, System.Environment.NewLine);
            return new BoolMessage(false, multiLineError);
        }


        /// <summary>
        /// Valida la regla y devuelve un boolMessage
        /// </summary>
        /// <param name="rule"></param>
        /// <returns></returns>
        public static bool ValidateAndCollect(IValidator validator, IValidationResults results)
        {
            IValidationResults validationResults = validator.Validate(results);
            return validationResults.IsValid;
        }


        /// <summary>
        /// Construye un único mensaje de error de una lista de resultados de la acción 
        /// </summary>
        /// <param name="actionResults"></param>
        /// <param name="onlyBuildFromErrors"></param>
        /// <param name="resultSeparator"></param>
        /// <returns></returns>
        public static string BuildSingleErrorMessage(IStatusResults results, string resultSeparator)
        {
            StringBuilder buffer = new StringBuilder();

            foreach (IStatusResult entry in results)
            {
                buffer.Append(entry.ToString() + resultSeparator);
            }
            return buffer.ToString();
        }
    }
}

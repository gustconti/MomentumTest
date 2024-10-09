using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace MomentumTest.Validations
{
    [DebuggerDisplay($"{{{nameof(GetDebuggerDisplay)}(),nq}}")]
    public partial class CpfCnpjAttribute : ValidationAttribute
    {
        public CpfCnpjAttribute() { }

        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("CPF/CNPJ é obrigatório.");
            }

            var input = value as string;

            if (string.IsNullOrEmpty(input))
            {
                return new ValidationResult("CPF/CNPJ é obrigatório.");
            }

            // Determine whether to validate as CPF or CNPJ
            if (input.Length == 11) // CPF
            {
                if (!IsValidCpf(input))
                {
                    return new ValidationResult("Formato de CPF Inválido.");
                }
            }
            else if (input.Length == 14) // CNPJ
            {
                if (!IsValidCnpj(input))
                {
                    return new ValidationResult("Formato de CNPJ inválido.");
                }
            }
            else
            {
                return new ValidationResult("Número de caracteres invalido para CPF/CNPJ.");
            }

            return ValidationResult.Success;
        }

        private static bool IsValidCpf(string cpf)
        {
            // Implement the CPF validation logic
            int[] digits = cpf.Select(c => c - '0').ToArray();

            // Calculate first check digit
            int sum1 = 0;
            for (int i = 0; i < 9; i++)
            {
                sum1 += digits[i] * (10 - i);
            }
            int checkDigit1 = 11 - (sum1 % 11);
            checkDigit1 = checkDigit1 >= 10 ? 0 : checkDigit1;

            // Calculate second check digit
            int sum2 = 0;
            for (int i = 0; i < 10; i++)
            {
                sum2 += digits[i] * (11 - i);
            }
            int checkDigit2 = 11 - (sum2 % 11);
            checkDigit2 = checkDigit2 >= 10 ? 0 : checkDigit2;

            return digits[9] == checkDigit1 && digits[10] == checkDigit2;
        }

        private static bool IsValidCnpj(string cnpj)
        {
            // Remove any non-numeric characters
            cnpj = cnpj.Replace(".", "").Replace("/", "").Replace("-", "").Trim();

            // Length check
            if (cnpj.Length != 14)
            {
                return false; // Invalid length
            }

            // Check for repeated digits
            if (new string(cnpj[0], 14) == cnpj)
            {
                return false; // Invalid CNPJ
            }

            // Calculate the first check digit
            int[] firstWeight = { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int sum = 0;
            for (int i = 0; i < 12; i++)
            {
                sum += (cnpj[i] - '0') * firstWeight[i];
            }
            int firstCheckDigit = (sum % 11 < 2) ? 0 : 11 - (sum % 11);

            // Calculate the second check digit
            int[] secondWeight = { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            sum = 0;
            for (int i = 0; i < 13; i++)
            {
                sum += (cnpj[i] - '0') * secondWeight[i];
            }
            int secondCheckDigit = (sum % 11 < 2) ? 0 : 11 - (sum % 11);

            // Compare the calculated check digits with the actual check digits
            return (cnpj[12] - '0' == firstCheckDigit) && (cnpj[13] - '0' == secondCheckDigit);
        }

        private string GetDebuggerDisplay()
        {
            return $"CPF/CNPJ Attribute: {ErrorMessage}";
        }
    }
}
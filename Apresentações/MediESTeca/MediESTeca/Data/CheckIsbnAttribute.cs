using System.ComponentModel.DataAnnotations;

namespace MediESTeca.Data
{
    public class CheckIsbnAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            string Isbn = value as string;
            if (string.IsNullOrWhiteSpace(Isbn))
                return false;

            if (Isbn.Length != 10)
                return false;

            int sum = 0;
            for(int i = 0; i < Isbn.Length-1; i++)
            {
                int digit = Isbn[i] - '0';
                if(digit < 0 || digit > 9)
                    return false;
                sum += (digit * (10 - i));               
            }

            // Checking last digit.
            char last = Isbn[9];
            if (last != 'X' && (last < '0' || last > '9'))
                return false;

            // If last digit is 'X', add 10
            // to sum, else add its value.
            sum += ((last == 'X') ? 10 : (last - '0'));

            // Return true if weighted sum
            // of digits is divisible by 11.
            return (sum % 11 == 0);           
        }
    }
}

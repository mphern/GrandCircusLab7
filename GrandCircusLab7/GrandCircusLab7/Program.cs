using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;


namespace GrandCircusLab7
{
    class Program
    {
        static void Main()
        {

            //Section that validates that name
            Console.Write("Please enter a valid Name: ");
            string name = Console.ReadLine();
            ValidateName(ref name);
            Console.WriteLine("Name is Valid!");
            Console.WriteLine("\n");

            //Section that validates the email address
            Console.Write("Please enter a valid email: ");
            string email = Console.ReadLine();
            ValidateEmail(ref email);
            Console.WriteLine("Email is valid!");
            Console.WriteLine("\n");


            //Section that validates the phone number
            Console.Write("Please enter a valid phone number: ");
            string phoneNumber = Console.ReadLine();
            ValidatePhoneNumber(ref phoneNumber);
            Console.WriteLine("Phone Number is valid!");
            Console.WriteLine("\n");


            //Section that validates the date
            Console.Write("Please enter a valid Date (dd/mm/yyyy): ");
            string date = Console.ReadLine();
            ValidateDate(ref date);
            Console.WriteLine("Date is valid!");

            Console.ReadKey();
        }

        public static bool ValidateName(ref string name)
        {
            string pattern = @"(^[A-Z])([a-z]){0,29}$";
            bool isMatch = Regex.IsMatch(name.Trim(), pattern);
            
            while (isMatch == false)
            {
                Console.Write("Sorry, name is not valid! Please enter valid Name: ");
                name = Console.ReadLine();
                isMatch = ValidateName(ref name);
            }
            return true;
        }

        public static bool ValidateEmail(ref string email)
        {
            string pattern = @"^\w{5,30}@\w{5,10}\.\w{2,3}$";
            bool isMatch = Regex.IsMatch(email.Trim(), pattern);
            while (isMatch == false)
            {
                Console.Write("Sorry, email is not valid! Please enter valid email: ");
                email = Console.ReadLine();
                isMatch = ValidateEmail(ref email);
            }

            return true;
        }
        public static bool ValidatePhoneNumber(ref string phoneNumber)
        {
            string pattern = @"^[1-9]\d{2}-\d{3}-\d{4}$";
            bool isMatch = Regex.IsMatch(phoneNumber, pattern);

            while (isMatch == false)
            {
                Console.Write("Sorry, phone number is not valid! Please enter valid phone number: ");
                phoneNumber = Console.ReadLine();
                isMatch = ValidatePhoneNumber(ref phoneNumber);
            }

            return true;
        }

        //Method to prevent using future year.  Method is not called in this particular program as it allows future dates.
        public static void ValidateYear(ref string date)
        {
            int year;
            while (!int.TryParse(date.Substring(date.Length - 4), out year) || year > 2018)
            {
                Console.Write("Sorry, date is not valid! Please enter valid date: ");
                date = Console.ReadLine();
            }
            
        }


        public static bool ValidateDate(ref string date)
        {
            bool validDate = false;
            /*I made 3 patterns for every month (except Feb, I made 2) that tests for patterns based on 
            * if the first digit of the day is 0, 1, 2, or 3.*/
            string patternJan1 = @"[0][1-9]/[0][1]/\d{4}";
            string patternJan2 = @"[1-2][0-9]/[0][1]/\d{4}";
            string patternJan3 = @"[3][0-1]/[0][1]/\d{4}";
            string patternFeb1 = @"[0][1-9]/[0][2]/\d{4}";
            string patternFeb2 = @"[1-2][0-9]/[0][2]/\d{4}";
            string patternMar1 = @"[0][1-9]/[0][3]/\d{4}";
            string patternMar2 = @"[1-2][0-9]/[0][3]/\d{4}";
            string patternMar3 = @"[3][0-1]/[0][3]/\d{4}";
            string patternApr1 = @"[0][1-9]/[0][4]/\d{4}";
            string patternApr2 = @"[1-2][0-9]/[0][4]/\d{4}";
            string patternApr3 = @"[3][0]/[0][4]/\d{4}";
            string patternMay1 = @"[0][1-9]/[0][5]/\d{4}";
            string patternMay2 = @"[1-2][0-9]/[0][5]/\d{4}";
            string patternMay3 = @"[3][0-1]/[0][5]/\d{4}";
            string patternJun1 = @"[0][1-9]/[0][6]/\d{4}";
            string patternJun2 = @"[1-2][0-9]/[0][6]/\d{4}";
            string patternJun3 = @"[3][0]/[0][6]/\d{4}";
            string patternJul1 = @"[0][1-9]/[0][7]/\d{4}";
            string patternJul2 = @"[1-2][0-9]/[0][7]/\d{4}";
            string patternJul3 = @"[3][0-1]/[0][7]/\d{4}";
            string patternAug1 = @"[0][1-9]/[0][8]/\d{4}";
            string patternAug2 = @"[1-2][0-9]/[0][8]/\d{4}";
            string patternAug3 = @"[3][0-1]/[0][8]/\d{4}";
            string patternSep1 = @"[0][1-9]/[0][9]/\d{4}";
            string patternSep2 = @"[1-2][0-9]/[0][9]/\d{4}";
            string patternSep3 = @"[3][0]/[0][9]/\d{4}";
            string patternOct1 = @"[0][1-9]/[1][0]/\d{4}";
            string patternOct2 = @"[1-2][0-9]/[1][0]/\d{4}";
            string patternOct3 = @"[3][0-1]/[1][0]/\d{4}";
            string patternNov1 = @"[0][1-9]/[1][1]/\d{4}";
            string patternNov2 = @"[1-2][0-9]/[1][1]/\d{4}";
            string patternNov3 = @"[3][0]/[1][1]/\d{4}";
            string patternDec1 = @"[0][1-9]/[1][2]/\d{4}";
            string patternDec2 = @"[1-2][0-9]/[1][2]/\d{4}";
            string patternDec3 = @"[3][0-1]/[1][2]/\d{4}";
            if (CheckLeapYear(date) == true)  /*Calls CheckLeapYear method to make sure date is valid for non-leap years.
                                                 If not, method will skip down to while loop to ask the user for a new date*/
            {
                if (Regex.IsMatch(date, patternJan1))
                    return true;
                if (Regex.IsMatch(date, patternJan2))
                    return true;
                if (Regex.IsMatch(date, patternJan3))
                    return true;
                if (Regex.IsMatch(date, patternFeb1))
                    return true;
                if (Regex.IsMatch(date, patternFeb2))
                    return true;
                if (Regex.IsMatch(date, patternMar1))
                    return true;
                if (Regex.IsMatch(date, patternMar2))
                    return true;
                if (Regex.IsMatch(date, patternMar3))
                    return true;
                if (Regex.IsMatch(date, patternApr1))
                    return true;
                if (Regex.IsMatch(date, patternApr2))
                    return true;
                if (Regex.IsMatch(date, patternApr3))
                    return true;
                if (Regex.IsMatch(date, patternMay1))
                    return true;
                if (Regex.IsMatch(date, patternMay2))
                    return true;
                if (Regex.IsMatch(date, patternMay3))
                    return true;
                if (Regex.IsMatch(date, patternJun1))
                    return true;
                if (Regex.IsMatch(date, patternJun2))
                    return true;
                if (Regex.IsMatch(date, patternJun3))
                    return true;
                if (Regex.IsMatch(date, patternJul1))
                    return true;
                if (Regex.IsMatch(date, patternJul2))
                    return true;
                if (Regex.IsMatch(date, patternJul3))
                    return true;
                if (Regex.IsMatch(date, patternAug1))
                    return true;
                if (Regex.IsMatch(date, patternAug2))
                    return true;
                if (Regex.IsMatch(date, patternAug3))
                    return true;
                if (Regex.IsMatch(date, patternSep1))
                    return true;
                if (Regex.IsMatch(date, patternSep2))
                    return true;
                if (Regex.IsMatch(date, patternSep3))
                    return true;
                if (Regex.IsMatch(date, patternOct1))
                    return true;
                if (Regex.IsMatch(date, patternOct2))
                    return true;
                if (Regex.IsMatch(date, patternOct3))
                    return true;
                if (Regex.IsMatch(date, patternNov1))
                    return true;
                if (Regex.IsMatch(date, patternNov2))
                    return true;
                if (Regex.IsMatch(date, patternNov3))
                    return true;
                if (Regex.IsMatch(date, patternDec1))
                    return true;
                if (Regex.IsMatch(date, patternDec2))
                    return true;
                if (Regex.IsMatch(date, patternDec3))
                    return true;
            }
            while (validDate == false)
            {
                Console.Write("Sorry, date is not valid! Please enter valid date (dd/mm/yyyy): ");
                date = Console.ReadLine();
                validDate = ValidateDate(ref date);
            }

            return true;
        }
        public static bool CheckLeapYear(string date)
        {
            int day = int.Parse(date.Substring(0, 2)); 
            int month = int.Parse(date.Substring(3, 2));
            int year = int.Parse(date.Substring(date.Length - 4));
            bool leapYear = false;
            if (year % 4 == 0)
            { leapYear = true; }
            if (year % 100 == 0)
            { leapYear = false; }
            if (year % 400 == 0)
            { leapYear = true; }
            if(leapYear == false && month == 2 && day > 28)
            { return false; }
            return true;
            
        }
    }
}

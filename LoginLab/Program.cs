using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoginLab
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> userData = new List<string>();
            bool run = true;
            while (run == true)
            {
                Console.WriteLine("Please enter email address:");
                string userEmail = EmailValidation();
                Console.WriteLine("Please enter password:");
                string userPassword = PasswordValidation();
                userData.Add(userEmail);
                userData.Add(userPassword);
                //foreach(string data in userData)
                //{
                    //Console.WriteLine(data);
                //}
                run = Continue();
            }
        }

        public static string EmailValidation()
        {
            string run;
            var userEmail = Console.ReadLine();
            try
            {
                if (Regex.IsMatch(userEmail, @"[A-z0-9]{3,30}@[a-z]{3,30}.[a-z]{2,3}"))
                {
                    Console.WriteLine("This is a valid email address");
                }
                else
                {
                    Console.WriteLine("That is not a valid email address. Please try again:");
                    run = EmailValidation();
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("This is a Format Exception");
            }
            return userEmail;
        }
        public static string PasswordValidation()
        {
            string run;
            var userPassword = Console.ReadLine();
            try
            {
                if (Regex.IsMatch(userPassword, @"(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{5,}$"))
                {
                    Console.WriteLine("This is a valid password");
                }
                else
                {
                    Console.WriteLine("That is not a valid password. Please try again:");
                    run = PasswordValidation();
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("This is a format exception");
            }
            return userPassword;
        }

        public static bool Continue()
        {
            bool run;
            Console.WriteLine("Would you like to add another user? (y/n)");
            string userContinue = Console.ReadLine().ToLower();

            if(userContinue == "y")
            {
                run = true;
            }
            else if (userContinue == "n")
            {
                run = false;
            }
            else
            {
                Console.WriteLine("That input is not valid");
                run = Continue();
            }
            return run;
        }
    }
}

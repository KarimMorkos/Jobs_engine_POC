using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CV.DataSource
{
    public class DataGeneration
    {


        public static ArrayList DataGeneration_YourVerCard()
        {
            var RandomChar = new Random();
            var RandomNum = new Random();

            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            var Num = "1234567890";
        

            //////First Page
            var FirstName ="A"+ new string(Enumerable.Repeat(chars, 17).Select(s => s[RandomChar.Next(s.Length)]).ToArray());
            var MiddleName ="B";
            var LastName ="C"+ new string(Enumerable.Repeat(chars, 24).Select(s => s[RandomChar.Next(s.Length)]).ToArray());
            var Address = new string(Enumerable.Repeat(chars, 24).Select(s => s[RandomChar.Next(s.Length)]).ToArray());
            var Apt = new string(Enumerable.Repeat(chars, 24).Select(s => s[RandomChar.Next(s.Length)]).ToArray());
            var City = new string(Enumerable.Repeat(chars, 18).Select(s => s[RandomChar.Next(s.Length)]).ToArray());
            var ZipCode = new string(Enumerable.Repeat(Num,5).Select(s => s[RandomChar.Next(s.Length)]).ToArray());
            var Email = new string(Enumerable.Repeat(chars, 3).Select(s => s[RandomChar.Next(s.Length)]).ToArray()) +"@hotmail.com";
            var PhoneNum = new string(Enumerable.Repeat(Num, 10).Select(s => s[RandomChar.Next(s.Length)]).ToArray());
            var SeconPhoneNum = new string(Enumerable.Repeat(Num, 10).Select(s => s[RandomChar.Next(s.Length)]).ToArray());
            //////////////////////////////////////////////////////////////////
            //Second Page

            int Years = (int)DateTime.Now.Year-(RandomNum.Next(10000,15000));
            var BD= (DateTime.Now.AddDays(Years)).ToString("MM/dd/yyyy");



            var GMI = RandomNum.Next(1000, 1990);



            /////third page
            var Intial = (string)FirstName.Substring(0, 1) + (string)MiddleName.Substring(0, 1) + (string)LastName.Substring(0, 1);

            ArrayList Result = new ArrayList();

            Result.Add(FirstName);
            Result.Add(MiddleName);
            Result.Add(LastName);
            Result.Add(Address);
            Result.Add(Apt);
            Result.Add(City);
            Result.Add(ZipCode);
            Result.Add(Email);
            Result.Add(PhoneNum);
            Result.Add(SeconPhoneNum);
            Result.Add(BD);
            Result.Add(GMI);
            Result.Add(Intial);
            return Result;
        }



       
    }
    }


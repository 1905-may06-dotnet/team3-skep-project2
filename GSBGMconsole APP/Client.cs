using System;
using System.Collections.Generic;
using System.Text;
using Data;

namespace GSBGMconsole_APP
{
    public class Client
    {
        
        public void RunAPP()
        {
            Data.Models.BGUser LoginUser=new Data.Models.BGUser();
            Data.Repo r = new Data.Repo();
            Console.WriteLine("(1).sign in");
            Console.WriteLine("(2).sign up");
            //string str = Console.ReadLine();
            int selectNum = inputValidation(1, 2);
            if (selectNum==1)
            {
                string un, pw;
                do {
                    Console.WriteLine("Sign In");
                    Console.WriteLine("Enter your username angrily:");
                    un = Console.ReadLine();
                    Console.WriteLine("Enter your password angrily:");
                    pw = Console.ReadLine();
                    if (!r.UsernameExist(un))
                    {
                        Console.WriteLine("user doesnt exist");
                    }
                    else
                    {
                        if (!r.PasswordMatched(un, pw))
                        {
                            Console.WriteLine("wrong password");
                        }
                    }
                }
                while (!r.UsernameExist(un)||!r.PasswordMatched(un,pw));
                LoginUser = r.GetUserByUsername(un);
            }
            else if (selectNum == 2)
            {
                string un, pw, em, pn;
                DateTime dob;
                bool apn, aen;
                Console.WriteLine("Sign Up");
                do
                {
                    Console.WriteLine("Enter your username angrily:");
                    un = Console.ReadLine();
                    if (r.UsernameExist(un))
                    {
                        Console.WriteLine("user name exist");
                    }
                }
                while (r.UsernameExist(un));
                Console.WriteLine("Enter your password angrily:");
                 pw = Console.ReadLine();
                Console.WriteLine("Enter your email:");
                 em = Console.ReadLine();
                Console.WriteLine("Enter your Phone#");
                 pn = Console.ReadLine();
                Console.WriteLine("Enter your Date of birth(mm/dd/yyyy):");
                 dob = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine($"your Date of birth is {dob.ToString()}");
                Console.WriteLine("allow phone notification? (1)yes (2)no:");
                int selectNum1 = inputValidation(1, 2);
                apn = (selectNum1==1);
                Console.WriteLine("allow email notification? (1)yes (2)no:");
                int selectNum2 = inputValidation(1, 2);
                aen = (selectNum1 == 1);
                Domain.BGUser newUser = new Domain.BGUser(un, pw, em, pn, dob, apn, aen);
                r.AddUser(newUser);
                Console.WriteLine("new user added successfully!");
                LoginUser = r.GetUserByUsername(un);
            }
            UserActivity(LoginUser.Username);


            Console.WriteLine("------------end of test-----------------");
        }
        public void UserActivity(string un)
        {
            Data.Repo r = new Data.Repo();
            Data.Models.BGUser LoginUser = new Data.Models.BGUser();
            LoginUser = r.GetUserByUsername(un);
            Console.WriteLine($"welcome {LoginUser.Username}");
            Console.WriteLine("(1).Friends");
            Console.WriteLine("(2).Add a Friend");
            Console.WriteLine("(3).Board Games");
            Console.WriteLine("(4).Add a Board Game");
            int selectNum = inputValidation(1, 4);
            if (selectNum == 2)
            {
                string findun;
                do
                {
                    Console.WriteLine("Enter User to add friend:");
                    findun = Console.ReadLine();
                    if (!r.UsernameExist(findun))
                    {
                        Console.WriteLine("user doesnt exist");
                    }
                }
                while (!r.UsernameExist(findun));
                r.AddFriend(LoginUser.Username, findun);
                Console.WriteLine("Friend Added!");
            }
        }

        public int inputValidation(int min, int max)
        {
            int s = 0;
            do
            {
                if (!(Int32.TryParse(Console.ReadLine(), out s) && s <= max && s >= min))
                { Console.WriteLine("Please enter a valid input."); }
            }
            while (s > max || s < min); // check range
            return s;
        }
    }
}

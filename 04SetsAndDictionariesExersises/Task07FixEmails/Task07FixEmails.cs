using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Task07FixEmails
    {
        static void Main(string[] args)
        {

        string name = string.Empty;

        int counter = 1;

        var mailsBook = new Dictionary<string, string>();

        while (name!="stop")
        {
            if (counter%2!=0)
            {
                name = Console.ReadLine();      
            }
            else
            {
                string mail = Console.ReadLine();

                string country = mail.Substring(mail.Length - 2, 2);

                if (country!="us" && country!="uk")
                {
                    mailsBook[name] = mail;
                }             
            }

            counter++;

        }

        foreach (var nameMail in mailsBook)
        {
            Console.WriteLine($"{nameMail.Key} -> {nameMail.Value}");
        }
        
        }
    }


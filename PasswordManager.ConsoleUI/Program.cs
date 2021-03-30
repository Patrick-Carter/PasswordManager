using PasswordManager.Data.Model;
using System;
using System.IO;

namespace PasswordManager.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamWriter file = new StreamWriter("testy.txt", true))
            {
                UserModel user = new UserModel("Patrick", "123455");

                file.WriteLine(user);
            }

            string[] lines = File.ReadAllLines("testy.txt");

            foreach (var item in lines)
            {
                Console.WriteLine(item);
            }
                Console.ReadLine();
        }

       
    }
}

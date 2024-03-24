using langchips_project.Application;
using langchips_project.Data;
using langchips_project.Models;
using System.Collections.Generic;

namespace langchips_project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // User user = new User("Paulina", "Okulska", "paulinaokuslka@gmail.com", "test123", "paulina1");
            User user = new User("t", "t", "t", "t", "t");

            AppManager appManager = new AppManager(user);
            Dictionary dictionary=  appManager.CreateDictionary("TestDict", Language.PL, Language.EN);
            dictionary.AddEntry("pink", "rozowy", Language.EN, Language.PL, dictionary.DictionaryName);
            //dictionary.FindEntryByWord("pink", "rozowy");
            Console.ReadLine();
           
        }
    }
}

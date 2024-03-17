using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace langchips_project.Models
{
    public enum Language
    {
        EN, // English
        PL, // Polish
        ES, // Spanish
        FR, // French
        PT  // Portuguese
    }
    public static class LanguageHelper
    {
        public static Language ParseLanguage(string userInput)
        {
            switch (userInput.ToUpper())
            {
                case "EN":
                case "ENGLISH":
                    return Language.EN;
                case "PL":
                case "POLISH":
                    return Language.PL;
                case "ES":
                case "SPANISH":
                    return Language.ES;
                case "FR":
                case "FRENCH":
                    return Language.FR;
                case "PT":
                case "PORTUGUESE":
                    return Language.PT;
                default:
                    throw new ArgumentException("Invalid language code.");
            }
        }
    }
}

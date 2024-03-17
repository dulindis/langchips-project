using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace langchips_project.Models
{
    internal class Entry
    {
        public string Word { get; set; }
        public string Translation { get; set; }
        public Language LanguageOfWord { get; set; }

        public Language LanguageOfTranslation { get; set; }
        public bool HasVoiceOption { get; set; } // TODO: handle voice entry

        public Entry(string word, string translation, Language languageOfWord, Language languageOfTranslation, bool hasVoiceOption)
        {
            Word = word;
            Translation = translation;
            LanguageOfWord = languageOfWord;
            LanguageOfTranslation = languageOfTranslation;
            HasVoiceOption = hasVoiceOption;
        }

        public void ModifyEntry(string word, string translation, Language languageOfWord, Language languageOfTranslation, bool hasVoiceOption)
        {
            Word = word;
            Translation = translation;
            LanguageOfWord = languageOfWord;
            LanguageOfTranslation = languageOfTranslation;
            HasVoiceOption = hasVoiceOption;
        }
    }
}

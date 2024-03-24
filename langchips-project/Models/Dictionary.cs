using langchips_project.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace langchips_project.Models
{
    internal class Dictionary
    {

        public string DictionaryName { get; set; } 
        public Language Language1 { get; set; }
        public Language Language2 { get; set; }
        public User User { get; set; }
        public bool isPublic { get; set; }
        public bool isActive { get; set; }
        public List<Entry> Collection { get; set; }

        private readonly EntryContext _entryContext;

        public Dictionary(string dictionaryName , Language language1, Language language2, User user, EntryContext dbContext = null)
        {
            DictionaryName = dictionaryName;
            _entryContext = dbContext ?? new EntryContext();
            Language1 = language1;
            Language2 = language2;
            User = user;
            isPublic = true;
            isActive = true;
            Collection = new List<Entry>();
        }

     
        public Entry AddEntry(string word1, string word2, Language language1, Language language2, string dictionaryName)
        {
            bool canProceed= doSelectedLanguagesMatchDictionaryLanguage(language1 , language2);
            if(canProceed)
            {
                var newEntry = new Entry(word1, word2, language1, language2, true, dictionaryName);
                _entryContext.Entries.Add(newEntry);
                _entryContext.SaveChanges();
                return newEntry;
            }
            return null;
        }
        public Entry FindEntryByWord(string word1, string word2)
        {
            try
            {
                var entry = _entryContext.Entries.FirstOrDefault(e => e.Word == word1 && e.Translation == word2);

                return entry;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error finding entry in database: {ex.Message}");
                return null;
            }
        }
        public bool doSelectedLanguagesMatchDictionaryLanguage(Language language1, Language language2)
        {
            bool lang1 = language1 == Language1 || language1 == Language2;
            bool lang2 = language2 == Language1 || language2 == Language2;
            return lang1 && lang2;
        }
        public List<Entry> GetAllEntries()
        {
            return _entryContext.Entries.ToList();
        }
    }

}

using langchips_project.Models;
using langchips_project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace langchips_project.Controllers
{
    internal class FolderController
    {
        private Dictionary<string, List<Entry>> folders = new Dictionary<string, List<Entry>>();

        public bool CreateFolder(string folderPath, string folderName)
        {
            string fullFolderPath = Path.Combine(folderPath, folderName);

            if (!FolderExists(fullFolderPath))
            {
                Directory.CreateDirectory(fullFolderPath);
                folders.Add(folderName, new List<Entry>());
                return true;
            }
            return false;
        }

        public bool CreateEntryFileInFolder(string folderPath, string folderName, string entryFileName)
        {
            string entryFileFullName = entryFileName + ".csv";
            string entryFilePath = Path.Combine(folderPath, folderName, entryFileFullName);

            if (!FileExists(entryFilePath))
            {
                File.Create(entryFilePath).Close();
                return true;
            }
            else
            {
                return false;
            }                    
        }

        public bool CreateEntryInFile(string filePath)
        {
            bool fileExists = FileExists(filePath);

            if (!fileExists)
            {
                return false;
            }

            List<Entry> newEntryList = new List<Entry>();
            return true;
        }
        //comment empty
        public Entry CreateNewEntry(string word, string translation, Language languageOfWord, Language languageOfTranslation, bool hasVoiceOption)
        {
            Entry newEntry = new Entry(word, translation, languageOfWord, languageOfTranslation, hasVoiceOption);
            return newEntry;
        }

        public bool DeleteEntryInFile(string entryFilePath, string wordToDelete)
        {
            List<Entry> existingEntries = LoadEntriesFromFile(entryFilePath);

            Entry entryToDelete = existingEntries.FirstOrDefault(entry => entry.Word.Equals(wordToDelete, StringComparison.OrdinalIgnoreCase));
            if (entryToDelete == null)
            {
                return false;
            }
            existingEntries.Remove(entryToDelete);
            SaveEntryListToFile(entryFilePath, existingEntries);
            return true;

        }

        public List<Entry> LoadEntriesFromFile(string filePath)
        {
            List<Entry> entryList = new List<Entry>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] parts = line.Split(',');
  
                    if (parts.Length == 5)
                    {
                        Language languageOfWord;
                        if (!Enum.TryParse(parts[2], out languageOfWord))
                        {                 
                            continue; 
                        }

                        Language languageOfTranslation;
                        if (!Enum.TryParse(parts[3], out languageOfTranslation))
                        {
                          
                            continue;
                        }

                        Entry entry = new Entry(parts[0], parts[1], languageOfWord, languageOfTranslation, bool.Parse(parts[4]));
                        entryList.Add(entry);
                    }
                }
            }

            return entryList;
        }

        public void SaveEntryListToFile(string filePath, List<Entry> entryList)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Entry entry in entryList)
                {
                    writer.WriteLine($"{entry.Word},{entry.Translation},{entry.LanguageOfWord},{entry.LanguageOfTranslation},{entry.HasVoiceOption}");
                }
            }
        }

        public bool FileExists(string entryFilePath)
        {
            return File.Exists(entryFilePath);
        }

        public bool FolderExists(string folderPath, string folderName)
        {
            string fullFolderPath = Path.Combine(folderPath, folderName);
            return Directory.Exists(fullFolderPath);
        }

        public bool FolderExists(string fullPath)
        {
            return Directory.Exists(fullPath);
        }

       
    }
}

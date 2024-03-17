using langchips_project.Controllers;
using langchips_project.Models;
using langchips_project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace langchips_project.Application
{
    internal class AppManager
    {
 

        private string folderPath;
        private FolderController folderController;

        public AppManager(string folderPath)
        {
            this.folderPath = folderPath;
            this.folderController = new FolderController();
        }
        public void CreateFolder()
        {
            string folderName = InputHelper.ValidateEntry("Enter folder name:");

            try
            {
                bool isFolderCreated = folderController.CreateFolder(folderPath, folderName);

                if (isFolderCreated)
                {
                    Console.WriteLine("Folder created successfully.");
                }
                else 
                {
                    Console.WriteLine("Folder already exists.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred: {ex.Message}");
            }
        }

        public void CreateEntryFileInFolder()
        {
            string folderName = InputHelper.ValidateEntry("Enter folder name:");
            bool folderExists = folderController.FolderExists(folderPath, folderName);

            if(!folderExists)
            {
                Console.WriteLine("Folder does not exist");
                bool userDecision = InputHelper.GetValidBooleanInput("Do you want to create a new folder?");
                if (userDecision == true)
                {
                    CreateFolder();
                }
                else return;
            }
            else
            {
                string entryFileName = InputHelper.ValidateEntry("Enter file name:");
                bool entryCreated = folderController.CreateEntryFileInFolder(folderPath, folderName, entryFileName);
                  
                if (entryCreated)
                {
                    Console.WriteLine("Entry file created successfully.");

                } else
                {
                    Console.WriteLine("Entry file already exists in the folder.");
                }
            }
        }

        private void ShowExisitngEntries(List<Entry> entryList)
        {
            foreach (Entry entry in entryList)
            {
                Console.WriteLine($"Word: {entry.Word}");
                Console.WriteLine($"Translation: {entry.Translation}");
                Console.WriteLine($"Language of Word: {entry.LanguageOfWord}");
                Console.WriteLine($"Language of Translation: {entry.LanguageOfTranslation}");
                Console.WriteLine($"Has Voice Option: {entry.HasVoiceOption}");
            }
        }

        public void CreateEntryInFile()
        {
            string folderName = InputHelper.ValidateEntry("Enter folder name:");
            bool folderExists = folderController.FolderExists(folderPath, folderName);
            if (!folderExists)
            {
                Console.WriteLine("Folder does not exist");      
                return;
            }
            string entryFileName = InputHelper.ValidateEntry("Enter file name:");
            string entryFileFullName = entryFileName + ".csv";
            string fullFilePath = Path.Combine(folderPath, folderName, entryFileFullName);
            bool fileExists=folderController.FileExists(fullFilePath);
            Console.Write("entryFilePath"+ fullFilePath);
            if (!fileExists)
            {
                Console.WriteLine("Entry file does not exist in the folder. Please create it first.");
                return;
            }

            List<Entry> entryList = folderController.LoadEntriesFromFile(fullFilePath);
            Console.WriteLine("The following entries are present in your file:");
            ShowExisitngEntries(entryList);

            List<Entry> newEntryList = new List<Entry>();

            bool shouldContinue;
            do
            {
                Entry newEntry = CreateNewEntry();
                entryList.Add(newEntry);
                shouldContinue = InputHelper.GetValidBooleanInput("Do you want to add another entry? (true/false)");
            } while (shouldContinue);

            folderController.SaveEntryListToFile(fullFilePath, entryList);
            ShowExisitngEntries(entryList);
            Console.WriteLine("Entries saved successfully.");

        }

        public Entry CreateNewEntry()
        {
            Console.WriteLine("Enter word:");
            string word = Console.ReadLine();
            Console.WriteLine("Enter translation:");
            string translation = Console.ReadLine();
            Console.WriteLine("Enter language of word:");

            Language languageOfWord = LanguageHelper.ParseLanguage(Console.ReadLine());
            Console.WriteLine("Enter language of translation:");
            Language languageOfTranslation = LanguageHelper.ParseLanguage(Console.ReadLine());
            bool hasVoiceOption = InputHelper.GetValidBooleanInput("Does it have voice option? (true/false):");
            Entry newEntry = folderController.CreateNewEntry(word, translation, languageOfWord, languageOfTranslation, hasVoiceOption);
            return newEntry;
        }

        public void DeleteEntryInFile()
        {

            string folderName = InputHelper.ValidateEntry("Enter folder name:");
            bool folderExists = folderController.FolderExists(folderPath, folderName);
            if (!folderExists)
            {
                Console.WriteLine("Folder does not exist");
                return;
            }
            string entryFileName = InputHelper.ValidateEntry("Enter file name:");

            string entryFileFullName = entryFileName + ".csv";
            string fullFilePath = Path.Combine(folderPath, folderName, entryFileFullName);
            bool fileExists = folderController.FileExists(fullFilePath);
            
            if (!fileExists)
            {
                Console.WriteLine("Entry file does not exist in the folder. Please create it first.");
                return;
            }

            List<Entry> entryList = folderController.LoadEntriesFromFile(fullFilePath);
            Console.WriteLine("The following entries are present in your file:");
            ShowExisitngEntries(entryList);

            string wordToDelete = InputHelper.ValidateEntry("Enter the word of the entry to delete:");

            bool entryDeleted = folderController.DeleteEntryInFile(fullFilePath, wordToDelete);
            if (!entryDeleted)
            {
                Console.WriteLine("Entry with the specified word not found.");
            }
            else
            {
                Console.WriteLine("Entry deleted successfully.");
                Console.WriteLine("The following entries are present in your file:");
                List<Entry> newEntryList = folderController.LoadEntriesFromFile(fullFilePath);

                ShowExisitngEntries(newEntryList);
            }

        }


        public Language convertLanguageInput()
        {
            Console.WriteLine("Enter a language code or name:");
            string userAnswer=InputHelper.ValidateEntry(Console.ReadLine());
            Language language = LanguageHelper.ParseLanguage(userAnswer);
            return language;
        }
    }


}


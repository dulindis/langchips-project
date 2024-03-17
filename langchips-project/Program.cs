using langchips_project.Application;

namespace langchips_project
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string folderPath = "C:\\Users\\pauli\\source\\repos\\langchips-project";
            AppManager appManager = new AppManager(folderPath);
            //appManager.CreateFolder();
            //appManager.CreateEntryFileInFolder();
            appManager.CreateEntryInFile();
            //appManager.DeleteEntryInFile();
            Console.ReadLine();
        }
    }
}

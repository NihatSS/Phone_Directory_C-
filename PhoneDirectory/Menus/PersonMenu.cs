using PhoneDirectory.Controllers;
using PhoneDirectory.Helpers;
using System.Diagnostics;

namespace PhoneDirectory.Menus
{
    public class PersonMenu
    {
        PersonController controller;
        public PersonMenu()
        {
            controller = new();

            bool isContinue = true;
            do
            {
                ConsoleColor.Cyan.WriteConsole("Enter the operation!\n1-Add person\n2-Delete person\n3-Update person\n4-Person listing\n5-Search person\n6-Clear console");
                string strNum = Console.ReadLine();
                bool isCorrectFormat = int.TryParse(strNum, out int operation);
                if (isCorrectFormat)
                {
                    switch (operation)
                    {
                        case (int)Operations.AddPerson:
                            controller.Create();
                            break;
                        case (int)Operations.DeletePerson:
                            controller.Delete();
                            break;
                        case (int)Operations.UpdatePerson:
                            controller.Edit();
                            break;
                        case (int)Operations.GetAll:
                            controller.GetAll();
                            Thread.Sleep(1000);
                            break;
                        case (int)Operations.Search:
                            controller.Search();
                            break;
                        case (int)Operations.ClearConsole:
                            Console.Clear();
                            break;
                        default:
                            break;
                    }
                }
            } while (isContinue);
        }
    }
}

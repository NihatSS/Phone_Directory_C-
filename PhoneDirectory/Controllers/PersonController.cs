using PhoneDirectory.Helpers;
using PhoneDirectory.Models;
using PhoneDirectory.Services;
using PhoneDirectory.Services.Interfaces;

namespace PhoneDirectory.Controllers
{
    internal class PersonController
    {
        private readonly IPersonService _service;

        public PersonController()
        {
            _service = new PersonService();
        }



        //1)

        public async Task Create()
        {
            Console.WriteLine("Enter the person name :");
            Name: string personName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(personName))
            {
                ConsoleColor.Red.WriteConsole("Invalid input! Please enter the corret name :");
                goto Name;
            }


            Console.WriteLine("Enter the phine number : ");
            Phone: string phone = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(phone))
            {
                ConsoleColor.Red.WriteConsole("Invalid input! Please enter the corret number :");
                goto Phone;
            }

            await _service.CreateAsync(new Person { Name = personName, Phone = phone });
        }


        
        //2)

        public async Task Delete()
        {
            Console.WriteLine("Enter the person id :");
            Num: string strNum = Console.ReadLine();

            bool isCorrectIdFormat = int.TryParse(strNum, out var id);

            if (isCorrectIdFormat)
            {
                Question: ConsoleColor.Yellow.WriteConsole("Are you sure to delete this person ?(y/n)");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "y":
                        await _service.DeleteAsync(id);
                        ConsoleColor.Green.WriteConsole("Person successfully deleted!");
                        break;
                    case "n":
                        break;
                    default:
                        ConsoleColor.Red.WriteConsole("Please enter correct answer");
                        goto Question;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Invalid id! Please enter corret id :");
                goto Num;
            }
        }

        //3)

        public async Task Edit()
        {
            Console.WriteLine("Enter the person id :");
            Num: string strNum = Console.ReadLine();

            bool isCorrectIdFormat = int.TryParse(strNum, out var id);

            if (isCorrectIdFormat)
            {
                Console.WriteLine("Enter the person's name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter the person's phone:");
                string phone = Console.ReadLine();
                await _service.EditAsync(id, new Person { Name = name, Phone = phone });
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Invalid id! Please enter corret id :");
                goto Num;
            }
        }


        //4)

        public async Task GetAll()
        {
            foreach (var item in await _service.GetAllAsync())
            {
                Console.WriteLine(item);
            }
        }

        //5)

        public async Task Search()
        {
            Console.WriteLine("1-Search with name\n2-Search with phone");
            Text: string strNum = Console.ReadLine();
            bool isCorrectFormat = int.TryParse(strNum,out var operation);

            if (isCorrectFormat)
            {
                switch (operation)
                {
                    case 1:
                        Console.WriteLine("Enter the person's name:");
                        string name = Console.ReadLine();
                        var datasFromNames = await _service.SearchWithPhoneAsync(name);
                        foreach (var data in datasFromNames)
                        {
                            Console.WriteLine(data);
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter the person's phone:");
                        string phone = Console.ReadLine();
                        var datas =await _service.SearchWithPhoneAsync(phone);
                        foreach (var data in datas)
                        {
                            Console.WriteLine(data);
                        }
                        break;
                    default:
                        break;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Invalid input! Please enter the corret operation :");
                goto Text;
            }
        }
    }
}

using PhoneDirectory.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneDirectory.Services.Interfaces
{
    internal interface IPersonService 
    {
        Task<List<Person>> GetAllAsync();
        Task CreateAsync(Person person);
        Task DeleteAsync(int id);
        Task EditAsync(int id, Person person);
        Task<List<Person>> SearchWithNameAsync(string name);
        Task<List<Person>> SearchWithPhoneAsync(string phone);

    }
}

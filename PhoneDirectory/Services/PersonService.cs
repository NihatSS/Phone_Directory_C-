using Microsoft.EntityFrameworkCore;
using PhoneDirectory.Data;
using PhoneDirectory.Exceptions;
using PhoneDirectory.Models;
using PhoneDirectory.Services.Interfaces;

namespace PhoneDirectory.Services
{
    public class PersonService : IPersonService
    {
        private readonly AppDbContext _context;

        public PersonService()
        {
            _context = new AppDbContext();
        }



        public async Task<List<Person>> GetAllAsync()
        {
            return await _context.People.ToListAsync();
        }



        public async Task DeleteAsync(int id)
        {
            var response = await _context.People.FindAsync(id) ?? throw new NotFoundException("Data not found!");
             _context.People.Remove(response);
            await _context.SaveChangesAsync();
        }




        public async Task EditAsync(int id, Person person)
        {
            var existPerson = await _context.People.FindAsync(id) ?? throw new NotFoundException("Data not found!");

            if (string.IsNullOrWhiteSpace(person.Name))
            {
                existPerson.Name = existPerson.Name;
            }
            if (string.IsNullOrWhiteSpace(person.Phone))
            {
                existPerson.Phone = existPerson.Phone;
            }
            else
            {
                existPerson.Name = person.Name;
                existPerson.Phone = person.Phone;
            }

            await _context.SaveChangesAsync();
        }




        public async Task CreateAsync(Person person)
        {
            await _context.People.AddAsync(person);
            await _context.SaveChangesAsync();
        }




        public async Task<List<Person>> SearchWithNameAsync(string name)
        {
            return await _context.People.Where(m=>m.Name.Contains(name)).ToListAsync() ?? throw new NotFoundException("Data not found!");
        }
        
        public async Task<List<Person>> SearchWithPhoneAsync(string phone)
        {
            return await _context.People.Where(m=>m.Phone.Contains(phone)).ToListAsync() ?? throw new NotFoundException("Data not found!");
        }
    }
}

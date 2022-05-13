
using WebAppApi.Models;

namespace WebAppApi.Services
{
    public interface IContactsService
    {
        public Contact Get(string Id);
        public List<Contact> GetAll();
        public void Create(string Id ,string Name, string Server);

        public void Edit(string Id, string Name, string Server, string Last);

        public void Delete(string Id);
    }
}

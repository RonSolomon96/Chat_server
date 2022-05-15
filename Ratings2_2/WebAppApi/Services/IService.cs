using WebAppApi.Models;

namespace WebAppApi.Services
{
    public interface IService
    {
        public Contact GetContact(string Id);
        public List<Contact> GetAllContacts();
        public void CreateContact(string Id, string Name, string Server);

        public void EditContact(string Id, string Name, string Server);

        public void DeleteContact(string Id);


        public Message GetMessage(int Id);

        public List<Message> GetAllMessages();

        public void CreateMessage(string Content);

        public void EditMessage(int Id, string Content);

        public void DeleteMessage(int Id);
    }
}

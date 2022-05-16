using WebAppApi.Models;

namespace WebAppApi.Services
{
    public interface IService
    {
        public Contact GetContact(string User, string Id);

        public List<Contact> GetAllContacts(string User);
        
        public void CreateContact(string User, string Id, string Name, string Server);

        public void EditContact(string User, string Id, string Name, string Server);

        public void DeleteContact(string User, string Id);


        public Message GetMessage(string User, string Contact, int Id);

        public List<Message> GetAllMessages(string User, string Contact);

        public void CreateMessage(string User, string Contact, string Content);

        public void EditMessage(string User, string Contact, int Id, string Content);

        public void DeleteMessage(string User, string Contact, int Id);
    }
}

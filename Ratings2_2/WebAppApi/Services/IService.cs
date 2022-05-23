using WebAppApi.Models;

namespace WebAppApi.Services
{
    public interface IService
    {
        public User GetUser(string Username);

        public List<User> GetAllUsers();

        public void CreateUser(string Username, string Password, string Nickname, string Server);

       // public void EditUser(string Username string Password, string Nickname, string Server);

       // public void DeleteContact(string User, string Id);



        public ContactClone GetContact(string User, string Id);

        public List<ContactClone> GetAllContacts(string User);
        
        public void CreateContact(string User, string Id, string Name, string Server);

        public void EditContact(string User, string Id, string Name, string Server);

        public void DeleteContact(string User, string Id);


        public Message GetMessage(string User, string Contact, int Id);

        public List<Message> GetAllMessages(string User, string Contact);

        public void CreateMessage(string User, string Contact,bool ort, string Content);

        public void EditMessage(string User, string Contact, int Id, string Content);

        public void DeleteMessage(string User, string Contact, int Id);
    }
}

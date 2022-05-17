using WebAppApi.Models;

namespace WebAppApi.Services
{
    public class Service : IService
    {
        Dictionary<string, List<Contact>> DB = new Dictionary<string, List<Contact>>();
       // List<User> Users = new List<User>();



        public Contact GetContact(string User, string Id)
        {
            return DB[User].Find(c => c.Id == Id); 
                //Contacts.Find(c => c.Id == Id);
        }

        public List<Contact> GetAllContacts(string User)
        {
            return DB[User];
        }
        public void CreateContact(string User, string Id, string Name, string Server)
        {
            DB[User].Add(new Contact()
            {
                Id = Id,
                Name = Name,
                Server = Server,
                Last = "",
                Lastdate = DateTime.Now.ToString(),
                Messages = new List<Message>()
            });
        }

        public void EditContact(string User, string Id, string Name, string Server)
        {
            Contact obj = GetContact(User, Id);
            if (obj != null)
            {
                obj.Name = Name;
                obj.Server = Server;
                obj.Lastdate = DateTime.Now.ToString();
            }
        }

        public void DeleteContact(string User, string Id)
        {
            Contact obj = GetContact(User, Id);
            if (obj != null)
            {
                DB[User].Remove(obj);
            }
        }



        

        public Message GetMessage(string User, string Contact, int Id)
        {
            return DB[User].Find(c => c.Id == Contact).Messages.Find(m => m.Id == Id);
        }

        public List<Message> GetAllMessages(string User, string Contact)
        {
            return DB[User].Find(c => c.Id == Contact).Messages;
        }

        public void CreateMessage(string User, string Contact, string Content)
        {
            List<Message> Messages = DB[User].Find(c => c.Id == Contact).Messages;
            int id = 0;
            if (Messages.Count != 0)
            {
                id = Messages.Max(x => x.Id) + 1;
            }

            Messages.Add(new Message()
            {
                Id = id,
                Content = Content,
                Created = DateTime.Now.ToString(),
                Sent = true
            });
        }

        public void EditMessage(string User, string Contact, int Id, string Content)
        {
            Message obj = GetMessage(User, Contact, Id);
            if (obj != null)
            {
                obj.Content = Content;
                obj.Created = DateTime.Now.ToString();
            }
        }

        public void DeleteMessage(string User, string Contact, int Id)
        {
            Message obj = GetMessage(User, Contact, Id);
            if (obj != null)
            {
                DB[User].Find(c => c.Id == Contact).Messages.Remove(obj);
            }
        }
    }
}

using WebAppApi.Models;

namespace WebAppApi.Services
{
    public class Service : IService
    {
        Dictionary<string, List<Contact>> DB = new Dictionary<string, List<Contact>>();
        List<User> Users = new List<User>();

        public User GetUser(string Username)
        {
            return Users.Find(u => u.UserName == Username);
            //Contacts.Find(c => c.Id == Id);
        }

        public List<User> GetAllUsers()
        {
            return Users;
        }

        public void CreateUser(string Username, string Password, string Nickname, string Server)
        {

            Users.Add(new User()
            {
                UserName = Username,
                Password = Password,
                Nickname = Nickname,    
                Server = Server
            });

            DB[Username] = new List<Contact>();
        }

       




        public ContactClone GetContact(string User, string Id)
        {
            if (GetUser(User) == null) { 
                return null;    
            }
            
            return DB[User].Find(c => c.Id == Id);
        }

        public List<ContactClone> GetAllContacts(string User)
            
        {
            if (GetUser(User) == null)
            {
                return null;
            }
            List<ContactClone> contacts = new List<ContactClone>();
            foreach (Contact contact in DB[User]) { 

                contacts.Add(new ContactClone()
                {
                    Id = contact.Id,
                    Name = contact.Name,
                    Server = contact.Server,
                    Last = contact.Last,
                    Lastdate = contact.Lastdate
                });
            }
            return contacts;
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
            ContactClone obj = GetContact(User, Id);
            if (obj != null)
            {
                obj.Name = Name;
                obj.Server = Server;
                obj.Lastdate = DateTime.Now.ToString();
            }
        }

        public void DeleteContact(string User, string Id)
        {
            ContactClone obj = GetContact(User, Id);
            if (obj != null)
            {
                DB[User].Remove((Contact)obj);
            }
        }



        

        public Message GetMessage(string User, string Contact, int Id)
        {
            if (GetContact(User, Contact) == null)
            {
                return null;
            }
            return DB[User].Find(c => c.Id == Contact).Messages.Find(m => m.Id == Id);
        }

        public List<Message> GetAllMessages(string User, string Contact)
        {
            if (GetContact(User, Contact) == null)
            {
                return null;
            }
            return DB[User].Find(c => c.Id == Contact).Messages;
        }

        public void CreateMessage(string User, string Contact,bool ort, string Content)
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
                Sent = ort
            }) ;
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

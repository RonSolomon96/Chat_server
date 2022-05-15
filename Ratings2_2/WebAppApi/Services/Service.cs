using WebAppApi.Models;

namespace WebAppApi.Services
{
    public class Service : IService
    {
        private static List<Contact> Contacts = new List<Contact>();
        private static List<Message> Messages = new List<Message>();


        public Contact GetContact(string Id)
        {
            return Contacts.Find(c => c.Id == Id);
        }

        public List<Contact> GetAllContacts()
        {
            return Contacts;
        }
        public void CreateContact(string Id, string Name, string Server)
        {
            Contacts.Add(new Contact()
            {
                Id = Id,
                Name = Name,
                Server = Server,
                Last = "",
                Lastdate = DateTime.Now.ToString()
            });
        }

        public void EditContact(string Id, string Name, string Server)
        {
            Contact obj = GetContact(Id);
            if (obj != null)
            {
                obj.Name = Name;
                obj.Server = Server;
                obj.Lastdate = DateTime.Now.ToString();
            }
        }

        public void DeleteContact(string Id)
        {
            Contact obj = GetContact(Id);
            if (obj != null)
            {
                Contacts.Remove(obj);
            }
        }



        

        public Message GetMessage(int Id)
        {
            return Messages.Find(c => c.Id == Id);
        }

        public List<Message> GetAllMessages()
        {
            return Messages;
        }
        public void CreateMessage(string Content)
        {
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

        public void EditMessage(int Id, string Content)
        {
            Message obj = GetMessage(Id);
            if (obj != null)
            {
                obj.Content = Content;
                obj.Created = DateTime.Now.ToString();
            }
        }

        public void DeleteMessage(int Id)
        {
            Message obj = GetMessage(Id);
            if (obj != null)
            {
                Messages.Remove(obj);
            }
        }
    }
}

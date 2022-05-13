using WebAppApi.Models;

namespace WebAppApi.Services
{
    public class ContactsService : IContactsService
    {
        private static List<Contact> Contacts = new List<Contact>();

        public Contact Get(string Id)
        {
            return Contacts.Find(c => c.Id == Id);
        }

        public List<Contact> GetAll()
        {
            return Contacts;
        }
        public void Create(string Id, string Name, string Server)
        {
            Contacts.Add(new Contact()
            {
                Id = Id,
                Name = Name,
                Server = Server,
                Last = "",
                Lastdate = DateTime.Now.ToString()
            }) ;
        }

        public void Edit(string Id, string Name, string Server, string Last)
        {
            Contact obj = Get(Id);
            obj.Name = Name;
            obj.Server = Server;
            obj.Last = Last;
            obj.Lastdate = DateTime.Now.ToString();
        }

        public void Delete(string Id)
        {
            Contacts.Remove(Get(Id));

        }
    }
}

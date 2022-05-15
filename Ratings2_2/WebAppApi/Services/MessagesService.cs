using WebAppApi.Models;

namespace WebAppApi.Services
{
    public class MessagesService : IMessagesService
    {
        private static List<Message> Messages = new List<Message>();

        public Message Get(int Id)
        {
            return Messages.Find(c => c.Id == Id);
        }

        public List<Message> GetAll()
        {
            return Messages;
        }
        public void Create(string Content)
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

        public void Edit(int Id, string Content)
        {
            Message obj = Get(Id);
            if (obj != null)
            {
                obj.Content = Content;
                obj.Created = DateTime.Now.ToString();
            }
        }

        public void Delete(int Id)
        {
            Message obj = Get(Id);
            if (obj != null)
            {
                Messages.Remove(obj);
            }
        }
    }
}

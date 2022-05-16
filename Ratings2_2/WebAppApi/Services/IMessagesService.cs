using WebAppApi.Models;

namespace WebAppApi.Services
{
    public interface IMessagesService
    {
        public Message Get(int Id);

        public List<Message> GetAll();

        public void Create(string Content);

        public void Edit(int Id, string Content);

        public void Delete(int Id);
    }
}

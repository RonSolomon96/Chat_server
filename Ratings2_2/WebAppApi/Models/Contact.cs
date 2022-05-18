using System.ComponentModel.DataAnnotations;

namespace WebAppApi.Models
{
    public class Contact : ContactClone
    {
        public List<Message> Messages { set; get; }
    }
}

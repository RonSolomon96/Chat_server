using System.ComponentModel.DataAnnotations;

namespace WebAppApi.Models
{
    public class Message
    {
        [Key]
        public int Id { set; get; }

        public string Content { set; get; }

        public string Created { set; get; }

        public bool Sent { set; get; }

    }
}

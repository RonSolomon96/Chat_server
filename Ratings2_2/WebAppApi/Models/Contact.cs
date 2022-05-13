using System.ComponentModel.DataAnnotations;

namespace WebAppApi.Models
{
    public class Contact
    {
        [Key]
        public string Id { set; get; }

        public string Name { set; get; }

        public string Server { set; get; }

        public string Last { set; get; }

        public string Lastdate { set; get; }
    }
}

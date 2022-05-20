using System.ComponentModel.DataAnnotations;

namespace WebAppApi.Models
{
    public class invitation
    {
        [Key]
        public string From { set; get; }
        public string To { set; get; }
        public string Server { set; get; }

    }
}

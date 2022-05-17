using System.ComponentModel.DataAnnotations;

namespace WebAppApi.Models
{
    public class User
    {
        [Key]
        public string UserName { set; get; }

        public string Password { set; get; }

        public string Nickname { set; get; }

        [Required]
        public string Server { set; get; }

    }
}

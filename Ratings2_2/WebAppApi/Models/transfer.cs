using System.ComponentModel.DataAnnotations;

namespace WebAppApi.Models
{
    public class transfer
    {
        [Key]
        public string From { set; get; }
        public string To { set; get; }
        public string Content { set; get; }

    }
}


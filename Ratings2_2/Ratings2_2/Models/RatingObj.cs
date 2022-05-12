using System.ComponentModel.DataAnnotations;

namespace Ratings2_2.Models
{
    public class RatingObj
    {
        public int Id { set; get; }
        
        [Required(ErrorMessage = "Name is required ")]
        public string Name { set; get; }

        [Range(1,5)]
        public int Rate { set; get; }
        public string Description { set; get; }
        public string Date { set; get; }
    }
}

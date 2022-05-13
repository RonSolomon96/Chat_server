using Ratings2_2.Models;
namespace Ratings2_2.Services
{
    public class RatingObjService : IRatingObjService
    {
        private static List<RatingObj> Rlist = new List<RatingObj>();

        public RatingObj Get(int id)
        {
            return Rlist.Find(x => x.Id == id);
        }
        public List<RatingObj> GetAll()
        {
            return Rlist;
        }
        public void Create(string Name, int Rate, string Description)
        {
            int id = 0;
            if (Rlist.Count != 0)
            {
                id = Rlist.Max(x => x.Id) + 1;
            }
            if (Description == null) {
                Description = "";
            }
            Rlist.Add(new RatingObj()
            {
                Id = id,
                Name = Name,
                Rate = Rate,
                Description = Description,
                Date = DateTime.Now.ToString()
            });
        }

        public void Edit(int Id, string Name, int Rate, string description)
        {
            RatingObj obj = Get(Id);
            obj.Name = Name;
            obj.Rate = Rate;
            obj.Description = description;
            obj.Date = DateTime.Now.ToString();
        }

        public void Delete(int Id)
        {
            Rlist.Remove(Get(Id));

        }
    }
}

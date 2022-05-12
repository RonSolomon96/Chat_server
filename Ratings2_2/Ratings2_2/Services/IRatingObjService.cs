using Ratings2_2.Models;

namespace Ratings2_2.Services
{
    public interface IRatingObjService
    {
        public RatingObj Get(int id);
        public List<RatingObj> GetAll();
        public void Create(string Name, int Rate, string description);

        public void Edit(int Id, string Name, int Rate, string description);
        public void Delete(int Id);


    }
}
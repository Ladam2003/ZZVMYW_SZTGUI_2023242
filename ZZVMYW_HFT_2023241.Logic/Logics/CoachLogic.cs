using System;
using System.Linq;
using ZZVMYW_HFT_2023241.Models;
using ZZVMYW_HFT_2023241.Repository;

namespace ZZVMYW_HFT_2023241.Logic
{
    public class CoachLogic : ICoachLogic
    {
        IRepository<Coach> repo;

        public CoachLogic(IRepository<Coach> repo)
        {
            this.repo = repo;
        }

        public void Create(Coach item)
        {
            if (item.CoachName.Length < 6)
            {
                throw new Exception("Less then 6 character Name does not exist!");
            }
            if (item.CoachName == "")
            {
                throw new Exception("Null CoachName does not exits!");
            }
            this.repo.Create(item);
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }


        public Coach Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Coach> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Coach item)
        {
            this.repo.Update(item);
        }
    }
}

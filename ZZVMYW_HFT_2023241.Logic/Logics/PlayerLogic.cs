using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZVMYW_HFT_2023241.Models;
using ZZVMYW_HFT_2023241.Repository;

namespace ZZVMYW_HFT_2023241.Logic
{
    public class PlayerLogic : IPlayerLogic
    {
        IRepository<Player> repo;

        public PlayerLogic(IRepository<Player> repo)
        {
            this.repo = repo;
        }

        public void Create(Player item)
        {
            if (item.PlayerName.Length < 5)
            {
                throw new Exception("Less then 5 character Name does not exist!");
            }
            if (item.PlayerName == "")
            {
                throw new Exception("Null PlayerName does not exits!");
            }
             repo.Create(item);
            
            
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }


        public Player Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Player> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Player item)
        {
            this.repo.Update(item);
        }
    }
}

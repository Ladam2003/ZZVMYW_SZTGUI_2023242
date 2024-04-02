using System;
using System.Collections.Generic;
using System.Linq;
using ZZVMYW_HFT_2023241.Models;
using ZZVMYW_HFT_2023241.Repository;

namespace ZZVMYW_HFT_2023241.Logic
{
    public class RoleLogic : IRoleLogic
    {
        IRepository<Role> repo;

        public RoleLogic(IRepository<Role> repo)
        {
            this.repo = repo;
        }

        public void Create(Role item)
        {
            if (item.RoleName.Length < 5)
            {
                throw new Exception("Less then 5 character Name does not exist!");
            }
            if (item.RoleName == "")
            {
                throw new Exception("Null RollName does not exits!");
            }
            this.repo.Create(item);
            
        }

        public void Delete(int id)
        {
            this.repo.Delete(id);
        }


        public Role Read(int id)
        {
            return this.repo.Read(id);
        }

        public IQueryable<Role> ReadAll()
        {
            return this.repo.ReadAll();
        }

        public void Update(Role item)
        {
            this.repo.Update(item);
        }
        
    }
}

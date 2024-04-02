using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZVMYW_HFT_2023241.Models;

namespace ZZVMYW_HFT_2023241.Logic
{
    public interface ICoachLogic
    {
        void Create(Coach item);
        void Delete(int id);
        Coach Read(int id);
        IQueryable<Coach> ReadAll();
        void Update(Coach item);
    }
}

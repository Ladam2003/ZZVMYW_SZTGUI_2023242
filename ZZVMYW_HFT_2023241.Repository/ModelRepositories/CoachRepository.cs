using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZVMYW_HFT_2023241.Models;

namespace ZZVMYW_HFT_2023241.Repository
{
    public class CoachRepository : Repository<Coach>, IRepository<Coach>
    {
        public CoachRepository(NFLDbContext ctx) : base(ctx)
        {
        }

        public override Coach Read(int id)
        {
            return ctx.Coaches.FirstOrDefault(t => t.CoachId == id);
        }

        public override void Update(Coach itemm)
        {
            var old = Read(itemm.CoachId);
            foreach (var prop in old.GetType().GetProperties())
            {
                if (prop.GetAccessors().FirstOrDefault(t => t.IsVirtual) == null)
                {
                    prop.SetValue(old, prop.GetValue(itemm));
                }
            }
            ctx.SaveChanges();
        }
    }
}

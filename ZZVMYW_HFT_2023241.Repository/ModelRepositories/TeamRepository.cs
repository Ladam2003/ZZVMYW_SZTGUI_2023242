﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZVMYW_HFT_2023241.Models;

namespace ZZVMYW_HFT_2023241.Repository
{
    public class TeamRepository: Repository<Team>, IRepository<Team>
    {
        public TeamRepository(NFLDbContext ctx) : base(ctx)
    {
    }

    public override Team Read(int id)
    {
        return ctx.Teams.FirstOrDefault(t => t.TeamId == id);
    }

    public override void Update(Team itemm)
    {
            var old = Read(itemm.TeamId);
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

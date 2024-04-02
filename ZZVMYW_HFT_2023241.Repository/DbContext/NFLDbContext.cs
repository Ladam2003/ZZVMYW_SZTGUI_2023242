using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Numerics;
using ZZVMYW_HFT_2023241.Models;

namespace ZZVMYW_HFT_2023241.Repository
{
    public class NFLDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Coach> Coaches { get; set; }

        public NFLDbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder
                    .UseLazyLoadingProxies()
                    .UseInMemoryDatabase("NFL");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Team>(team => team
                .HasOne(team => team.Coach)
                .WithMany(coach => coach.Teams)
                .HasForeignKey(team => team.CoachId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Player>()
                .HasMany(x => x.Teams)
                .WithMany(x => x.Players)
                .UsingEntity<Role>(
                    x => x.HasOne(x => x.Team)
                        .WithMany().HasForeignKey(x => x.TeamId).OnDelete(DeleteBehavior.Cascade),
                    x => x.HasOne(x => x.Player)
                        .WithMany().HasForeignKey(x => x.PlayerId).OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Role>()
                .HasOne(r => r.Player)
                .WithMany(player => player.Roles)
                .HasForeignKey(r => r.PlayerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Role>()
                .HasOne(r => r.Team)
                .WithMany(team => team.Roles)
                .HasForeignKey(r => r.TeamId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Team>().HasData(new Team[]
           {
               new Team("1#Hungarian Birds#Hungarian NFL Leauge#1999.03.04#Hungarian#1"),
               new Team("2#Hungarian Eagles#Hungarian NFL Leauge#2004.05.16#Hungarian#2"),
               new Team("3#Canadian Bulls#Canadian NFL Leauge#2000.08.15#Canadian#3"),
               new Team("4#East Canadian Sharks#Canadian NFL Leauge#1998.09.15#Canadian#4"),
               new Team("5#British Chickens#British NFL Leauge#2005.11.27#British#5"),
               new Team("6#Rolay Guards#British NFL Leauge#2008.01.07#British#6"),
               new Team("7#Chicago Bulls#American NFL Leauge#1976.06.13#American#7"),
               new Team("8#Dallas Sharks#American NFL Leauge#1986.07.01#American#8"),
               new Team("9#Texas Cowboys#American NFL Leauge#1992.06.27#American#9"),
               new Team("10#Los Angeles Chickens#American NFL Leauge#1966.03.15#American#10")
           });
            modelBuilder.Entity<Role>().HasData(new Role[]
            {
                new Role("1#Quarterback#QB#1#1"),
                new Role("2#Running Back#RB#1#2"),
                new Role("3#Wide Receiver#WR#2#3"),
                new Role("4#Tight End#TE#2#4"),
                new Role("5#Defensive Back#DB#3#5"),
                new Role("6#Linebacker#LB#3#6"),
                new Role("7#Defensive Lineman#DL#4#7"),
                new Role("8#Offensive Lineman#OL#4#8"),
                new Role("9#Kicker#K#5#9"),
                new Role("10#Punter#P#5#10"),
                new Role("11#Quarterback#QB#6#11"),
                new Role("12#Running Back#RB#6#12"),
                new Role("13#Wide Receiver#WR#7#13"),
                new Role("14#Tight End#TE#7#14"),
                new Role("15#Defensive Back#DB#8#15"),
                new Role("16#Linebacker#LB#8#16"),
                new Role("17#Defensive Lineman#DL#9#17"),
                new Role("18#Offensive Lineman#OL#9#18"),
                new Role("19#Kicker#K#10#19"),
                new Role("20#Punter#P#10#20")

            });
            modelBuilder.Entity<Player>().HasData(new Player[]
            {
                new Player("1#Johan Sebastian#German#42"),
                new Player("2#Michael Smith#American#25"),
                new Player("3#Sophie Johnson#Canadian#30"),
                new Player("4#Luis Rodriguez#Mexican#28"),
                new Player("5#Emily White#British#22"),
                new Player("6#Hiroshi Tanaka#Japanese#31"),
                new Player("7#Anna Müller#German#29"),
                new Player("8#Rafael Costa#Brazilian#27"),
                new Player("9#Elena Petrov#Russian#26"),
                new Player("10#Chen Wei#Chinese#32"),
                new Player("11#Mateo Fernandez#Spanish#24"),
                new Player("12#Isabella Rossi#Italian#33"),
                new Player("13#Ahmed Ali#Egyptian#23"),
                new Player("14#Olga Sokolova#Ukrainian#28"),
                new Player("15#Seo Joon-ho#South Korean#29"),
                new Player("16#Mia Patel#Indian#26"),
                new Player("17#Lucas Silva#Brazilian#27"),
                new Player("18#Aya Saito#Japanese#25"),
                new Player("19#Omar Hassan#Egyptian#30"),
                new Player("20#Lara Gomes#Portuguese#28")
            });
            modelBuilder.Entity<Coach>().HasData(new Coach[]
            {
                new Coach("1#Johny Dill#American#33"),
                new Coach("2#Eva Johnson#Canadian#40"),
                new Coach("3#Carlos Rodriguez#Mexican#45"),
                new Coach("4#Sophie White#British#38"),
                new Coach("5#Takashi Yamamoto#Japanese#50"),
                new Coach("6#Maria Schmidt#German#42"),
                new Coach("7#Ricardo Silva#Brazilian#48"),
                new Coach("8#Anna Petrova#Russian#43"),
                new Coach("9#Li Wei#Chinese#47"),
                new Coach("10#Alejandro Fernandez#Spanish#41")
            });
        }
    }
}

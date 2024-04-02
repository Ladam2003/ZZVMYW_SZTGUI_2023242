using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZZVMYW_HFT_2023241.Models;

namespace ZZVMYW_HFT_2023241.Logic
{
    public interface ITeamLogic
    {
        void Create(Team item);
        void Delete(int id);
        Team Read(int id);
        IQueryable<Team> ReadAll();
        void Update(Team item);


        //Vissza adja az átlagéletkort teamId alapján a teambe
        double? getAvgPlayersAgeByTeamId(int teamId);
        //Vissza adja a legidősebb játékost teamId alapján
        string? getTheOldestPlayerByTeamId( int teamId);

        //Ez a metódus azt keresi meg, hogy mely csapatoknak van olyan edzőjük, akik a megadott nemzetiségű csapatokhoz tartoznak,
        IEnumerable<Coach> GetCoachsByTeamNationality(string nationality);

        //TeamID alapján megszámolja hogy abba a csapatban hány játékos van
        int? GetPlayersCountByTeamId(int teamId);

        //Visszadja a legfiatalabb játékost csapatId Alapjánn
        string? getTheYoungestPlayerByTeamId(int teamId);


    }
}

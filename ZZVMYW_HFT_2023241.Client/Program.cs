using ConsoleTools;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using ZZVMYW_HFT_2023241.Models;

namespace ZZVMYW_HFT_2023241.Client
{
    internal class Program
    {
        static RestService rest;
        static void Create(string entity)
        {
            if (entity == "Player")
            {
                Console.Write("Enter Player Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter an Age: ");
                int num = int.Parse(Console.ReadLine());
                Console.Write("Enter Nationality: ");
                string nationality = Console.ReadLine();
                rest.Post(new Player() { PlayerName = name,Age = num,Nationality = nationality }, "Player");
            }
            if (entity == "Role")
            {
                Console.Write("Enter Role Name: ");
                string name = Console.ReadLine();
                string rovidites = name.Substring(0, 3).ToUpper();
                rest.Post(new Role() { RoleName = name,Abbreviation = rovidites}, "Role");
            }
            if (entity == "Coach")
            {
                Console.Write("Enter Coach Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter an Age: ");
                int num = int.Parse(Console.ReadLine());
                Console.Write("Enter Natioanlity: ");
                string nationality = Console.ReadLine();
                rest.Post(new Coach() { CoachName = name ,Age = num, Nationality = nationality  }, "Coach");
            }
            if (entity == "Team")
            {
                Console.Write("Enter Team Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter a Divison Name: ");
                string div = Console.ReadLine();
                Console.Write("Enter an Establishment Date: ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Enter Nationality: ");
                string nationality = Console.ReadLine();
                rest.Post(new Team() { TeamName = name, Division = div , EstablishmentDate = date, Nationality = nationality}, "Team");
            }

        }
        static void ReadAll(string entity)
        {
            if (entity == "Player")
            {
                List<Player> players = rest.Get<Player>("Player");
                foreach (var item in players)
                {
                    Console.WriteLine(item.PlayerId + ": " + item.PlayerName);
                }
            }
            if (entity == "Coach")
            {
                List<Coach> Coaches = rest.Get<Coach>("Coach");
                foreach (var item in Coaches)
                {
                    Console.WriteLine(item.CoachId + ": " + item.CoachName);
                }
            }
            if (entity == "Role")
            {
                List<Role> Roles = rest.Get<Role>("Role");
                foreach (var item in Roles)
                {
                    Console.WriteLine(item.RoleId + ": " + item.RoleName);
                }
            }
            if (entity == "Team")
            {
                List<Team> Teams = rest.Get<Team>("Team");
                foreach (var item in Teams)
                {
                    Console.WriteLine(item.TeamId + ": " + item.TeamName);
                }
            }
            Console.ReadLine();
        }
        static void Read(string entity)
        {
            if (entity == "Player")
            {
                Console.Write("Enter Player's id to read: ");
                int id = int.Parse(Console.ReadLine());
                Player one = rest.Get<Player>(id, "Player");
                Console.WriteLine($"The properties behind the id are: Name: {one.PlayerName}||Nationality: {one.Nationality} || Age: {one.Age}");
            }

            else if (entity == "Coach")
            {
                Console.Write("Enter Coach's id to read: ");
                int id = int.Parse(Console.ReadLine());
                Coach two = rest.Get<Coach>(id, "Coach");
                Console.WriteLine($"The properties behind the id are: Name: {two.CoachName}||Nationality: {two.Nationality} || Age: {two.Age}");
            }
            else if (entity == "Team")
            {
                Console.Write("Enter Team's id to read: ");
                int id = int.Parse(Console.ReadLine());
                Team three = rest.Get<Team>(id, "Team");
                Console.WriteLine($"The properties behind the id are: Name: {three.TeamName}||Nationality: {three.Nationality} || EstablishmentDate: {three.EstablishmentDate}");
            }
            else
            {
                Console.Write("Enter Role's id to read: ");
                int id = int.Parse(Console.ReadLine());
                Role Four = rest.Get<Role>(id, "Role");
                Console.WriteLine($"The properties behind the id are: Name: {Four.RoleName}||Abbreviation: {Four.Abbreviation}");
            }
            Console.ReadLine() ;
        }
        static void Update(string entity)
        {
            if (entity == "Player")
            {
                Console.Write("Enter Player's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Player one = rest.Get<Player>(id, "Player");
                Console.Write($"New name [old: {one.PlayerName}]: ");
                string name = Console.ReadLine();
                one.PlayerName = name;
                rest.Put(one, "Player");
            }
            if (entity == "Coach")
            {
                Console.Write("Enter Coach's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Coach one = rest.Get<Coach>(id, "Coach");
                Console.Write($"New name [old: {one.CoachName}]: ");
                string name = Console.ReadLine();
                one.CoachName = name;
                rest.Put(one, "Coach");
            }
            if (entity == "Team")
            {
                Console.Write("Enter Team's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Team one = rest.Get<Team>(id, "Team");
                Console.Write($"New name [old: {one.TeamName}]: ");
                string name = Console.ReadLine();
                one.TeamName = name;
                rest.Put(one, "Team");
            }
            if (entity == "Role")
            {
                Console.Write("Enter Role's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Role one = rest.Get<Role>(id, "Role");
                Console.Write($"New name [old: {one.RoleName}]: ");
                string name = Console.ReadLine();
                one.RoleName = name;
                rest.Put(one, "Role");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Player")
            {
                Console.Write("Enter Players's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Player");
            }
            if (entity == "Coach")
            {
                Console.Write("Enter Coach's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Coach");
            }
            if (entity == "Team")
            {
                Console.Write("Enter Team's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Team");
            }
            if (entity == "Role")
            {
                Console.Write("Enter Role's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "Role");
            }
        }

        static void getAvgPlayersAgeByTeamId()
        {
            Console.Write("Enter Team's id: ");
            int teamId = int.Parse(Console.ReadLine());

            try
            {
                var averageAge = rest.GetAvgPlayersAgeByTeamId(teamId);
                if (averageAge.HasValue)
                {
                    Console.WriteLine($"Average Players Age for Team {teamId}: {averageAge}");
                }
                else
                {
                    Console.WriteLine($"No players found for Team {teamId}.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadLine();
        }

        static void getTheOldestPlayerByTeamId()
        {
            Console.Write("Enter Team's id: ");
            int teamId = int.Parse(Console.ReadLine());

            try
            {
                var oldestPlayerName = rest.getTheOldestPlayerByTeamId(teamId);
                if (!string.IsNullOrEmpty(oldestPlayerName))
                {
                    Console.WriteLine($"The oldest player in the team is: {oldestPlayerName}");
                }
                else
                {
                    Console.WriteLine($"No players found for Team {teamId}.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadLine();
        }

        static void GetCoachesByTeamNationality()
        {
            Console.Write("Enter Team's nationality: ");
            string nationality = Console.ReadLine();

            try
            {
                var coaches = rest.GetCoachesByTeamNationality(nationality);
                if (coaches != null && coaches.Any())
                {
                    Console.WriteLine($"Coaches affiliated with {nationality} team:");
                    foreach (var coach in coaches)
                    {
                        Console.WriteLine($"{coach.CoachId}: {coach.CoachName}");
                    }
                }
                else
                {
                    Console.WriteLine($"No coaches found with nationality '{nationality}'.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadLine();
        }


        static void GetPlayersCountByTeamId()
        {
            Console.Write("Enter Team's id: ");
            int teamId = int.Parse(Console.ReadLine());

            try
            {
                var playersCount = rest.GetPlayersCountByTeamId(teamId);
                if (playersCount.HasValue)
                {
                    Console.WriteLine($"Number of players for Team: {playersCount}");
                }
                else
                {
                    Console.WriteLine($"No team found for Team {teamId}.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadLine();
        }

        static void GetTheYoungestPlayerByTeamId()
        {
            Console.Write("Enter Team's id: ");
            int teamId = int.Parse(Console.ReadLine());

            try
            {
                var youngestPlayerName = rest.GetTheYoungestPlayerByTeamId(teamId);
                if (!string.IsNullOrEmpty(youngestPlayerName))
                {
                    Console.WriteLine($"The youngest player for Team is: {youngestPlayerName}");
                }
                else
                {
                    Console.WriteLine($"No players found for Team {teamId}.");
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadLine();
        }
        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:57195/", "swagger");

            var playerSubMenu = new ConsoleMenu(args, level: 1)
                .Add("ReadAll", () => ReadAll("Player"))
                .Add("Read", () => Read("Player"))
                .Add("Create", () => Create("Player"))
                .Add("Delete", () => Delete("Player"))
                .Add("Update", () => Update("Player"))
                .Add("Exit", ConsoleMenu.Close);

            var roleSubMenu = new ConsoleMenu(args, level: 1)
                .Add("ReadAll", () => ReadAll("Role"))
                .Add("Read", () => Read("Role"))
                .Add("Create", () => Create("Role"))
                .Add("Delete", () => Delete("Role"))
                .Add("Update", () => Update("Role"))
                .Add("Exit", ConsoleMenu.Close);

            var coachSubMenu = new ConsoleMenu(args, level: 1)
                .Add("ReadAll", () => ReadAll("Coach"))
                .Add("Read", () => Read("Coach"))
                .Add("Create", () => Create("Coach"))
                .Add("Delete", () => Delete("Coach"))
                .Add("Update", () => Update("Coach"))
                .Add("Exit", ConsoleMenu.Close);

            var movieSubMenu = new ConsoleMenu(args, level: 1)
                .Add("ReadAll", () => ReadAll("Team"))
                .Add("Read", () => Read("Team"))
                .Add("Create", () => Create("Team"))
                .Add("Delete", () => Delete("Team"))
                .Add("Update", () => Update("Team"))
                .Add("Exit", ConsoleMenu.Close);
            var NonCrudMenu = new ConsoleMenu(args, level: 1)
                .Add("getAvgPlayersAgeByTeamId", () => getAvgPlayersAgeByTeamId())
                .Add("getTheOldestPlayerByTeamId", () => getTheOldestPlayerByTeamId())
                .Add("GetCoachesByTeamNationality", () => GetCoachesByTeamNationality())
                .Add("GetPlayersCountByTeamId", () => GetPlayersCountByTeamId())
                .Add("GetTheYoungestPlayerByTeamId",() => GetTheYoungestPlayerByTeamId())
                .Add("Exit", ConsoleMenu.Close);
            { }

            var menu = new ConsoleMenu(args, level: 0)
                .Add("Teams", () => movieSubMenu.Show())
                .Add("Players", () => playerSubMenu.Show())
                .Add("Roles", () => roleSubMenu.Show())
                .Add("Coaches", () => coachSubMenu.Show())
                .Add("NonCrudMethods", () => NonCrudMenu.Show())
                .Add("Exit", ConsoleMenu.Close);


            menu.Show();

        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using TcgTournament.EntityFramework;
using TcgTournament.EntityFramework.EfModels;
using TcgTournament.Models;
using System.Collections.Generic;

namespace TestTcgDataBase
{
    [TestClass]
    public class UnitTest1
    {
        EFTournamentMapper mapper;

       

        [TestInitialize]
        public void Setup()
        {
            mapper = new EFTournamentMapper("TcgTest");
            Player p = new Player("user");
            Player p2 = new Player("u2");
            Player p3 = new Player("u3");
            Player p4 = new Player("u4");
            mapper.CreatePlayer(p);
            mapper.CreatePlayer(p2);
            mapper.CreatePlayer(p3);
            mapper.CreatePlayer(p4);
            List<Player> players = new List<Player>();
            players.Add(p);
            players.Add(p2);
            players.Add(p3);
            players.Add(p4);
            mapper.CreateTournament();
            mapper.AddAllPlayerInTournament(players);
            Match m = new Match(p, p2);
            Match m2 = new Match(p3, p4);
            Match m3 = new Match(p, p3);
            Match m4 = new Match(p2, p4);
            m.Result[p] = 2;
            m.Result[p2] = 0;
            m2.Result[p3] = 2;
            m2.Result[p4] = 1;
            m3.Result[p] = 2;
            m3.Result[p3] = 0;
            m4.Result[p2] = 2;
            m4.Result[p4] = 0;

            mapper.SaveMatch(m);
            mapper.SaveMatch(m2);
            mapper.SaveMatch(m3);
            mapper.SaveMatch(m4);

        }

        [TestMethod]
        public void TestGetAllPl()
        {
            Player p = new Player("user");
            List<Player> players = mapper.GetAllPlayers();
            Assert.IsTrue(players.Count == 4);
            
        }
        [TestMethod]
        public void TestGetVAndD()
        {
            Player p = new Player("user");
            int[] i=mapper.TotalVictoriesAndDefeat(p);
            Assert.IsTrue(i[0] == 2 && i[1] == 0);
        }
        [TestMethod]
        public void testVAndDPlayers()
        {
            Player p = new Player("user");
            Player p2 = new Player("u2");
            int[] i = mapper.GetVictoriesDefeatVS1(p, p2);
            Assert.IsTrue(i[0] == 1 && i[1] == 0);
            i = mapper.GetVictoriesDefeatVS1(p2, p);
            Assert.IsTrue(i[0] == 0 && i[1] == 1);
        }
        [TestMethod]
        public void testGetPlausiblePosition()
        {
            Player p = new Player("user");
            Player p2 = new Player("u2");
            Player p3 = new Player("u3");
            Player p4 = new Player("u4");
            List<Player> players = new List<Player>();
    
            players.Add(p2);
            players.Add(p3);
            players.Add(p4);

            int i=mapper.PossiblePosition(p, players);
            Assert.IsTrue(i == 1);

        }

        [TestCleanup]
        public void cleanup()
        {
            mapper.emptyDb();
            
        }
    }
}

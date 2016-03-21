using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using TcgTournament.EntityFramework;
using TcgTournament.EntityFramework.EfModels;
using TcgTournament.Models;

namespace TestTcgDataBase
{
    [TestClass]
    public class UnitTest1
    {
        EFTournamentMapper mapper;

       
        [ClassInitialize]
        public static void SetupDataBase(TestContext context)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<EFDataContext>());
        }

        /// <summary>
        /// Crée un contexte, que l'on peut voir comme une session d'échange.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            mapper = new EFTournamentMapper("TcgTest");
           
        }
        [TestMethod]
        public void testingAddPlayer()
        {
            Player p = new Player("user");
            mapper.CreatePlayer(p);
            
        }
    }
}

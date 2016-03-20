using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Entity;
using TcgTournament.EntityFramework;
using TcgTournament.EntityFramework.EfModels;

namespace TestTcgDataBase
{
    [TestClass]
    public class UnitTest1
    {
        EFDataContext contexte;

       
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
            contexte = new EFDataContext("TcgTest");
           
        }
        [TestMethod]
        public void testingCreationPlayersTable()
        {
            contexte.Players.Add(new DbPlayer("Mininours"));
            contexte.SaveChanges();        
        }
    }
}

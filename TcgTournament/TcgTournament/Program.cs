using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcgTournament.Models;
using TcgTournament.Controlers;
using TcgTournament.EntityFramework;

namespace TcgTournament
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
           Tournament tournament = new Tournament();
            EFTournamentMapper mapper = new EFTournamentMapper("TCGDataBase");
           // TournamentControler tournamentControler = new TournamentControler(tournament);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // mapper.CreateTournament();
            Application.Run(new Players(new PlayersController(tournament,mapper)));
        }
    }
}

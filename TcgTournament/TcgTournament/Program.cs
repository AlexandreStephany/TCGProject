using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TcgTournament.Models;
using TcgTournament.Controlers;

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
            LaunchingControler launcherControler = new LaunchingControler(tournament);
            TournamentControler tournamentControler = new TournamentControler(tournament);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

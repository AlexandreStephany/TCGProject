﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcgTournament.EntityFramework.EfModels
{
    [Serializable]
    public class DbTournament
    {
        long idTournament;
        DateTime Date;
        List<DbPlayer> players;

        public long IdTournament
        {
            get
            {
                return idTournament;
            }

            set
            {
                idTournament = value;
            }
        }

        public DateTime Date1
        {
            get
            {
                return Date;
            }

            set
            {
                Date = value;
            }
        }

        public List<DbPlayer> Players
        {
            get
            {
                return players;
            }

            set
            {
                players = value;
            }
        }

        public DbTournament()
        {
            IdTournament = 0;
            Date1 = DateTime.Now;
            Players = new List<DbPlayer>();
        }
    }
}
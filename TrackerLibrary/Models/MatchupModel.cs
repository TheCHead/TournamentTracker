using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Represents teams competing in particular matchup.
        /// </summary>
        public List<MatchupEntryModel> Entries { get; set; } = new List<MatchupEntryModel>();

        /// <summary>
        /// Winner of the particular matchup.
        /// </summary>
        public TeamModel Winner { get; set; }

        /// <summary>
        /// The number of the round that the matchup takes place in.
        /// </summary>
        public int MatchupRound { get; set; }
    }
}

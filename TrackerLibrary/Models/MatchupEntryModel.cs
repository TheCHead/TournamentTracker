using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class MatchupEntryModel
    {
        public int Id { get; set; }
        /// <summary>
        /// Represents one team in the matchup.
        /// </summary>
        public TeamModel TeamCompeting { get; set; }

        /// <summary>
        /// Score of this team.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// The matchup that this team came from.
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }
    }
}

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
        /// ID of competing team from database to find competing team
        /// </summary>
        public int TeamCompetingId { get; set; }

        /// <summary>
        /// Score of this team.
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// The matchup that this team came from.
        /// </summary>
        public MatchupModel ParentMatchup { get; set; }

        /// <summary>
        /// Id of the parent matchup form database to find the parent matchup.  
        /// </summary>
        public int ParentMatchupId { get; set; }
    }
}

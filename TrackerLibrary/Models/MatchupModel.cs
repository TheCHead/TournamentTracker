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
        /// Id of the winner from the database to be used to identify the winner.
        /// </summary>
        public int WinnerId { get; set; }


        /// <summary>
        /// Winner of the particular matchup.
        /// </summary>
        public TeamModel Winner { get; set; }

        /// <summary>
        /// The number of the round that the matchup takes place in.
        /// </summary>
        public int MatchupRound { get; set; }

        public string DisplayName
        {
            get
            {
                string output = "";
                foreach (MatchupEntryModel me in Entries)
                {
                    if (me.TeamCompeting != null)
                    {
                        if (output.Length == 0)
                        {
                            output = me.TeamCompeting.TeamName;
                        }
                        else
                        {
                            output += $" vs. { me.TeamCompeting.TeamName }";
                        } 
                    }
                    else
                    {
                        output = "Matchup Not Yet Determined";
                        break;
                    }
                }
                return output;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerLibrary
{
    public static class TournamentLogic
    {
        // order list of teams randomly
        // check if its big enough, if not - add byes
        // create first round of matchups
        // create every round after that

        public static void CreateRounds(TournamentModel model)
        {
            List<TeamModel> randomizedTeams = RandomizeTeamOrder(model.EnteredTeams);
            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int byes = NumberOfByes(rounds, randomizedTeams.Count);

            model.Rounds.Add(CreateFirstRound(byes, randomizedTeams));

            CreateOtherRounds(model, rounds);

        }

        public static void UpdateTournamentResults(TournamentModel tournament)
        {
            int startingRound = tournament.GetCurrentRound();

            List<MatchupModel> toScore = new List<MatchupModel>();

            foreach (List<MatchupModel> round in tournament.Rounds)
            {
                foreach (MatchupModel rm in round)
                {
                    if (rm.Winner == null && (rm.Entries.Any(x => x.Score != 0) || rm.Entries.Count == 1))
                    {
                        toScore.Add(rm);
                    }
                }
            }

            MarkWinnersInMatchup(toScore);

            AdvanceWinners(toScore, tournament);

            toScore.ForEach(x => GlobalConfig.Connection.UpdateMatchup(x));

            int endingRound = tournament.GetCurrentRound();

            if (endingRound > startingRound)
            {
                tournament.AlertUsersToNextRound();
            }
        }

        public static void AlertUsersToNextRound(this TournamentModel tournament)
        {
            int currentRoundNumber = tournament.GetCurrentRound();

            List<MatchupModel> currentRound = tournament.Rounds.Where(x => x.First().MatchupRound == currentRoundNumber).First();

            foreach (MatchupModel m in currentRound)
            {
                foreach (MatchupEntryModel me in m.Entries)
                {
                    foreach (PersonModel p in me.TeamCompeting.TeamMembers)
                    {
                        AlertPersonToNextRound(p, me.TeamCompeting.TeamName, m.Entries.Where(x => x.TeamCompeting != me.TeamCompeting).FirstOrDefault());
                    }
                }
            }
        }

        private static void AlertPersonToNextRound(PersonModel p, string teamName, MatchupEntryModel competitor)
        {
            if (p.EmailAddress.Length == 0)
            {
                return;
            }

            string toAddress = "";
            string subject = "";
            StringBuilder body = new StringBuilder();


            if (competitor != null)
            {
                subject = $"You have a new matchup with { competitor.TeamCompeting.TeamName }.";

                body.AppendLine("<h1>You have a new matchup</h1>");
                body.Append("<strong>Competitor: </strong>");
                body.Append(competitor.TeamCompeting.TeamName);
                body.AppendLine();
                body.AppendLine();
                body.AppendLine("Prepare yourself.");
                body.AppendLine("~Tournament Tracker");
            }
            else
            {
                subject = "You have a bye week this round.";

                body.Append("Enjoy your round off!");
                body.AppendLine("~Tournament Tracker");
            }

            toAddress = p.EmailAddress;


            EmailLogic.SendEmail(toAddress, subject, body.ToString());
        }

        private static void MarkWinnersInMatchup(List<MatchupModel> matchups)
        {
            //greater or lesser 
            string greaterWins = ConfigurationManager.AppSettings["greaterWins"];

            foreach (MatchupModel m in matchups)
            {
                // for bye week entry
                if (m.Entries.Count == 1)
                {
                    m.Winner = m.Entries[0].TeamCompeting;
                    continue;
                }

                // 0 means low score wins
                if (greaterWins == "0")
                {
                    if (m.Entries[0].Score <m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                    }

                    else if (m.Entries[1].Score < m.Entries[0].Score)
                    {
                        m.Winner = m.Entries[1].TeamCompeting;
                    }

                    else
                    {
                        throw new Exception("Ties are not allowed.");
                    }
                }
                
                else
                {
                    // 1 means high score wins
                    if (m.Entries[0].Score > m.Entries[1].Score)
                    {
                        m.Winner = m.Entries[0].TeamCompeting;
                    }

                    else if (m.Entries[1].Score > m.Entries[0].Score)
                    {
                        m.Winner = m.Entries[1].TeamCompeting;
                    }

                    else
                    {
                        throw new Exception("Ties are not allowed.");
                    }
                }
            }

        }

        private static void AdvanceWinners(List<MatchupModel> matchups, TournamentModel tournament)
        {

            foreach (MatchupModel m in matchups)
            {
                //make entry move to the next round after the win
                foreach (List<MatchupModel> round in tournament.Rounds)
                {
                    foreach (MatchupModel rm in round)
                    {
                        foreach (MatchupEntryModel mem in rm.Entries)
                        {
                            if (mem.ParentMatchup != null)
                            {
                                if (mem.ParentMatchup.Id == m.Id)
                                {
                                    mem.TeamCompeting = m.Winner;
                                    GlobalConfig.Connection.UpdateMatchup(rm);
                                }
                            }
                        }
                    }
                }
            }

        }

        private static int GetCurrentRound(this TournamentModel tournament)
        {
            int output = 1;

            foreach (List<MatchupModel> round in tournament.Rounds)
            {
                if (round.All(x => x.Winner != null))
                {
                    output++;
                }
            }

            return output;
        }

        private static void CreateOtherRounds(TournamentModel model, int rounds)
        {
            int round = 2;
            List<MatchupModel> previousRound = model.Rounds[0];
            List<MatchupModel> currRound = new List<MatchupModel>();
            MatchupModel currMatchup = new MatchupModel();

            while (round <= rounds)
            {
                foreach(MatchupModel match in previousRound)
                {
                    currMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = match });

                    if (currMatchup.Entries.Count > 1)
                    {
                        currMatchup.MatchupRound = round;
                        currRound.Add(currMatchup);
                        currMatchup = new MatchupModel();
                    }
                }

                model.Rounds.Add(currRound);
                
                previousRound = currRound;
                currRound = new List<MatchupModel>();
                round++;
            }
        }

        private static List<MatchupModel> CreateFirstRound(int byes, List<TeamModel> teams)
        {
            List<MatchupModel> firstRound = new List<MatchupModel>();
            MatchupModel curr = new MatchupModel();

            foreach (TeamModel team in teams)
            {
                curr.Entries.Add(new MatchupEntryModel { TeamCompeting = team });

                if (byes > 0 || curr.Entries.Count > 1)
                {
                    curr.MatchupRound = 1;
                    firstRound.Add(curr);
                    curr = new MatchupModel();

                    if (byes > 0)
                    {
                        byes--;
                    }
                }
            }

            return firstRound;
        }

        private static int NumberOfByes(int rounds, int teamCount)
        {
            int output = 0;
            int totalTeams = 1;

            for (int i = 1; i <= rounds; i++)
            {
                totalTeams *= 2;
            }

            output = totalTeams - teamCount;

            return output;
        }

        private static int FindNumberOfRounds(int teamCount)
        {
            int output = 1;
            int val = 2;
            while (val < teamCount)
            {
                output++;
                val *= 2;
            }

            return output;
        }

        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> teams)
        {
            return teams.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}

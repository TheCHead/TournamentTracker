using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class TournamentDashboardForm : Form
    {
        List<TournamentModel> tournaments = GlobalConfig.Connection.GetTournament_All();
        

        public TournamentDashboardForm()
        {
            InitializeComponent();

            WireUpLists();
        }

        private void WireUpLists()
        {
            existingTournamentsDropdown.DataSource = tournaments;
            existingTournamentsDropdown.DisplayMember = "TournamentName";
        }

        private void createNewTournamentLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!System.IO.Directory.Exists($"{ConfigurationManager.AppSettings["filePath"]}"))
            {
                System.IO.Directory.CreateDirectory($"{ConfigurationManager.AppSettings["filePath"]}");
            }
            CreateTournamentForm frm = new CreateTournamentForm();
            frm.Show();
        }

        private void loadTournamentButton_Click(object sender, EventArgs e)
        {
            TournamentModel tm = (TournamentModel)existingTournamentsDropdown.SelectedItem;
            if (tm == null) return;

            tm.OnTournamentComplete += Tm_OnTournamentComplete;

            TournamentViewerForm frm = new TournamentViewerForm(tm);
            frm.Show();
        }

        private void Tm_OnTournamentComplete(object sender, DateTime e)
        {
            RewireTournamentList();
        }

        private void RewireTournamentList()
        {
            tournaments = GlobalConfig.Connection.GetTournament_All();
            existingTournamentsDropdown.DataSource = tournaments;
            existingTournamentsDropdown.DisplayMember = "TournamentName";
        }
    }
}

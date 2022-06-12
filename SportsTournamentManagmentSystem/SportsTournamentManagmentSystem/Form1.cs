using BusinessLogic;
using BusinessLogicLayer;
using DataAccessLayer;
using SportsTournamentManagmentSystem;
using Entities;

namespace SportsTournamentManagmentSystem
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cmbTournamentSystem.DataSource = TournamentSystem.Systems;
            cmbSportType.DataSource = SportType.SportTypes;
            tm = new TournamentManager(new TournamnentDBManager(), new TournamnentDBManager(), new TournamnentDBManager());
            gm = new GameManager(new GameDBManager());
            GetTournaments();
        }

        TournamentManager tm;
        GameManager gm;


        //TOURNAMENT MANAGMENT(CRUD)//
        private void btnCreateTournament_Click(object sender, EventArgs e)
        {
            try
            {
                //The start date of the torunament shoul be at least two weeks from now so people have at least one week to register
                if (dtpStartDate.Value.CompareTo(DateTime.Today.AddDays(14)) >= 0 || dtpStartDate.Value.CompareTo(dtpEndDate.Value) <= 0)
                {
                    if (numMaxPlayers.Value >= 2 || numMinPlayers.Value >= 2 || numMaxPlayers.Value >= numMinPlayers.Value)
                    {
                        tm.Add(new Tournament(tm.GetId(), tbTitle.Text, Status.open, new TournamentInfo((SportType)cmbSportType.SelectedItem, rtbDescription.Text, dtpStartDate.Value, dtpEndDate.Value, Convert.ToInt32(numMinPlayers.Value), Convert.ToInt32(numMaxPlayers.Value), tbLocation.Text, (TournamentSystem)cmbTournamentSystem.SelectedItem)));
                        MessageBox.Show("Tournament addeed successfully!");
                        GetTournaments();
                    }
                    else
                    {
                        MessageBox.Show("The number of players is invalid!");
                    }
                }
                else
                {
                    MessageBox.Show("The date you entered is invalid!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetTournaments()
        {
            lbEditTournaments.Items.Clear();
            lbTournaments.Items.Clear();

            foreach (Tournament t in tm.Tournaments)
            {
                lbEditTournaments.Items.Add(t);
                lbTournaments.Items.Add(t);
            }

        }


        Tournament t;

        private void lbEditTournaments_SelectedIndexChanged(object sender, EventArgs e)
        {
            t = (Tournament)lbEditTournaments.SelectedItem;

            if (t.Status == Status.open || t.Status == Status.closed || t.Status == Status.canceled)
            {
                tm.GetTournamentInfo(t);
            }
            else if (t.Status == Status.scheduled || t.Status == Status.finished)
            {
                tm.GetTournamentInfo(t);
            }

            if (t.Status == Status.finished || t.Status == Status.canceled)
            {
                btnEditTournament.Enabled = false;
            }
            else if (t.Status == Status.open)
            {
                btnEditTournament.Enabled = true;
            }
            else if (t.Status == Status.scheduled || t.Status == Status.closed)
            {
                btnEditTournament.Enabled = true;
            }

            tbTitle.Text = t.Title;
            cmbSportType.Text = t.Info.Sport.ToString();
            tbLocation.Text = t.Info.Location;
            rtbDescription.Text = t.Info.Description;
            dtpStartDate.Value = t.Info.StartDate;
            dtpEndDate.Value = t.Info.EndDate;
            numMaxPlayers.Value = t.Info.MaxPlayers;
            numMinPlayers.Value = t.Info.MinPlayers;
            cmbTournamentSystem.SelectedItem = t.Info.System;
            cmbTournamentSystem.Text = t.Info.System.ToString();
        }

        private void btnEditTournament_Click(object sender, EventArgs e)
        {
            try
            {
                if (t.Status != Status.canceled || t.Status != Status.finished)
                {
                    Tournament tr = null;

                    tr = new Tournament(t.Id, tbTitle.Text, t.Status, new TournamentInfo(t.Info.Sport, rtbDescription.Text, dtpStartDate.Value.ToString("yyyy-MM-dd"), dtpEndDate.Value.ToString("yyyy-MM-dd"), t.Info.MinPlayers, t.Info.MaxPlayers, tbLocation.Text, t.Info.System));

                    tm.Update(t, tr);
                    MessageBox.Show("Tournament info updated successfully!");
                    GetTournaments();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeleteTournament_Click(object sender, EventArgs e)
        {
            try
            {
                //A tournament can only be delted if it is stil open for registering and no people have registered
                if (t.Status == Status.open && t.Users.Count < 1)
                {
                    //asking for confirmation for the cancelation
                    var result = MessageBox.Show("Are you sure you want to delete the selected tournament", "Are you sure?", MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Yes)
                    {
                        tm.Delete(t);
                        MessageBox.Show("Tournament was successfully deleted!");
                        GetTournaments();
                    }
                }
                else
                {
                    MessageBox.Show("Tournament can't be deleted!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelTournament_Click(object sender, EventArgs e)
        {
            try
            {
                if (t.Status != Status.canceled || t.Status != Status.finished)
                {
                    //asking for confirmation for the cancelation
                    var result = MessageBox.Show("Are you sure you want to camcel the selected tournament", "Are you sure?", MessageBoxButtons.YesNoCancel);

                    if (result == DialogResult.Yes)
                    {
                        tm.Cancel(t);
                        MessageBox.Show("Tournament canceled successully!");
                        GetTournaments();
                    }
                }
                else
                {
                    MessageBox.Show("The selected tournament can't be canceled!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }






        //TOURNAMENT GAME MANAGEMENT//
        private void lbTournaments_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbGames.Items.Clear();
            t = (Tournament)lbTournaments.SelectedItem;
            btmSaveResult.Enabled = false;

            if (t.Status == Status.open || t.Status == Status.closed)
            {
                tm.GetTournamentInfo(t);

                if (t.Status == Status.open)
                {
                    lbGames.Items.Add("The tournament is currently still open for registering");
                    btnGenerateSchedule.Enabled = false;
                }
                else
                {
                    lbGames.Items.Add("The tournament is closed for registering");
                    btnGenerateSchedule.Enabled = true;
                }
            }
            else if (t.Status == Status.scheduled || t.Status == Status.finished)
            {
                tm.GetTournamentInfo(t);
                btnGenerateSchedule.Enabled = false;
                GetGames();
            }
            else
            {
                lbGames.Items.Add("The tournament has been canceled");
            }

            GetTournaments();
        }

        private void GetGames()
        {
            lbGames.Items.Clear();

            foreach (var item in t.Games)
            {
                lbGames.Items.Add(item);
            }
        }


        private void btnGenerateSchedule_Click(object sender, EventArgs e)
        {
            try
            {
                if (t.Status == Status.closed)
                {
                    t.Info.System.GetGames(t);
                    gm.AddGames(t);
                    GetGames();
                }
                else
                {
                    MessageBox.Show("A schedule can't be generated for the selected tournament!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btmSaveResult_Click(object sender, EventArgs e)
        {
            int result1 = Convert.ToInt32(tbResultPlayerOne.Text);
            int result2 = Convert.ToInt32(tbResultPlayerTwo.Text);

            if (t.Status != Status.scheduled)
            {
                MessageBox.Show("You can't enter any results for this tournament!");
            }
            else if (result1 < 0 || result2 < 0)
            {
                MessageBox.Show("The results you entered are invalid!");
            }
            else
            {
                if (lbGames.SelectedIndex == -1)
                {
                    MessageBox.Show("Choose a game!");
                }
                else if (g.PlayerTwoScore != 0 || g.PlayerOneScore != 0)
                {
                    MessageBox.Show("You can't edit the points of the players!");
                }
                else
                {
                    try
                    {
                        gm.SaveResults(t, g, result1, result2);
                        MessageBox.Show("Results successfully saved");

                        GetGames();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

            }
        }

        Game g;

        private void lbGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            g = (Game)lbGames.SelectedItem;

            if (g.PlayerOne.User == null || g.PlayerTwo.User == null)
            {
                MessageBox.Show("You can't enter results for this game");
            }
            else
            {
                lblPlayerOne.Text = g.PlayerOne.User.Id.ToString();
                lblPlayerTwo.Text = g.PlayerTwo.User.Id.ToString();

                if (g.PlayerOneScore != 0 && g.PlayerTwoScore != 0)
                {
                    tbResultPlayerOne.Text = g.PlayerOneScore.ToString();
                    tbResultPlayerTwo.Text = g.PlayerTwoScore.ToString();
                    btmSaveResult.Enabled = false;
                }
                else
                {
                    tbResultPlayerOne.Text = "";
                    tbResultPlayerTwo.Text = "";
                    btmSaveResult.Enabled = true;
                }
            }



        }



        //FILTERING//

        private void Filter(ListBox lb, Status status)
        {
            lb.Items.Clear();

            //Filtering the tournaments according to their status
            foreach (Tournament t in tm.Tournaments)
            {
                if (t.Status == status)
                {
                    lb.Items.Add(t);
                }
            }
            NoResults(lb);
        }

        private void NoResults(ListBox lb)
        {
            if (lb.Items.Count == 0)
            {
                lb.Items.Add("There are no items");
            }
        }

        private void rbOpen_CheckedChanged(object sender, EventArgs e)
        {
            Filter(lbEditTournaments, Status.open);
        }

        private void rbClosed_CheckedChanged(object sender, EventArgs e)
        {
            Filter(lbEditTournaments, Status.closed);
        }

        private void rbCanceled_CheckedChanged(object sender, EventArgs e)
        {
            Filter(lbEditTournaments, Status.canceled);
        }

        private void rbScheduled_CheckedChanged(object sender, EventArgs e)
        {
            Filter(lbEditTournaments, Status.scheduled);
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            GetTournaments();
            NoResults(lbEditTournaments);
        }


        private void rbtnOpen_CheckedChanged(object sender, EventArgs e)
        {
            Filter(lbTournaments, Status.open);
        }

        private void rbtnClosed_CheckedChanged(object sender, EventArgs e)
        {
            Filter(lbTournaments, Status.closed);
        }

        private void rbtnCamceled_CheckedChanged(object sender, EventArgs e)
        {
            Filter(lbTournaments, Status.canceled);
        }

        private void rbtnScheduled_CheckedChanged(object sender, EventArgs e)
        {
            Filter(lbTournaments, Status.scheduled);
        }

        private void rbtnAll_CheckedChanged(object sender, EventArgs e)
        {
            GetTournaments();
            NoResults(lbTournaments);
        }


        //Case insensitive filtering according to the given id or partial title
        private void btnFilterById_Click(object sender, EventArgs e)
        {
            lbEditTournaments.Items.Clear();
            lbEditTournaments.Items.Add(tm.GetTournamentByID(Convert.ToInt32(tbTournamentId.Text)));
        }

        private void btnGetTournamentByTitle_Click(object sender, EventArgs e)
        {
            lbEditTournaments.Items.Clear();

            foreach (var item in tm.GetTournamentsByTitle(tbTournamentTitle.Text))
            {
                lbEditTournaments.Items.Add(item);
            }
        }
        private void btnCloseTournament_Click_1(object sender, EventArgs e)
        {
            if (t.Info.StartDate.CompareTo(DateTime.Today.AddDays(7)) > 0)
            {
                MessageBox.Show("It is too early to close the tournament!");
            }
            else
            {
                tm.CloseTournament(t);
            }
        }

        //I'll fix that.. some day

        //private void SetTimer()
        //{
        //    var start = TimeSpan.Zero;
        //    var period = TimeSpan.FromHours(6);

        //    var timer = new System.Threading.Timer((e) =>
        //    {
        //        tm.CloseTournament();
        //    }, null, start, period);
        //}
    }


}
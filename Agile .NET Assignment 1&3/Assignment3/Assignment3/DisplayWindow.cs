using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment3
{
    public partial class DisplayWindow : Form
    {
        //references to both teams in the game
        private Team team1 = new Team();
        private Team team2 = new Team();

        //represents the current round
        private int round = 1;

        public DisplayWindow()
        {
            InitializeComponent();
        }

        //Sets all variables to zero upon game start, updates display with team info, sets the windows location be be top the right of the input window
        private void DisplayWindow_Load(object sender, EventArgs e)
        {
            team1.resetBonus();
            team2.resetBonus();

            team1.resetScore();
            team2.resetScore();

            updateDisplay();

            Location = new Point(InputWindow.ActiveForm.Location.X + InputWindow.ActiveForm.Width, InputWindow.ActiveForm.Location.Y);

            this.FormClosing += new FormClosingEventHandler(this.DisplayWindow_FormClosing);
        }

        //returns team 1
        public Team getTeam1()
        {
            return team1;
        }

        //returns team 2
        public Team getTeam2()
        {
            return team2;
        }

        public void setTeam1(Team newTeam1)
        {
            this.team1 = newTeam1;
        }

        public void setTeam2(Team newTeam2)
        {
            this.team2 = newTeam2;
        }

        //Updates all displays to the curerent information
        public void updateDisplay()
        {
            Team1Labeld.Text = team1.getName();
            Team2Labeld.Text = team2.getName();

            Team1aD.Text = team1.getMembers(0).ToString();
            Team1bD.Text = team1.getMembers(1).ToString();
            Team1cD.Text = team1.getMembers(2).ToString();
            Team1dD.Text = team1.getMembers(3).ToString();
            Team1eD.Text = team1.getMembers(4).ToString();

            Team2aD.Text = team2.getMembers(0).ToString();
            Team2bD.Text = team2.getMembers(1).ToString();
            Team2cD.Text = team2.getMembers(2).ToString();
            Team2dD.Text = team2.getMembers(3).ToString();
            Team2eD.Text = team2.getMembers(4).ToString();

            Team1ScoreD.Text = team1.getScore().ToString();
            Team2ScoreD.Text = team2.getScore().ToString();

            Team1BonusD.Text = team1.getBonus().ToString();
            Team2BonusD.Text = team2.getBonus().ToString();


            roundDisplay.Text = round.ToString();

            Team1aD.ForeColor = Color.White;
            Team1bD.ForeColor = Color.White;
            Team1cD.ForeColor = Color.White;
            Team1dD.ForeColor = Color.White;
            Team1eD.ForeColor = Color.White;

            Team2aD.ForeColor = Color.White;
            Team2bD.ForeColor = Color.White;
            Team2cD.ForeColor = Color.White;
            Team2dD.ForeColor = Color.White;
            Team2eD.ForeColor = Color.White;

            for (int i = 0; i < 5; i++)
            {
                if (team1.getFouls(i) > 0 && team1.getFouls(i) < 3)
                {
                    if (i == 0)
                    {
                        Team1aD.ForeColor = Color.Yellow;
                    }
                    else if (i == 1)
                    {
                        Team1bD.ForeColor = Color.Yellow;
                    }
                    else if (i == 2)
                    {
                        Team1cD.ForeColor = Color.Yellow;
                    }
                    else if (i == 3)
                    {
                        Team1dD.ForeColor = Color.Yellow;
                    }
                    else if (i == 4)
                    {
                        Team1eD.ForeColor = Color.Yellow;
                    }
                }
                else if (team1.getFouls(i) > 2)
                {
                    if (i == 0)
                    {
                        Team1aD.ForeColor = Color.Red;
                    }
                    else if (i == 1)
                    {
                        Team1bD.ForeColor = Color.Red;
                    }
                    else if (i == 2)
                    {
                        Team1cD.ForeColor = Color.Red;
                    }
                    else if (i == 3)
                    {
                        Team1dD.ForeColor = Color.Red;
                    }
                    else if (i == 4)
                    {
                        Team1eD.ForeColor = Color.Red;
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                if (team2.getFouls(i) > 0 && team2.getFouls(i) < 3)
                {
                    if (i == 0)
                    {
                        Team2aD.ForeColor = Color.Yellow;
                    }
                    else if (i == 1)
                    {
                        Team2bD.ForeColor = Color.Yellow;
                    }
                    else if (i == 2)
                    {
                        Team2cD.ForeColor = Color.Yellow;
                    }
                    else if (i == 3)
                    {
                        Team2dD.ForeColor = Color.Yellow;
                    }
                    else if (i == 4)
                    {
                        Team2eD.ForeColor = Color.Yellow;
                    }
                }
                else if (team2.getFouls(i) > 2)
                {
                    if (i == 0)
                    {
                        Team2aD.ForeColor = Color.Red;
                    }
                    else if (i == 1)
                    {
                        Team2bD.ForeColor = Color.Red;
                    }
                    else if (i == 2)
                    {
                        Team2cD.ForeColor = Color.Red;
                    }
                    else if (i == 3)
                    {
                        Team2dD.ForeColor = Color.Red;
                    }
                    else if (i == 4)
                    {
                        Team2eD.ForeColor = Color.Red;
                    }
                }
            }
        }

        //increases the current round by one, will not go higher than 3
        public void increaseRound()
        {
            if (round < 3)
            {
                round += 1;
            }
        }

        //decreases the current round by one, will not go lower than 1
        public void decreaseRound()
        {
            if (round > 1)
            {
                round -= 1;
            }
        }

        private void DisplayWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}

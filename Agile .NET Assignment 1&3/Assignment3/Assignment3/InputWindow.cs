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
    public partial class InputWindow : Form
    {
        DisplayWindow DisplayWindow = new DisplayWindow();

        private int pageNum = 1;

        // Creates all 6 teams for the tournament
        private Team team1 = new Team();
        private Team team2 = new Team();
        private Team team3 = new Team();
        private Team team4 = new Team();
        private Team team5 = new Team();
        private Team team6 = new Team();

        public Team[] firstTeamList = new Team[6];
        public Team[] secondTeamList = new Team[6];

        

        // the 2 teams that will play each game
        private Team firstTeam = null;
        private Team secondTeam = null;


        public InputWindow()
        {
            InitializeComponent();
        }

        private void InputWindow_Load(object sender, EventArgs e)
        {
            teamView();

            ChangeTeams.Click += new EventHandler(this.ChangeTeams_Click);
            ConfirmTeams.Click += new EventHandler(this.ConfirmTeams_Click);
            ZeroScore.Click += new EventHandler(this.ZeroScore_Click);
            Team1BonusI.Click += new EventHandler(this.Team1BonusI_Click);
            Team2BonusI.Click += new EventHandler(this.Team2BonusI_Click);
            Team1BonusReset.Click += new EventHandler(this.Team1BonusReset_Click);
            Team2BonusReset.Click += new EventHandler(this.Team2BonusReset_Click);
            increaseRound.Click += new EventHandler(this.increaseRound_Click);
            decreaseRound.Click += new EventHandler(this.decreaseRound_Click);
            team1Goal.Click += new EventHandler(this.team1Goal_Click);
            team2Goal.Click += new EventHandler(this.team2Goal_Click);

            Foul1a.Click += new EventHandler(this.increaseFoul);
            Foul1b.Click += new EventHandler(this.increaseFoul);
            Foul1c.Click += new EventHandler(this.increaseFoul);
            Foul1d.Click += new EventHandler(this.increaseFoul);
            Foul1e.Click += new EventHandler(this.increaseFoul);

            Foul2a.Click += new EventHandler(this.increaseFoul);
            Foul2b.Click += new EventHandler(this.increaseFoul);
            Foul2c.Click += new EventHandler(this.increaseFoul);
            Foul2d.Click += new EventHandler(this.increaseFoul);
            Foul2e.Click += new EventHandler(this.increaseFoul);
        }

        // represents the view when changing information about the teams
        private void teamView()
        {
            // makes all of the necessary objects visible
            Team1a.Visible = true;
            Team1b.Visible = true;
            Team1c.Visible = true;
            Team1d.Visible = true;
            Team1e.Visible = true;

            Team2a.Visible = true;
            Team2b.Visible = true;
            Team2c.Visible = true;
            Team2d.Visible = true;
            Team2e.Visible = true;

            Team1MemberLabeli.Visible = true;
            Team2MemberLabeli.Visible = true;

            Team1Labeli.Visible = true;
            Team2Labeli.Visible = true;

            Team1Name.Visible = true;
            Team2Name.Visible = true;

            ConfirmTeams.Visible = true;

            // makes all of the unnecessary objects invisible

            ChangeTeams.Visible = false;
            ZeroScore.Visible = false;

            Team1BonusI.Visible = false;
            Team2BonusI.Visible = false;

            Team1BonusReset.Visible = false;
            Team2BonusReset.Visible = false;

            increaseRound.Visible = false;
            decreaseRound.Visible = false;

            team1Goal.Visible = false;
            team2Goal.Visible = false;

            Team1i.Visible = false;
            Team2i.Visible = false;

            Foul1a.Visible = false;
            Foul1b.Visible = false;
            Foul1c.Visible = false;
            Foul1d.Visible = false;
            Foul1e.Visible = false;

            Foul2a.Visible = false;
            Foul2b.Visible = false;
            Foul2c.Visible = false;
            Foul2d.Visible = false;
            Foul2e.Visible = false;

            EndGameButton.Visible = false;
            NextPageButton.Visible = true;
            PageLabel.Visible = true;

        }

        //represents the view when changing information about the game
        private void gameView()
        {
            //makes all of the necessary objects visible
            ChangeTeams.Visible = true;
            ZeroScore.Visible = true;

            Team1BonusI.Visible = true;
            Team2BonusI.Visible = true;

            Team1BonusReset.Visible = true;
            Team2BonusReset.Visible = true;

            increaseRound.Visible = true;
            decreaseRound.Visible = true;

            team1Goal.Visible = true;
            team2Goal.Visible = true;

            Team1i.Visible = true;
            Team2i.Visible = true;

            Foul1a.Visible = true;
            Foul1b.Visible = true;
            Foul1c.Visible = true;
            Foul1d.Visible = true;
            Foul1e.Visible = true;

            Foul2a.Visible = true;
            Foul2b.Visible = true;
            Foul2c.Visible = true;
            Foul2d.Visible = true;
            Foul2e.Visible = true;

            // makes the text in the textboxes the names of the teams
            Team1i.Text = DisplayWindow.getTeam1().getName();
            Team2i.Text = DisplayWindow.getTeam2().getName();

            // makes all of the unnecessary objects invisible

            Team1a.Visible = false;
            Team1b.Visible = false;
            Team1c.Visible = false;
            Team1d.Visible = false;
            Team1e.Visible = false;

            Team2a.Visible = false;
            Team2b.Visible = false;
            Team2c.Visible = false;
            Team2d.Visible = false;
            Team2e.Visible = false;

            Team1MemberLabeli.Visible = false;
            Team2MemberLabeli.Visible = false;

            Team1Labeli.Visible = false;
            Team2Labeli.Visible = false;

            Team1Name.Visible = false;
            Team2Name.Visible = false;

            ConfirmTeams.Visible = false;

            EndGameButton.Visible = true;
            NextPageButton.Visible = false;
            PageLabel.Visible = false;
        }

        // switches the view back to the team changing view when the user presses the change teams button
        private void ChangeTeams_Click(object sender, EventArgs e)
        {
            teamView();
        }

        // Click event for entering the teams
        private void ConfirmTeams_Click(object sender, EventArgs e)
        {
            // Tests that the team names, team 1 player names, and team 2 player names are not empty
            if (string.IsNullOrWhiteSpace(Team1Name.Text) || string.IsNullOrWhiteSpace(Team2Name.Text)){
                MessageBox.Show("Please enter team names", "ERROR");
            }
            else if(string.IsNullOrWhiteSpace(Team1a.Text) || string.IsNullOrWhiteSpace(Team1b.Text) || string.IsNullOrWhiteSpace(Team1c.Text) || string.IsNullOrWhiteSpace(Team1d.Text) || string.IsNullOrWhiteSpace(Team1e.Text)) {
                MessageBox.Show("Please enter player names for team 1", "ERROR");
            }
            else if (string.IsNullOrWhiteSpace(Team2a.Text) || string.IsNullOrWhiteSpace(Team2b.Text) || string.IsNullOrWhiteSpace(Team2c.Text) || string.IsNullOrWhiteSpace(Team2d.Text) || string.IsNullOrWhiteSpace(Team2e.Text)) {
                MessageBox.Show("Please enter player names for team 2", "ERROR");
            }
            else
            {

                // updates the values for the final teams that are filled in for the tournament
                if (pageNum == 3)
                {
                    team5.setName(Team1Name.Text);
                    team6.setName(Team2Name.Text);

                    team5.setMember(Team1a.Text, 0);
                    team5.setMember(Team1b.Text, 1);
                    team5.setMember(Team1c.Text, 2);
                    team5.setMember(Team1d.Text, 3);
                    team5.setMember(Team1e.Text, 4);

                    team6.setMember(Team2a.Text, 0);
                    team6.setMember(Team2b.Text, 1);
                    team6.setMember(Team2c.Text, 2);
                    team6.setMember(Team2d.Text, 3);
                    team6.setMember(Team2e.Text, 4);

                    Console.WriteLine("Page 3");
                    Console.WriteLine(team5.getName() + " " + team6.getName());
                    Console.WriteLine(team5.getMembers(0) + " " + team6.getMembers(0));
                }

                // Sets the values of the lists to the teams in the tournament
                firstTeamList.SetValue(team1, 0);
                firstTeamList.SetValue(team2, 1);
                firstTeamList.SetValue(team3, 2);
                firstTeamList.SetValue(team4, 3);
                firstTeamList.SetValue(team5, 4);
                firstTeamList.SetValue(team6, 5);

                secondTeamList.SetValue(team1, 0);
                secondTeamList.SetValue(team2, 1);
                secondTeamList.SetValue(team3, 2);
                secondTeamList.SetValue(team4, 3);
                secondTeamList.SetValue(team5, 4);
                secondTeamList.SetValue(team6, 5);

                // Plays the first game of tournament
                DisplayWindow.setTeam1((Team)firstTeamList.GetValue(0));
                DisplayWindow.setTeam2((Team)secondTeamList.GetValue(1));


                //sets the variables of the two teams to the values input by the user
                /*
                DisplayWindow.getTeam1().setName(Team1Name.Text);
                DisplayWindow.getTeam2().setName(Team2Name.Text);

                DisplayWindow.getTeam1().setMember(Team1a.Text, 0);
                DisplayWindow.getTeam1().setMember(Team1b.Text, 1);
                DisplayWindow.getTeam1().setMember(Team1c.Text, 2);
                DisplayWindow.getTeam1().setMember(Team1d.Text, 3);
                DisplayWindow.getTeam1().setMember(Team1e.Text, 4);

                DisplayWindow.getTeam2().setMember(Team2a.Text, 0);
                DisplayWindow.getTeam2().setMember(Team2b.Text, 1);
                DisplayWindow.getTeam2().setMember(Team2c.Text, 2);
                DisplayWindow.getTeam2().setMember(Team2d.Text, 3);
                DisplayWindow.getTeam2().setMember(Team2e.Text, 4);
                */



                //tests if the display window is already vivible, if so, it will just update the display, if not, it will load the window
                if (DisplayWindow.Visible == true)
                {
                    DisplayWindow.updateDisplay();
                }
                else
                {
                    DisplayWindow.Show();
                }
                //switches the view of this screen to the 'game' view
                gameView();
            }
        }

        //zeroes both teams scores when buton is clicked
        private void ZeroScore_Click(object sender, EventArgs e)
        {
            DisplayWindow.getTeam1().resetScore();
            DisplayWindow.getTeam2().resetScore();
            DisplayWindow.getTeam1().resetFouls();
            DisplayWindow.getTeam2().resetFouls();
            DisplayWindow.updateDisplay();
        }

        //increases team 1's bonus points on click
        private void Team1BonusI_Click(object sender, EventArgs e)
        {
            DisplayWindow.getTeam1().increaseBonus();
            DisplayWindow.updateDisplay();
        }

       //increases team 2's bonus points on click
        private void Team2BonusI_Click(object sender, EventArgs e)
        {
            DisplayWindow.getTeam2().increaseBonus();
            DisplayWindow.updateDisplay();
        }

        //Reset's the bonus points for team 1 on click
        private void Team1BonusReset_Click(object sender, EventArgs e)
        {
            DisplayWindow.getTeam1().resetBonus();
            DisplayWindow.updateDisplay();
        }

        //Reset's the bonus points for team 2 on click
        private void Team2BonusReset_Click(object sender, EventArgs e)
        {
            DisplayWindow.getTeam2().resetBonus();
            DisplayWindow.updateDisplay();
        }

        //Increases the round number by 1 on click
        private void increaseRound_Click(object sender, EventArgs e)
        {
            DisplayWindow.increaseRound();
            DisplayWindow.updateDisplay();
        }

        //Decreases the round number by 1 on click
        private void decreaseRound_Click(object sender, EventArgs e)
        {
            DisplayWindow.decreaseRound();
            DisplayWindow.updateDisplay();
        }

        //Increases team 1's score by five + bonus points
        private void team1Goal_Click(object sender, EventArgs e)
        {
            DisplayWindow.getTeam1().scoreGoal();
            DisplayWindow.updateDisplay();
        }

        //Increases team 2's score by five + bonus points
        private void team2Goal_Click(object sender, EventArgs e)
        {
            DisplayWindow.getTeam2().scoreGoal();
            DisplayWindow.updateDisplay();
        }

        private void increaseFoul(object sender, EventArgs e)
        {
            if (sender.Equals(Foul1a))
            {
                DisplayWindow.getTeam1().increaseFouls(0);
            }
            else if (sender.Equals(Foul1b))
            {
                DisplayWindow.getTeam1().increaseFouls(1);
            }
            else if (sender.Equals(Foul1c))
            {
                DisplayWindow.getTeam1().increaseFouls(2);
            }
            else if (sender.Equals(Foul1d))
            {
                DisplayWindow.getTeam1().increaseFouls(3);
            }
            else if (sender.Equals(Foul1e))
            {
                DisplayWindow.getTeam1().increaseFouls(4);
            }
            else if (sender.Equals(Foul2a))
            {
                DisplayWindow.getTeam2().increaseFouls(0);
            }
            else if (sender.Equals(Foul2b))
            {
                DisplayWindow.getTeam2().increaseFouls(1);
            }
            else if (sender.Equals(Foul2c))
            {
                DisplayWindow.getTeam2().increaseFouls(2);
            }
            else if (sender.Equals(Foul2d))
            {
                DisplayWindow.getTeam2().increaseFouls(3);
            }
            else if (sender.Equals(Foul2e))
            {
                DisplayWindow.getTeam2().increaseFouls(4);
            }
            DisplayWindow.updateDisplay();
        }


        // this method clears the textboxes for the input window when needed
        public void ClearWindow()
        {
            Team1Name.Clear();
            Team2Name.Clear();

            Team1a.Clear();
            Team1b.Clear();
            Team1c.Clear();
            Team1d.Clear();
            Team1e.Clear();

            Team2a.Clear();
            Team2b.Clear();
            Team2c.Clear();
            Team2d.Clear();
            Team2e.Clear();
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {

            // Update the page number by 1
            if (pageNum != 3)
            {
                pageNum = pageNum + 1;
                PageLabel.Text = "Page " + pageNum;

            }

            // if it's the second page, update the values for the 1st and 2nd teams with the values input in page 1, update labels too.
            if (pageNum == 2)
            {
          
                team1.setName(Team1Name.Text);
                team2.setName(Team2Name.Text);

                team1.setMember(Team1a.Text, 0);
                team1.setMember(Team1b.Text, 1);
                team1.setMember(Team1c.Text, 2);
                team1.setMember(Team1d.Text, 3);
                team1.setMember(Team1e.Text, 4);

                team2.setMember(Team2a.Text, 0);
                team2.setMember(Team2b.Text, 1);
                team2.setMember(Team2c.Text, 2);
                team2.setMember(Team2d.Text, 3);
                team2.setMember(Team2e.Text, 4);

                Console.WriteLine("Page 1");
                Console.WriteLine(team1.getName() + " " + team2.getName());
                Console.WriteLine(team1.getMembers(0) + " " + team2.getMembers(0));

                this.ClearWindow();

                Team1Labeli.Text = "Enter Team 3 Name";
                Team2Labeli.Text = "Enter Team 4 Name";
                Team1MemberLabeli.Text = "Enter Team 3 Members";
                Team2MemberLabeli.Text = "Enter Team 4 Members";

               

            }

            // if it's the 3rd page, update the vlaues of teams 3 and 4 with the values given in the textboxes in page to, then clear the textboxes and update labels for team 5 and 6.
            if (pageNum == 3)
            {

                team3.setName(Team1Name.Text);
                team4.setName(Team2Name.Text);

                team3.setMember(Team1a.Text, 0);
                team3.setMember(Team1b.Text, 1);
                team3.setMember(Team1c.Text, 2);
                team3.setMember(Team1d.Text, 3);
                team3.setMember(Team1e.Text, 4);

                team4.setMember(Team2a.Text, 0);
                team4.setMember(Team2b.Text, 1);
                team4.setMember(Team2c.Text, 2);
                team4.setMember(Team2d.Text, 3);
                team4.setMember(Team2e.Text, 4);

                Console.WriteLine("Page 2");
                Console.WriteLine(team3.getName() + " " + team4.getName());
                Console.WriteLine(team3.getMembers(0) + " " + team4.getMembers(0));

                this.ClearWindow();

                Team1Labeli.Text = "Enter Team 5 Name";
                Team2Labeli.Text = "Enter Team 6 Name";
                Team1MemberLabeli.Text = "Enter Team 5 Members";
                Team2MemberLabeli.Text = "Enter Team 6 Members";

                NextPageButton.Visible = false;

            }

        }

        private int i = 0;

        private void EndGameButton_Click(object sender, EventArgs e)
        {

            // loop for iterating through the lists and having each team play against each other once only.
            while (i != secondTeamList.Length)
            {

            }



        }
    }
}

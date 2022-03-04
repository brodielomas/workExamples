using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Team
    {
        //variables for the team name, score and bonus points, as well as an array representing the team members
        private String teamName;
        private String[] teamMembers= new string[5];
        private int[] teamFouls = new int[5];
        private int score;
        private int bonus;
        private int totalScore;
        private int wins;
        private int losses;
        private int draws;
        
        public Team()
        {
            resetFouls();
        }
        
        //returns the team's name
        public String getName()
        {
            return teamName;
        }

        //set's the teams name
        public void setName(String teamName)
        {
            this.teamName = teamName;
        }

        //returns the team members
        public String getMembers(int pos)
        {
            return teamMembers.GetValue(pos).ToString();
        }

        //will set the team member in the array at the position specified
        public void setMember(String member, int pos)
        {
            teamMembers.SetValue(member, pos);
        }

        //returns the current score, if it is above 99, it will just return 99
        public int getScore()
        {
            if (score > 99)
            {
                return 99;
            }
            return score;
        }

        //adds five points to the score, plus the bonus points, and then resets the bonus points to zero
        public void scoreGoal()
        {
            score += 5;
            score += bonus;
            resetBonus();
        }

        //reset's the score to zero
        public void resetScore()
        {
            score = 0;
        }

        //returns the current number of bonus points
        public int getBonus()
        {
            return bonus;
        }

        //increases the bonus points by one, for a maximum of 3
        public void increaseBonus()
        {
            if (bonus < 3)
            {
                bonus += 1;
            }
        }

        //reset's the bonus points to zero
        public void resetBonus()
        {
            bonus = 0;
        }

        //returns the team members fouls
        public int getFouls(int pos)
        {
            return teamFouls[pos];
        }

        //will set the foul in the array at the position specified
        public void increaseFouls(int pos)
        {
            teamFouls[pos] += 1;
        }

        public void resetFouls()
        {
            for (int i = 0; i < 5; i++)
            {
                teamFouls.SetValue(0, i);
            }
        }

        // retruns total score of team 
        public int getTotalScore()
        {
            return totalScore;
        }

        // adds specified score to the totalScore of the team
        public void addTotalScore(int score)
        {
            totalScore = totalScore + score;
        }

        // returns the amount of wins the team has
        public int getWins()
        {
            return wins;
        }

        // adds the specified amount of wins to the team
        public void addWins(int win)
        {
            wins = wins + win;
        }

        // returns the amount of losses the team has suffered
        public int getLosses()
        {
            return losses;
        }

        // adds the specified amount of losses to the team 
        public void addLosses(int loss)
        {
            losses = losses + loss;
        }

        // returns the amount of draws that the team currently has
        public int getDraw()
        {
            return draws;
        }

        // adds the specified amount of draws to the teams current amount
        public void addDraws(int draw)
        {
            draws = draws + draw;
        }

    }
}

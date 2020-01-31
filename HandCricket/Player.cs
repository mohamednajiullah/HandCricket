using System;

namespace HandCricket
{
    class Player
    {
        private string strPlayerName = string.Empty;
        private int runsScored;
        private int ballsBowled;

        public Player(string strName)
        {
            strPlayerName = strName;
        }

        public string PlayerName
        {
            get
            {
                return strPlayerName;
            }
        }

        public int RunsScored
        {
            get
            {
                return runsScored;
            }
            set
            {
                if (value > 0)
                {
                    runsScored = value;
                }
            }
        }

        public int BallsBowled
        {
            get
            {
                return ballsBowled;
            }
            set
            {
                if (value > 0)
                {
                    ballsBowled = value;
                }
            }
        }
    }
}

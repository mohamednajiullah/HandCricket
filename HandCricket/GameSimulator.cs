using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HandCricket
{
    class GameSimulator
    {
        static HashSet<int> exclude = null;
        static IEnumerable<int> range = null;
        static int playersOut = 0;

        public static void SetRange()
        {
            exclude = new HashSet<int>() { 5 };
            range = Enumerable.Range(1, 6).Where(i => !exclude.Contains(i));
        }

        private static int GiveMeANumber()
        {
            var rand = new Random();
            int index = rand.Next(0, 5 - exclude.Count);
            return range.ElementAt(index);
        }

        private static void PrintEndOfInnings(Player batsman)
        {
            Console.WriteLine(batsman.PlayerName + " TOTAL SCORE: " + batsman.RunsScored);
            Console.WriteLine(batsman.PlayerName + " INNINGS ENDED.");
            Console.WriteLine("----------------------------------------------");
        }

        private static void HandlePlayerOut(Player batsman, Player bowler)
        {
            playersOut++;
            PrintEndOfInnings(batsman);

            if (playersOut == 2)
            {
                PrintResult(batsman, bowler);                
            }
            else if (playersOut < 2)
            {
                SimulateGame(bowler, batsman);
            }
        }

        private static void PrintResult(Player batsman, Player bowler)
        {
            Console.WriteLine("----------------------------------------------");
            string gameResult = batsman.RunsScored > bowler.RunsScored ? batsman.PlayerName + " WINS !!!" : bowler.PlayerName + " WINS !!!";
            if (batsman.RunsScored == bowler.RunsScored)
            {
                gameResult = "GAME TIED.";
            }
            Console.WriteLine(gameResult);
        }

        public static void SimulateGame(Player batsman, Player bowler)
        {
            string strInnings = batsman.PlayerName == "A" ? "Player A Innings" : "Player B Innings";
            Console.WriteLine(strInnings);

            int batsmanHand = 0;
            int bowlerHand = 0;
            SetRange();

            for (int ball = 1; ball <= 6 && playersOut < 2; ball++)
            {
                batsmanHand = GiveMeANumber();
                Thread.Sleep(50);
                bowlerHand = GiveMeANumber();
                                
                if (batsmanHand == bowlerHand)
                {
                    HandlePlayerOut(batsman, bowler);
                    break;
                }
                else
                {
                    batsman.RunsScored += batsmanHand;
                    bowler.BallsBowled++;
                    Console.WriteLine("Ball " + ball + "    " + "Score " + batsmanHand.ToString());

                    if (bowler.BallsBowled == 6)
                    {
                        HandlePlayerOut(batsman, bowler);
                        break;
                    }
                }
            }
        }

    }
}

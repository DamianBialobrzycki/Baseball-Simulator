using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;

namespace Baseball_Simulator
{
    class Pitcher
    {
        public ObservableCollection<string> PitcherSays = new ObservableCollection<string>();

        private int pitchNumber = 0;

        public Pitcher(Ball ball)
        {
            ball.BallInPlay += new EventHandler(Ball_BallInPlay);
        }

        private void Ball_BallInPlay(object sender, EventArgs e)
        {
            pitchNumber++;
            if(e is BallEventArgs)
            {
                BallEventArgs ballEventArgs = e as BallEventArgs;

                if ((ballEventArgs.Distance < 95) && (ballEventArgs.Trajectory < 60))
                    CatchBall();
                else
                    CoverFirstBase();
            }
        }

        private void CoverFirstBase()
        {
            PitcherSays.Add("Pitch #" + pitchNumber + ": I covered first base");
        }

        private void CatchBall()
        {
            PitcherSays.Add("Pitch #" + pitchNumber + ": I caught the ball");
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BallDodgeTemplate
{
    public partial  class GameScreen : UserControl
    {
        Ball chaseBall; 
        
        Random randGen = new Random();

        public static int gsWidth = 600;
        public static int gsHeight = 600;

        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();
        }

        public void InitializeGame()
        {
            int x = randGen.Next(40, gsWidth - 40);
            int y = randGen.Next(40, gsHeight - 40);

            chaseBall = new Ball(x, y, 8, 8);
        }


        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void gameTImer_Tick(object sender, EventArgs e)
        {
            chaseBall.Move();

            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Green, chaseBall.x, chaseBall.y, chaseBall.size, chaseBall.size);
        }
    }
}

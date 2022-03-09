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
        Player hero;

        public static int lives, difficuly;
        int score = 0;

        List<Ball> dodgeBalls = new List<Ball>();
        
        Random randGen = new Random();
        Size screenSize;

        public static int gsWidth = 600;
        public static int gsHeight = 600;

        bool upArrowDown = false;
        bool downArrowDown = false;
        public static bool leftArrowDown = false;
        bool rightArrowDown = false;

        public GameScreen()
        {
            InitializeComponent();
            InitializeGame();
        }

        public void InitializeGame()
        {
            screenSize = new Size(this.Width, this.Height);


            int x = randGen.Next(40, screenSize.Width - 40);
            int y = randGen.Next(40, screenSize.Height - 40);

            chaseBall = new Ball(x, y, 8, 8);

            x = randGen.Next(40, screenSize.Width - 40);
            y = randGen.Next(40, screenSize.Height - 40);
            hero = new Player(x, y);

            for (int i = 0; i < difficuly; i++)
            {
                NewBall();
            }
        }

        public void NewBall()
        {
            int x = randGen.Next(40, gsWidth - 40);
            int y = randGen.Next(40, gsHeight - 40);

            Ball b = new Ball(x, y, 8, 8);
            dodgeBalls.Add(b);
        }

        private void GameScreen_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = true;
                    break;
                case Keys.Right:
                    rightArrowDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
                    break;
            }

        }

        private void GameScreen_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    leftArrowDown = false;
                    break;
                case Keys.Right:
                    rightArrowDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
                    break;
            }
        }

        private void gameTImer_Tick(object sender, EventArgs e)
        {
            if (leftArrowDown == true)
            {
                hero.Move("left", screenSize);
            }

            if (rightArrowDown == true)
            {
                hero.Move("right", screenSize);
            }

            if (upArrowDown == true)
            {
                hero.Move("up", screenSize);
            }

            if (downArrowDown == true)
            {
                hero.Move("down", screenSize);
            }

            chaseBall.Move(screenSize);
            
            foreach( Ball b in dodgeBalls)
            {
                b.Move(screenSize);
            }
            
            if(chaseBall.Collision(hero))
            {
                score++;
                NewBall();
            }

            foreach (Ball b in dodgeBalls)
            {
                if (b.Collision(hero))
                {
                    lives--;

                    if (lives == 0)
                    {
                        gameTImer.Enabled = false;
                        Form1.ChangeScreen(this, new gameoverScreen());
                    }
                }
            }


            Refresh();
        }

        private void GameScreen_Paint(object sender, PaintEventArgs e)
        {
            scoreLabel.Text = $"{score}";
            livesLabel.Text = $"{lives}";

            e.Graphics.FillEllipse(Brushes.Green, chaseBall.x, chaseBall.y, chaseBall.size, chaseBall.size);

            foreach (Ball b in dodgeBalls)
            {
                e.Graphics.FillEllipse(Brushes.Red, b.x, b.y, b.size, b.size);
            }

            e.Graphics.FillRectangle(Brushes.DodgerBlue, hero.x, hero.y, hero.width, hero.height);  
        }
    }
}

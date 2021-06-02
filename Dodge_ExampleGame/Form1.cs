using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;


namespace Dodge_ExampleGame
{
    public partial class Dodge : Form
    {


        public Dodge()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, pnlGame, new object[] { true });


            for (int i = 0; i < 6; i++)
            {
                int x = 10 + (i*this.Width)/6;

                planet[i] = new Planetcreate(x);
            }
        
        }

        Graphics g;
        /*Planet planet1 = new Planet();*/
        

        Planetcreate[] planet = new Planetcreate[6];

        Random random = new Random();

        Spaceship spaceship = new Spaceship();

        bool left;
        bool right;

        bool up;
        bool down;

        int score = 0;
        int lives = 5;

        string move;

        bool playing = false;
        bool shoot = false;

        string skin;

        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            /*planet1.DrawPlanet(g);*/
            for (int i = 0; i<6; i++)
            {
                int yspeed = random.Next(1, 16);
                planet[i].y += yspeed;
                planet[i].DrawPlanet(g);

            }
            spaceship.DrawSpaceship(g, skin);
        }



        private void Dodge_Load(object sender, EventArgs e)
        {

        }

        private void Dodge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A) { left = true; }
            if (e.KeyData == Keys.D) { right = true; }
            if (e.KeyData == Keys.Space) { shoot = true; }

            if (e.KeyData == Keys.W) { up= true; }
            if (e.KeyData == Keys.S) { down = true; }
        }

        private void Dodge_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A) { left = false; }
            if (e.KeyData == Keys.D) { right = false; }
            if (e.KeyData == Keys.W) { up = false; }
            if (e.KeyData == Keys.S) { down = false; }

        }

        private void tmrSpaceship_Tick(object sender, EventArgs e)
        {

            if (right) // if right arrow key pressed
            {

                move = "right";
                spaceship.MoveSpaceship(move);

            }
            else if (left) // if left arrow key pressed
            {

                move = "left";
                spaceship.MoveSpaceship(move);
            }
           

            if (up) // if right arrow key pressed
            {

                move = "up";
                spaceship.MoveSpaceship(move);

            }
            else if (down) // if left arrow key pressed
            {

                move = "down";
                spaceship.MoveSpaceship(move);
            }
            


            if (shoot)
            {
                spaceship.ShootBullet(shoot);
                shoot = false;
            }

        }


        public void TmrPlanet_Tick(object sender, EventArgs e)
        {

            if (playing)
            {


                for (int i = 0; i < 6; i++)

                {
                    planet[i].MovePlanet();
                    if (planet[i].y >= pnlGame.Height)
                    {
                        planet[i].y = 30;
                        score += 1;
                        CheckLives();
                        
                    }

                    if (spaceship.spaceRec.IntersectsWith(planet[i].planetRec))
                    {
                        lives -= 1;
                        planet[i].y = 30;
                        CheckLives();
                    }

                }
            }

            pnlGame.Invalidate();
           
            lblScore.Text = "Score:  " + score.ToString();

        }

        private void lblScore_Click(object sender, EventArgs e)
        {

        }


        private void CheckLives()
        {
            if (lives == 0)
            {
                TmrPlanet.Enabled = false;
                tmrSpaceship.Enabled = false;
                MessageBox.Show("Game Over      Your soooo bad!!!       Score:  " + score.ToString());

                //string path = score.ToString();
                //
                //if (!File.Exists(path))
                //{
                //    File.Create(path);
                //}                else
                //{
                //    MessageBox.Show("File Already Exists");
                //}

            }
            lblLives.Text = "Lives:  " + lives.ToString();
        }

        private void lblLives_Click(object sender, EventArgs e)
        {

        }

        public void LoadOption()
        {
            lblScore.Text = "Score:  " + score.ToString();
            CheckLives();

        }




        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            lives = 50;
            score = 0;
            LoadOption();



        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            lives = 3;
            score = 0;
            LoadOption();


        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            lives = 2;
            score = 0;
            LoadOption();

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            lives = 1;
            score = 0;
            LoadOption();

        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmrSpaceship.Enabled= true;
            TmrPlanet.Enabled = true;
            playing = true;
            CheckLives();

        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tmrSpaceship.Enabled = false;
            TmrPlanet.Enabled = false;
            playing = false;


        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {

            score = 0;
            lives = 5;

            for (int i = 0; i < 6; i++)

            {
                planet[i].MovePlanet();
                planet[i].y = 30;
                pnlGame.Refresh();
            }
        }

        private void lblShoot_Click(object sender, EventArgs e)
        {

        }

        private void alienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            skin = "1";
        }

        private void flyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            skin = "2";
        }
    }
}

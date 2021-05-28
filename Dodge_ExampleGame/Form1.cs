using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodge_ExampleGame
{
    public partial class Dodge : Form
    {


        public Dodge()
        {
            InitializeComponent();
        
            for(int i = 0; i < 7; i++)
            {
                int x = 10 + (i *2* pnlGame.Width / planet.Length);

                planet[i] = new Planet(x);
            }
        
        }

        Graphics g;
        /*Planet planet1 = new Planet();*/
        

        Planet[] planet = new Planet[15];

        Random random = new Random();

        Spaceship spaceship = new Spaceship();

        bool left, right;

        string move;




        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            /*planet1.DrawPlanet(g);*/
            for(int i = 0; i<7; i++)
            {
                int yspeed = random.Next(1, 16);
                planet[i].y += yspeed;
                planet[i].DrawPlanet(g);

            }

            spaceship.DrawSpaceship(g);
        }

        

        private void Dodge_Load(object sender, EventArgs e)
        {

        }

        private void Dodge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A) { left = true; }
            if (e.KeyData == Keys.D) { right = true; }

        }

        private void Dodge_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.A) { left = false; }
            if (e.KeyData == Keys.D) { right = false; }

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
            else
            {
                move = "";
            }



        }


        private void TmrPlanet_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < 7; i++)

            {
                planet[i].MovePlanet();
                if (planet[i].y >= pnlGame.Height)
                {
                    planet[i].y = 30;
                }

            }
            pnlGame.Invalidate();

        }
    }
}

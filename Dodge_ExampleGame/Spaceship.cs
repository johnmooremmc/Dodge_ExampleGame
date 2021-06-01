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
    class Spaceship
    {

        public int  y, width, height;//variables for the rectangle
        public Image spaceship;//variable for the planet's image

        public Rectangle spaceRec;//variable for a rectangle to place our image in

        int x = 100;

        public void DrawSpaceship(Graphics g)
        {
            
            y = 360;
            width = 60;
            height = 40;

            spaceship = Properties.Resources.alien1;
            spaceRec = new Rectangle(x, y, width, height);

            g.DrawImage(spaceship, spaceRec);
        }

        public void ShootBullet(bool shoot)
        {
            if(shoot)
            {
                
                shoot = false;
            }

        }

        public void MoveSpaceship(string move)
        {
            spaceRec.Location = new Point(x, y);

            if (move == "right")
            {
                if (spaceRec.Location.X > 450) // is spaceship within 50 of right side
                {

                    x = 450;
                    spaceRec.Location = new Point(x, y);
                }
                else
                {
                    x += 20;
                    spaceRec.Location = new Point(x, y);
                }

            }


            if (move == "left")
            {
                if (spaceRec.Location.X < 10) // is spaceship within 10 of left side
                {

                    x = 20;
                    spaceRec.Location = new Point(x, y);
                }
                else
                {
                    x -= 20;
                    spaceRec.Location = new Point(x, y);
                }

            }



        }


    }
}

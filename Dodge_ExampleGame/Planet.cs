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
    class Planet
    {
        public int x, y, width, height;
        public Image planetImage;

        public Rectangle planetRec;

        public int score;

        public Planet(int spacing)
        {
            x = spacing;
            y = 10;
            width = 20;
            height = 20;

            planetImage = Properties.Resources.planet1;
            planetRec = new Rectangle(x, y, width, height);

        }

        public void DrawPlanet(Graphics g)
        {
            g.DrawImage(planetImage, planetRec);
        }

        public void MovePlanet()
        {
            y += 5;

            planetRec.Location = new Point(x, y);
        }




    }
}

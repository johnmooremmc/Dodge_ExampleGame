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
    class Planetcreate
    {
        public int x, y;


        Random randomplanet = new Random();

        public int width = 25;
        public int height = 20;
           

        public Image planetImage;

        public Rectangle planetRec;



        
        


        

        public Planetcreate(int spacing)
        {
            x = spacing;
            y = 10;

            

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

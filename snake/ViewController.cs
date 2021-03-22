using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using SnakeLibrary;


namespace snake
{
    public class ViewController
    {
        
        public ViewController(int x, int y)
        {
            Size = new Coordinates(x,y);

        }


        public Coordinates Size { get; set; }

        public Bitmap PrepareScene(Coordinates[] body, Coordinates eatCoords)
        {
            Bitmap Scene = new Bitmap(Size.x*20, Size.y*20);

            
            Coordinates snakeTestCoords = new Coordinates(1,1);
           

            Scene = DrawScene(Scene);
            Scene = DrawRect(Scene,eatCoords,Brushes.Green);

            for(int i=0; i<(body.Length-1); i++)
            {
                Scene = DrawRect(Scene, body[i], Brushes.Orange);

            }
            Scene = DrawRect(Scene, body[body.Length-1], Brushes.Red);

            return Scene;

        }



        private Bitmap DrawRect(Bitmap scene, Coordinates coords, Brush color)
        {

            Graphics graph = Graphics.FromImage(scene);

            Rectangle ImageSize = new Rectangle(coords.x * 20, coords.y * 20,  20, 20);
            graph.FillRectangle(color, ImageSize);

            return scene;

        }

        private Bitmap DrawScene(Bitmap scene)
        {
            Graphics graph = Graphics.FromImage(scene);

            Rectangle ImageSize = new Rectangle(0, 0, Size.x * 20, Size.y * 20);
            graph.FillRectangle(Brushes.White, ImageSize);

            return scene;
        }




    }
}

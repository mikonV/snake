using System;
using System.IO;
using System.Linq;

namespace SnakeLibrary
{
    public class Snake
    {
        public Snake(int BoardX, int BoardY)
        {
            Body = new Coordinates[] { new Coordinates(0, 0), new Coordinates(1, 0) };

            CurrentDirection = new Coordinates(0, 1);
            BoardSize = new Coordinates(BoardX, BoardY);
            EatCoords = new Coordinates(3, 3);
            GameOver = false;

        }
        public Coordinates[] Body;

        public Coordinates CurrentDirection { get; private set; }

        public Coordinates BoardSize { get; set; }

        public Coordinates EatCoords { get; set; }
        public int Length { get; set; }
        public bool GameOver { get; set; }
        public void setCurrentDirection(int x, int y)
        {
            Coordinates BodyHeadNextCoordinates = new Coordinates();

            BodyHeadNextCoordinates.x = Body[Body.Length - 1].x + x;
            BodyHeadNextCoordinates.y = Body[Body.Length - 1].y + y;

            
            if (CheckIfCoordinatesMatch(BodyHeadNextCoordinates, Body[Length-2]) == true) return;

            CurrentDirection = new Coordinates(x, y);

        }
        public bool Move()
        {
            bool returner = true;

            if (GameOver == true) returner = false;
            Coordinates BodyHeadCoordinates = new Coordinates();

            BodyHeadCoordinates.x = Body[Body.Length - 1].x + CurrentDirection.x;
            BodyHeadCoordinates.y = Body[Body.Length - 1].y + CurrentDirection.y;


            //check if crash 

            if (CheckIfCoordinatesMatchBody(BodyHeadCoordinates) == true) returner = false;

            if ((BodyHeadCoordinates.x >= BoardSize.x) || (BodyHeadCoordinates.y >= BoardSize.y)) returner = false;

            if ((BodyHeadCoordinates.x < 0) || (BodyHeadCoordinates.y < 0)) returner = false;



            //to do check if eat

            if ((BodyHeadCoordinates.x == EatCoords.x) && (BodyHeadCoordinates.y == EatCoords.y))
            {
                Body = (Body ?? Enumerable.Empty<Coordinates>()).Concat(new[] { BodyHeadCoordinates }).ToArray(); //append next step item

                EatCoords = generateNewEatCoords();
            }
            else
            {
                Body = Body.Where((source, index) => index != 0).ToArray(); //delete [0] item

                Body = (Body ?? Enumerable.Empty<Coordinates>()).Concat(new[] { BodyHeadCoordinates }).ToArray(); //append next step item

            }
            Length = Body.Length;

            if (returner == false)
            {
                GameOver = true;
                return false;
            }

            return true;
        }


        public Coordinates generateNewEatCoords()
        {
            Coordinates testedCoords = new Coordinates();
            var random = new Random();

            bool FindResult = false;
            bool CheckResult = false;

            while (FindResult == false)
            {
                while (CheckResult == false)
                {
                    testedCoords = new Coordinates(DateTime.Now.Second % 8, random.Next(8));

                    if (!(testedCoords.Equals(EatCoords))) CheckResult = true;


                }

                if (CheckIfCoordinatesMatchBody(testedCoords) == true)
                {
                    CheckResult = false;

                }
                else
                {
                    FindResult = true;
                }
            }

            return testedCoords;
        }

        private bool CheckIfCoordinatesMatchBody(Coordinates coords)
        {
            foreach (var part in Body)
            {
                if ((coords.x == part.x) && (coords.y == part.y))
                {
                    return true;
                }

            }
            return false;
        }

        private bool CheckIfCoordinatesMatch(Coordinates coords1, Coordinates coords2)
        {

            if ((coords1.x == coords2.x) && (coords1.y == coords2.y))
            {
                return true;
            }
            else
            {
                return false;
            }



        }

    }
}

using System;

namespace lsp_exercise_birds
{
    class Program
    {
        static void Main(string[] args)
        {
            Bird bird1 = new Duck();
            ArrangeBirdInPattern(bird1);

            Bird bird2 = new Penguin();
            ArrangeBirdInPattern(bird2);

            bird1.Draw();
            bird2.Draw();
        }

        static void ArrangeBirdInPattern(Bird aBird)
        {
            if (aBird is Penguin)
                ArrangeBirdOnGround((Penguin) aBird);
            else
                ArrangeBirdInSky(aBird);
        }

        static void ArrangeBirdInSky(Bird aBird)
        {
            aBird.SetLocation(12, 3);
            aBird.SetAltitude(100);
        }

        static void ArrangeBirdOnGround(Penguin penguin)
        {
            penguin.SetLocation(12, 3);
        }
    }

    public abstract class Bird
    {
        public double Longitude { get; internal set; }
        public double Latitude { get; internal set; }
        public double Altitude { get; internal set; }
        public abstract void SetLocation(double longitude, double latitude);
        public abstract void SetAltitude(double altitude);
        public abstract void Draw();
    }

    public class Penguin : Bird
    {
        public override void SetAltitude(double altitude)
        {
            //altitude can't be set because penguins can't fly
            //this function does nothing
        }

        public override void SetLocation(double longitude, double latitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override void Draw()
        {
            Console.WriteLine($"I'm a penguin. location:{Longitude},{Latitude} altitude:{Altitude}");
        }
    }

    public class Duck : Bird
    {
        public override void SetLocation(double longitude, double latitude)
        {
            Latitude = latitude;
            Longitude= longitude;
        }

        public override void SetAltitude(double altitude)
        {
            Altitude = altitude;
        }

        public override void Draw()
        {
            Console.WriteLine($"I'm a duck. location:{Longitude},{Latitude} altitude:{Altitude}");
        }
    }
}

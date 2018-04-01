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
            var placer = new LocationAndAltitudePlacer(12, 3, 100);
            aBird.MoveWith(placer);

//            if (aBird is Penguin)
//                ArrangeBirdOnGround((Penguin)aBird);
//            else
//                ArrangeBirdInSky(aBird);
        }

//        static void ArrangeBirdInSky(Bird aBird)
//        {
//            aBird.SetLocation(12, 3);
//            aBird.SetAltitude(100);
//        }
//
//        static void ArrangeBirdOnGround(Penguin penguin)
//        {
//            penguin.SetLocation(12, 3);
//        }
    }

    internal class LocationAndAltitudePlacer : IBirdPlacer
    {
        private readonly int _lon;
        private readonly int _lat;
        private readonly int _altitude;

        public LocationAndAltitudePlacer(int lon, int lat, int altitude)
        {
            _altitude = altitude;
            _lat = lat;
            _lon = lon;
        }

        public void PlacePenguin(Penguin bird)
        {
            bird.SetLocation(_lon, _lat);
        }

        public void PlaceDuck(Duck bird)
        {
            bird.SetLocation(_lon, _lat);
            bird.SetAltitude(_altitude);
        }
    }

    public interface IMoveableBird
    {
        void MoveWith(IBirdPlacer placer);
    }

    public abstract class Bird : IMoveableBird
    {
        public double Longitude { get; internal set; }
        public double Latitude { get; internal set; }
        public double Altitude { get; internal set; }
        public abstract void SetLocation(double longitude, double latitude);
//        public abstract void SetAltitude(double altitude);
        public abstract void Draw();
        public abstract void MoveWith(IBirdPlacer placer);
    }

    public interface IBirdPlacer
    {
        void PlacePenguin(Penguin bird);
        void PlaceDuck(Duck bird);
    }

    public class Penguin : Bird
    {
//        public override void SetAltitude(double altitude)
//        {
//            //altitude can't be set because penguins can't fly
//            //this function does nothing
//        }

        public override void SetLocation(double longitude, double latitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public override void Draw()
        {
            Console.WriteLine($"I'm a penguin. location:{Longitude},{Latitude} altitude:{Altitude}");
        }

        public override void MoveWith(IBirdPlacer placer)
        {
            placer.PlacePenguin(this);
        }
    }

    public class Duck : Bird
    {
        public override void SetLocation(double longitude, double latitude)
        {
            Latitude = latitude;
            Longitude = longitude;
        }

        public /*override*/ void SetAltitude(double altitude)
        {
            Altitude = altitude;
        }

        public override void Draw()
        {
            Console.WriteLine($"I'm a duck. location:{Longitude},{Latitude} altitude:{Altitude}");
        }

        public override void MoveWith(IBirdPlacer placer)
        {
            placer.PlaceDuck(this);
        }
    }
}

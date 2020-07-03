using System;
using System.Device.Location;

namespace WhereAmI
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Starting GeoCoordinate Watcher...");

            // 2. Use the GeoCoordinate Watcher
            var watcher = new GeoCoordinateWatcher();

            watcher.StatusChanged += (sender, ev) =>
            {
                Console.WriteLine($"GeoCoordinateWatcher:StatusChanges:{ev.Status}");
            };


            watcher.PositionChanged += (sender, ev) =>
            {
                Console.WriteLine($"GeoCoordinateWatcher:PositionChanged:{ev.Position.Location}");
                
                MapImage.Show(ev.Position.Location);
            };

            watcher.MovementThreshold = 100;

            watcher.Start();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}

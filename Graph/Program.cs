using System;
using System.Collections.Generic;
using Graph.Places;

namespace Graph
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var map = new PlaceMap();

            map.AddPlace("Cedar Rapids");
            map.AddPlace("Iowa City");
            map.AddPlace("Chicago");
            map.AddPlace("New York");
            map.AddPlace("Los Angeles");
            map.AddPlace("Toronto");
            map.AddPlace("PeePee Township");
            map.AddPlace("Cleveland");
            map.AddPlace("Uber Driver");
            map.Places.TryGetValue("Cedar Rapids", out var cr);
            map.Places.TryGetValue("Iowa City", out var ic);
            map.Places.TryGetValue("Chicago", out var chi);
            map.Places.TryGetValue("New York", out var ny);
            map.Places.TryGetValue("Los Angeles", out var la);
            map.Places.TryGetValue("Toronto", out var t);
            map.Places.TryGetValue("PeePee Township", out var pp);
            map.Places.TryGetValue("Cleveland", out var c);
            map.Places.TryGetValue("Uber Driver", out var ud);
            map.AddEdge(cr, ic);
            map.AddEdge(ic, chi);
            map.AddEdge(chi, ny);
            map.AddEdge(ic, la);
            map.AddEdge(ny, la);
            map.AddEdge(ny, t);
            map.AddEdge(ny, pp);
            map.AddEdge(pp, c);
            map.AddEdge(c, ud);
            map.AddEdge(ud, t);
            map.AddEdge(ic, t);

            Console.WriteLine(map.Size());

            var route = map.GetBestRoute(cr,la);

            foreach(var stop in route)
            {
                Console.WriteLine(stop.Name);
            }
        }


    }
}

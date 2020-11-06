using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graph.Places
{
    public class PlaceMap
    {
        public Dictionary<string, Place> Places { get; } = new Dictionary<string, Place>();

        public void AddPlace(string name)
        {
            if (Places.ContainsKey(name))
                throw new Exception();

            var place = new Place(name);
            Places.Add(name, place);
        }

        public void AddEdge(Place place1, Place place2)
        {
            if (!Places.ContainsKey(place1.Name) || !Places.ContainsKey(place2.Name))
            {
                throw new Exception();
            }
            if (!place1.Neighbors.ContainsKey(place2.Name))
            {
                place1.Neighbors.Add(place2.Name, place2);
            }
            if (!place2.Neighbors.ContainsKey(place1.Name))
            {
                place2.Neighbors.Add(place1.Name, place1);
            }
        }

        public int Size()
        {
            return Places.Count;
        }


        public List<Place> GetBestRoute(Place start, Place finish)
        {
            var routes = GetRoutes(start, finish);
            List<Place> result = null;
            foreach (var route in routes)
            {
                if (result == null)
                {
                    result = route;
                }
                else if (result.Count > route.Count)
                {
                    result = route;
                }
            }
            return result;
        }

        private List<List<Place>> GetRoutes(Place start, Place destination)
        {
            var routes = new List<List<Place>>();
            var route = new List<Place>();
            route.Add(start);
            if (start.Neighbors.ContainsKey(destination.Name))
            {
                route.Add(destination);
                routes.Add(route);
                return routes;
            }
            foreach (var neighbor in start.Neighbors.Values)
            {
                GenerateRoute(neighbor, destination, route, routes);
            }
            return routes;
        }

        private void GenerateRoute(Place current, Place destination, List<Place> route, List<List<Place>> routes)
        {
            route.Add(current);
            if (current == destination)
            {
                routes.Add(route);
            }

            foreach (var neighbor in current.Neighbors.Values)
            {
                var newRoute = new List<Place>(route);
                if (route.Contains(neighbor))
                {
                    continue;
                }
                if (route.Contains(destination))
                {
                    continue;
                }
                else
                    GenerateRoute(neighbor, destination, newRoute, routes);
            }
        }
    }

    public class Place
    {
        public Place(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

        public Dictionary<string, Place> Neighbors { get; } = new Dictionary<string, Place>();

    }
}

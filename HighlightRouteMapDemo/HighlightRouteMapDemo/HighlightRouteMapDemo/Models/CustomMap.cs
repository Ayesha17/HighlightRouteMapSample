using System.Collections.Generic;
using Xamarin.Forms.Maps;

namespace HighlightRouteMapDemo.Models
{
    public class CustomMap : Map
    {
        public bool DrawCircle { get; set; }
        public List<Position> RouteCoordinates { get; set; }
        public CustomCircle Circle { get; set; }
        

        public CustomMap()
        {
            RouteCoordinates = new List<Position>();
        }
    }
}

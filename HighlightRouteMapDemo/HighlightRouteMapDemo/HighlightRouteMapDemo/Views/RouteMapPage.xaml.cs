
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace HighlightRouteMapDemo.Models
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RouteMapPage : ContentPage
	{
		public RouteMapPage ()
		{
			
			InitializeComponent ();

            var pin1 = new Pin()
            {
                Position = new Position(37.785559, -122.396728),
                Label = "1"
            };
            var pin2 = new Pin()
            {
                Position = new Position(37.780624, -122.390541),
                Label = "2"
            };
            var pin3 = new Pin()
            {
                Position = new Position(37.777113, -122.394983),
                Label = "3"
            };
            var pin4 = new Pin()
            {
                Position = new Position(37.776831, -122.394627),
                Label = "4"
            };
            customMap.Pins.Add(pin1);
            customMap.Pins.Add(pin2);
            customMap.Pins.Add(pin3);
            customMap.Pins.Add(pin4);
            customMap.RouteCoordinates.Add(new Position(37.785559, -122.396728));
            customMap.RouteCoordinates.Add(new Position(37.780624, -122.390541));
            customMap.RouteCoordinates.Add(new Position(37.777113, -122.394983));
            customMap.RouteCoordinates.Add(new Position(37.776831, -122.394627));
            customMap.RouteCoordinates.Add(new Position(37.785559, -122.396728));
            
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(37.79752, -122.40183), Distance.FromMiles(1.0)));
        }


    }
}

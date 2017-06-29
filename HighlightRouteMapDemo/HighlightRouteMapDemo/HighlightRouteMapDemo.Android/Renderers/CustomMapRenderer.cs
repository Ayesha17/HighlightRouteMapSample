using System.Collections.Generic;
using Android.Views;
using Xamarin.Forms.Maps.Android;
using Xamarin.Forms;
using HighlightRouteMapDemo.Models;
using Xamarin.Forms.Maps;
using HighlightRouteMapDemo.Droid.Renderers;
using Android.Gms.Maps;
using Xamarin.Forms.Platform.Android;
using Android.Gms.Maps.Model;
using System;
using MapKit;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace HighlightRouteMapDemo.Droid.Renderers
{
    public class CustomMapRenderer : MapRenderer, IOnMapReadyCallback
    {
        bool isLoaded = false;
        GoogleMap map;
        List<Position> routeCoordinates;
        bool isCircle;       
        CustomCircle circle;


        protected override void OnElementChanged(ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                isCircle = formsMap.DrawCircle;
                if (!isCircle)
                {
                    routeCoordinates = formsMap.RouteCoordinates;
                    Control.GetMapAsync(this);
                   
                }
                if (isCircle)
                {
                    circle = formsMap.Circle;
                    //Control.GetMapAsync(this);
                }
                                
            }
        }

        
        public void OnMapReady(GoogleMap googleMap)
        {
            map = googleMap;

            if (!isCircle)
            {

                var polylineOptions = new PolylineOptions();
                polylineOptions.InvokeColor(0x66FF0000);

                foreach (var position in routeCoordinates)
                {
                    polylineOptions.Add(new LatLng(position.Latitude, position.Longitude));
                }

                map.AddPolyline(polylineOptions);
            }
            if (isCircle)
            {
                var circleOptions = new CircleOptions();
                circleOptions.InvokeCenter(new LatLng(circle.Position.Latitude, circle.Position.Longitude));
                circleOptions.InvokeRadius(circle.Radius);
                circleOptions.InvokeFillColor(0X00FFFFFF);
                circleOptions.InvokeStrokeColor(0X66FF0000);
                circleOptions.InvokeStrokeWidth(3);
                map.AddCircle(circleOptions);

            }
        }
                    
    }
}
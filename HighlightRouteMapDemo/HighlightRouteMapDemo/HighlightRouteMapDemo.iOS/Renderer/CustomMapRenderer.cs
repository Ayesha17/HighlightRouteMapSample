using System;
using CoreLocation;
using HighlightRouteMapDemo.iOS;
using HighlightRouteMapDemo.Models;
using MapKit;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Maps.iOS;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace HighlightRouteMapDemo.iOS
{
	public class CustomMapRenderer : MapRenderer
	{
		MKMapView nativeMap;
		bool isLoaded = false;
		MKCircleRenderer circleRenderer;
		MKPolylineRenderer polylineRenderer;
		bool isCircle;



			protected override void OnElementChanged(ElementChangedEventArgs<View> e)
		{
			base.OnElementChanged(e);
			if (isLoaded)
			{
				nativeMap.RemoveOverlays(nativeMap.Overlays);
			}
			if (e.OldElement != null)
			{
				 nativeMap = Control as MKMapView;
				nativeMap.OverlayRenderer = null;
			}

			if (e.NewElement != null)
			{
				
					
				var formsMap = (CustomMap)e.NewElement;
				nativeMap = Control as MKMapView;
				isCircle = formsMap.DrawCircle;
				if (!isCircle)
				{

					nativeMap.OverlayRenderer = GetOverlayRenderer;

					CLLocationCoordinate2D[] coords = new CLLocationCoordinate2D[formsMap.RouteCoordinates.Count];

					int index = 0;
					foreach (var position in formsMap.RouteCoordinates)
					{
						coords[index] = new CLLocationCoordinate2D(position.Latitude, position.Longitude);
						index++;
					}

					var routeOverlay = MKPolyline.FromCoordinates(coords);
					nativeMap.AddOverlay(routeOverlay);
				}
				if (isCircle)
				{
					var circle = formsMap.Circle;
					nativeMap.OverlayRenderer = GetOverlayRenderer;
					var circleOverlay = MKCircle.Circle(new CoreLocation.CLLocationCoordinate2D(circle.Position.Latitude, circle.Position.Longitude), circle.Radius);
					nativeMap.AddOverlay (circleOverlay);
				}
					
			}
		}
		MKOverlayRenderer GetOverlayRenderer(MKMapView mapView, IMKOverlay overlay)
		{
			if (!isCircle)
			{

				if (polylineRenderer == null)
				{
					polylineRenderer = new MKPolylineRenderer(overlay as MKPolyline);
					polylineRenderer.FillColor = UIColor.Blue;
					polylineRenderer.StrokeColor = UIColor.Red;
					polylineRenderer.LineWidth = 3;
					polylineRenderer.Alpha = 0.4f;
				}
				isLoaded = true;
				return polylineRenderer;
			}
			if (isCircle)
			{
				 if (circleRenderer == null)
				{
					circleRenderer = new MKCircleRenderer(overlay as MKCircle);
					circleRenderer.FillColor = UIColor.Red;
					circleRenderer.Alpha = 0.4f;
				}
				isLoaded = true;
				return circleRenderer;
			}
			return polylineRenderer;
		}
	}

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HighlightRouteMapDemo.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ShapeSelectionPage : ContentPage
	{
		public ShapeSelectionPage ()
		{
			InitializeComponent ();
		}

        private void Button_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Models.RouteMapPage());
        }

        private void Button_Clicked_1(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CircleRoutePage());
        }
    }
}

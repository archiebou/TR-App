using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TravelRecordApp
{	
	public partial class HomePage : TabbedPage
	{	
		public HomePage ()
		{
			InitializeComponent ();
		}

        void addToolbarItem_Clicked(System.Object sender, System.EventArgs e)
        {
			Navigation.PushAsync(new NewTravelPage());
        }
    }
}


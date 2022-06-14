﻿using System;
using System.Collections.Generic;
using SQLite;
using TravelRecordApp.Model;
using Xamarin.Forms;

namespace TravelRecordApp
{	
	public partial class PostDetailPage : ContentPage
	{
        Post selectedPost;

		public PostDetailPage (Post selectedPost)
		{
			InitializeComponent ();

            this.selectedPost = selectedPost;
            experienceEntry.Text = selectedPost.Experience;
		}

        void updateButton_Clicked(System.Object sender, System.EventArgs e)
        {
            selectedPost.Experience = experienceEntry.Text;


			using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
			{
				conn.CreateTable<Post>();
				int rows = conn.Update(selectedPost);

				if (rows > 0)
					DisplayAlert("Seccess", "Experience succesfully updated", "OK");
				else
					DisplayAlert("Failure", "Experience failed to be updated", "OK");
			}
		}

        void deleteButton_Clicked(System.Object sender, System.EventArgs e)
        {
			using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
			{
				conn.CreateTable<Post>();
				int rows = conn.Delete(selectedPost);

				if (rows > 0)
					DisplayAlert("Seccess", "Experience succesfully deleted", "OK");
				else
					DisplayAlert("Failure", "Experience failed to be deleted", "OK");
			}
		}
    }
}


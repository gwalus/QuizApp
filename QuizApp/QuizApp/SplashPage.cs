﻿using QuizApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace QuizApp
{
    public class SplashPage : ContentPage
    {
        Image splashImage;

        public SplashPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            var sub = new AbsoluteLayout();
            splashImage = new Image
            {
                Source = "quiz_app_logo.png",
                WidthRequest = 100,
                HeightRequest = 100
            };

            AbsoluteLayout.SetLayoutFlags(splashImage, AbsoluteLayoutFlags.PositionProportional);

            AbsoluteLayout.SetLayoutBounds(splashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));

            sub.Children.Add(splashImage);

            this.BackgroundColor = Color.FromHex("#000");
            this.Content = sub;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await splashImage.ScaleTo(4, 1500);
            await splashImage.RotateTo(180, 500);
            await splashImage.ScaleTo(3, 1000);
            await splashImage.RotateTo(360, 500);
            

            //.ScaleTo(0.9, 1500, Easing.Linear);
            //await splashImage.ScaleTo(150, 1200, Easing.Linear);
            Application.Current.MainPage = new NavigationPage(new WelcomePage());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HNUiMap.pages.Feedback
{
    public class RatingScale : ContentView
    {
        public event EventHandler<int> RatingSelected;

        public int MaxRating { get; set; } = 5;
        private int _currentRating = 0;

        public RatingScale()
        {
            Initialize();
        }

        private void Initialize()
        {
            var layout = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 5
            };

            for (int i = 1; i <= MaxRating; i++)
            {
                var starLabel = new Label
                {
                    Text = "★",
                    FontSize = 24,
                    GestureRecognizers = { new TapGestureRecognizer { Command = new Command<int>((rating) => OnStarTapped(rating)), CommandParameter = i } }
                };

                layout.Children.Add(starLabel);
            }

            Content = layout;
        }

        private void OnStarTapped(int starIndex)
        {
            _currentRating = starIndex;
            RatingSelected?.Invoke(this, _currentRating);
            UpdateStarColors();
        }

        private void UpdateStarColors()
        {
            var starLabels = (Content as StackLayout)?.Children;

            if (starLabels != null)
            {
                for (int i = 0; i < starLabels.Count; i++)
                {
                    if (starLabels[i] is Label starLabel)
                    {
                        starLabel.TextColor = i < _currentRating ? Color.Yellow : Color.Gray;
                    }
                }
            }
        }
    }
}
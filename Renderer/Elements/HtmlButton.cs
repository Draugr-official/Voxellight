using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Voxellight.Renderer.Elements
{
    /// <summary>
    /// Html button element
    /// </summary>
    class HtmlButton : StackPanel
    {
        /// <summary>
        /// </inherit>
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="Parent"></param>
        public HtmlButton(HtmlNode Node, StackPanel Parent)
        {
            /* Create button elements */
            Border ButtonBorder = new Border()
            {
                Background = new SolidColorBrush(Color.FromRgb(239, 239, 239)),
                HorizontalAlignment = HorizontalAlignment.Left,
                Margin = new Thickness(0, 14, 0, 0),
                Child = this,

                MinHeight = 6,
                MinWidth = 16,

                BorderThickness = new Thickness(1, 1, 1, 1),
                CornerRadius = new CornerRadius(2),
                BorderBrush = new SolidColorBrush(Color.FromRgb(118, 118, 118)),

                Padding = new Thickness(6, 1, 6, 1)
            };

            Label ButtonLabel = new Label()
            {
                Content = Node.InnerText == "" ? "Press me!" : Node.InnerText,
                FontFamily = new FontFamily("Arial"),
                FontSize = 13.33,

                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top,

                Padding = new Thickness(0, 0, 0, 0),

            };

            /* Assign all events */
            ButtonBorder.MouseEnter += ((object sender, MouseEventArgs e) =>
            {
                Border b = (Border)sender;
                b.Background = new SolidColorBrush(Color.FromRgb(229, 229, 229));
            });

            ButtonBorder.MouseLeave += ((object sender, MouseEventArgs e) =>
            {
                Border b = (Border)sender;
                b.Background = new SolidColorBrush(Color.FromRgb(239, 239, 239));
            });

            ButtonBorder.MouseDown += ((object sender, MouseButtonEventArgs e) =>
            {
                Border b = (Border)sender;
                b.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            });

            ButtonBorder.MouseUp += ((object sender, MouseButtonEventArgs e) =>
            {
                Border b = (Border)sender;
                b.Background = new SolidColorBrush(Color.FromRgb(229, 229, 229));
            });

            /* Finalize */
            this.Children.Add(ButtonLabel);
            Parent.Children.Add(ButtonBorder);
        }
    }
}

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
    /// Html paragraph element
    /// </summary>
    class HtmlParagraph : StackPanel
    {
        /// <summary>
        /// </inherit>
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="Parent"></param>
        public HtmlParagraph(HtmlNode Node, StackPanel Parent)
        {
            /* Create paragraph element */
            Label Paragraph = new Label()
            {
                FontFamily = new FontFamily("Times New Roman"),
                FontSize = 16,
                Foreground = Brushes.Black,
                Content = Node.InnerText,
                Padding = new Thickness(0, 0, 0, 0)
            };

            /* Finalize */
            this.Children.Add(Paragraph);
            this.Background = Brushes.Red;
            Parent.Children.Add(this);
        }
    }
}

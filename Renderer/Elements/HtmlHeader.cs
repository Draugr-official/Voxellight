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
    /// Html header element
    /// </summary>
    class HtmlHeader : StackPanel
    {
        /// <summary>
        /// </inherit>
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="Parent"></param>
        /// <param name="HeaderType"></param>
        public HtmlHeader(HtmlNode Node, StackPanel Parent, int HeaderType)
        {
            /* Initialize */
            int Margins = 0;

            this.Background = Brushes.Blue;
            Label Header = new Label();

            /* Determine header type */
            switch (HeaderType)
            {
                case 1:
                    {
                        Header.FontSize = 32;
                        Margins = 21;
                        break;
                    }
                case 2:
                    {
                        Header.FontSize = 24;
                        Margins = 10;
                        break;
                    }
                case 3:
                    {
                        Header.FontSize = 18.72;
                        Margins = 20;
                        break;
                    }
                case 4:
                    {
                        Header.FontSize = 16;
                        Margins = 24;
                        break;
                    }
                case 5:
                    {
                        Header.FontSize = 13.28;
                        Margins = 25;
                        break;
                    }
                case 6:
                    {
                        Header.FontSize = 10.72;
                        Margins = 12;
                        break;
                    }
            }

            /* Design header accordingly */
            Header.FontFamily = new FontFamily("Times New Roman");
            Header.FontWeight = FontWeight.FromOpenTypeWeight(600);
            Header.Content = Node.InnerText;
            Header.Foreground = Brushes.Black;

            Header.Padding = new Thickness(0, 0, 0, 0);

            this.Margin = new Thickness(0, Margins, 0, Margins);

            /* Finalize */
            this.Children.Add(Header);
            Parent.Children.Add(this);
        }
    }
}

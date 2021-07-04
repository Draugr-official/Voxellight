using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using HtmlAgilityPack;
using Voxellight.Renderer.Elements;

namespace Voxellight.Renderer
{
    /// <summary>
    /// Html renderer class
    /// </summary>
    class HtmlRenderer
    {
        /// <summary>
        /// Target html code
        /// </summary>
        string Html { get; set; }

        /// <summary>
        /// Render target
        /// </summary>
        StackPanel Frame { get; set; }

        /// <summary>
        /// </inherit>
        /// </summary>
        /// <param name="Html"></param>
        public HtmlRenderer(string Html, StackPanel Frame)
        {
            this.Html = Html;
            this.Frame = Frame;
        }

        /// <summary>
        /// Renders given html code
        /// </summary>
        public void Load()
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(Html);

            StackPanel Body = new StackPanel();
            Body.Margin = new Thickness(8,8,8,8);
            Frame.Children.Add(Body);

            LoadElement(htmlDoc.DocumentNode, Body);
        }

        /// <summary>
        /// Renders element and given descendants
        /// </summary>
        /// <param name="Node"></param>
        private void LoadElement(HtmlNode Node, StackPanel Parent)
        {
            if (Node.Name.StartsWith("h") && int.TryParse(Node.Name.Remove(0, 1), out int HeaderType))
            {
                Parent = this.LoadHeader(Node, Parent, HeaderType);
                return;
            }

            if(Node.Name == "button")
            {
                Parent = this.LoadButton(Node, Parent); 
                return;
            }

            if (Node.Name == "p")
            {
                Parent = this.LoadParagraph(Node, Parent);
                return;
            }

            foreach (HtmlNode ChildNode in Node.ChildNodes)
            {
                this.LoadElement(ChildNode, Parent);
            }
        }

        /// <summary>
        /// Renders a new button
        /// </summary>
        /// <param name="Node"></param>
        /// <returns></returns>
        private StackPanel LoadButton(HtmlNode Node, StackPanel Parent)
        {
            HtmlButton Button = new HtmlButton(Node, Parent);
            return Button;
        }

        /// <summary>
        /// Renders a new header
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="HeaderType"></param>
        private StackPanel LoadHeader(HtmlNode Node, StackPanel Parent, int HeaderType)
        {
            HtmlHeader Header = new HtmlHeader(Node, Parent, HeaderType);
            return Header;
        }

        /// <summary>
        /// Renders a new paragraph
        /// </summary>
        /// <param name="Node"></param>
        /// <param name="Parent"></param>
        /// <returns></returns>
        private StackPanel LoadParagraph(HtmlNode Node, StackPanel Parent)
        {
            HtmlParagraph Paragraph = new HtmlParagraph(Node, Parent);
            return Paragraph;
        }
    }
}

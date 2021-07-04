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

namespace Voxellight.Renderer.Styler
{
    /// <summary>
    /// Reads and translates attributes
    /// </summary>
    class AttributeReader
    {
        /// <summary>
        /// Gets / sets the raw attributes
        /// </summary>
        HtmlAttributeCollection Attributes { get; set; }

        /// <summary>
        /// Gets / sets the translated attributes
        /// </summary>
        TranslatedAttributeCollection TranslatedAttributes = new TranslatedAttributeCollection();

        /// <summary>
        /// </inherit>
        /// </summary>
        /// <param name="Attributes"></param>
        public AttributeReader(HtmlAttributeCollection Attributes)
        {
            this.Attributes = Attributes;
        }

        public TranslatedAttributeCollection TranslateAttributes()
        {
            foreach(HtmlAttribute Attribute in this.Attributes)
            {
                TranslatedAttribute translatedAttribute = new TranslatedAttribute()
                {
                    Name = Attribute.Name
                };

                switch(Attribute.Name)
                {
                    case "Margin":
                        {
                            if(Attribute.Value.Contains(","))
                            {
                                ThicknessConverter thicknessConverter = new ThicknessConverter();
                                Thickness Result = (Thickness)thicknessConverter.ConvertFromString(Attribute.Value);

                                translatedAttribute.Data = Result;
                            }
                            else
                            {
                                int Margin = Convert.ToInt32(Attribute.Value);
                                translatedAttribute.Data = new Thickness(Margin);
                            }
                            break;
                        }

                    default:
                        {
                            translatedAttribute.Data = Attribute.Value;
                            break;
                        }
                }

                this.TranslatedAttributes.Add(Attribute.Name, translatedAttribute);
            }

            return this.TranslatedAttributes;
        }
    }
}

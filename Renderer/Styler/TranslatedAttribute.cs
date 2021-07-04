using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voxellight.Renderer.Styler
{
    /// <summary>
    /// Translated attribute
    /// </summary>
    struct TranslatedAttribute
    {
        /// <summary>
        /// Name of the translated attribute
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Data of the translated attribute
        /// </summary>
        public object Data { get; set; }
    }

    /// <summary>
    /// Translated attribute collection
    /// </summary>
    class TranslatedAttributeCollection : Dictionary<string, TranslatedAttribute>
    {
        /// <summary>
        /// </inherit>
        /// </summary>
        public TranslatedAttributeCollection() { }
    }
}

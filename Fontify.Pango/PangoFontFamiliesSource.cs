using System;
using System.Collections;
using System.Collections.Generic;
using Pango;

namespace Fontify.Pango
{
    public class PangoFontFamiliesSource : IFontFamiliesSource
    {
        private string [] fonts;
        private Context pangoContext;

        public PangoFontFamiliesSource ( Context pangoContext )
        {
            this.pangoContext = pangoContext;
            Update ();
        }

        private void Update ()
        {
            var pangoFontFamilies = pangoContext.Families;

            fonts = new string[pangoFontFamilies.Length];

            for ( int n = 0 ; n < fonts.Length ; n++ )
            {
                var pangoFontFamily = pangoFontFamilies[n];
                fonts[n] = pangoFontFamily.Name;
            }
        }

        public IEnumerator<string> GetEnumerator ()
        {
            foreach ( var font in fonts )
            {
                yield return font;
            }
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            return this.GetEnumerator ();
        }
    }
}


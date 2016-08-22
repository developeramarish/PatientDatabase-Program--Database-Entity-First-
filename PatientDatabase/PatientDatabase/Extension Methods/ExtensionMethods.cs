using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PatientDatabase
{
    public static class ExtensionMethods
    {
        // Extension Method for RichTextBox To Allow for color change
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }

        // Extension Method for RichTextBox To Allow for font change
        public static void AppendText(this RichTextBox box, string text, Font font)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionFont = font;
            box.AppendText(text);
            box.SelectionFont = box.Font;
        }

        // Extension Method for RichTextBox To Allow for color and font change
        public static void AppendText(this RichTextBox box, string text, Color color, Font font)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.SelectionFont = font;
            box.AppendText(text);
            box.SelectionFont = box.Font;
            box.SelectionColor = box.ForeColor;
        }
    }
}

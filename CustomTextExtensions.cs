using System.Drawing;
using System.Windows.Forms;

namespace Dart_Class_Generator
{
    public static class CustomTextExtensions
    {
        public static void ColorText(RichTextBox rtb, string word, Color textColor)
        {
            int startindex = 0;

            while (startindex < rtb.TextLength)
            {
                int wordstartIndex = rtb.Find(word, startindex, RichTextBoxFinds.MatchCase);
                if (wordstartIndex != -1)
                {
                    rtb.SelectionStart = wordstartIndex;
                    rtb.SelectionLength = word.Length;
                    rtb.SelectionColor = textColor;
                }
                else break;
                startindex = wordstartIndex + word.Length;
            }
        }
        public static void ColorTextAll(RichTextBox rtb, string[] words, Color textColor)
        {
            foreach (string word in words)
            {
                int startindex = 0;

                while (startindex < rtb.TextLength)
                {
                    int wordstartIndex = rtb.Find(word, startindex, RichTextBoxFinds.MatchCase);
                    if (wordstartIndex != -1)
                    {
                        rtb.SelectionStart = wordstartIndex;
                        rtb.SelectionLength = word.Length;
                        rtb.SelectionColor = textColor;
                    }
                    else break;
                    startindex = wordstartIndex + word.Length;
                }
            }
        }

        public static void ColorQuotesText(RichTextBox rtb, string word, Color textColor)
        {
            int startindex = 0;

            while (startindex < rtb.TextLength)
            {
                int firstQuotes = rtb.Find(word, startindex, RichTextBoxFinds.MatchCase);
                int secondQuotes = rtb.Find(word, firstQuotes + 1, RichTextBoxFinds.MatchCase);
                if (firstQuotes != -1)
                {
                    rtb.SelectionStart = firstQuotes;
                    rtb.SelectionLength = secondQuotes - firstQuotes + 1;
                    rtb.SelectionColor = textColor;
                }
                else break;
                startindex = secondQuotes + 1;
            }
        }
        public static string TextBetweenCharacters(this string text, string firstChar, string lastChar)
        {
            int first = text.IndexOf(firstChar) + 1;
            int last = text.IndexOf(lastChar);
            return text.Substring(first, last - first);

        }
    }
}

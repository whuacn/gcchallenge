using System;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace GmatClubTest.QuestionRenderer
{
    internal abstract class Element
    {
        protected Renderer renderer;
        protected Size size;

        public Element(Renderer renderer)
        {
            this.renderer = renderer;
        }

        public Size Size
        {
            get { return size; }
        }

        public abstract void Draw(Graphics graphics, Point pos);
        public abstract bool CanCut(int width);
        public abstract Element Cut(int width);
    }

    internal class TextElement : Element
    {
        private string text;
        private Match match;

        public TextElement(string text, Renderer renderer) : base(renderer)
        {
            this.text = text;
            Init();
        }

        private void Init()
        {
            size = renderer.activeGraphics.MeasureString(text, renderer.font).ToSize();
            match = renderer.regexWord.Match(text);
        }

        public override void Draw(Graphics graphics, Point pos)
        {
            renderer.activeGraphics.DrawString(text, renderer.font, Brushes.Black, new PointF(pos.X, pos.Y));
        }

        public override bool CanCut(int width)
        {
            string s = match.Groups[0].Value;
            int len = renderer.activeGraphics.MeasureString(s, renderer.font).ToSize().Width;
            return len <= width;
        }

        public override Element Cut(int width)
        {
            string s = match.Groups[0].Value;
            int len = renderer.activeGraphics.MeasureString(s, renderer.font).ToSize().Width;

            if (len > width)
            {
                text = text.Substring(s.Length + 1);
                Init();
                return new TextElement(s, renderer);
            }

            string tmp = s;

            do
            {
                s = tmp;
                match = match.NextMatch();
                if (!match.Success) break;
                tmp += " " + match.Groups[0].Value;
                len = renderer.activeGraphics.MeasureString(tmp, renderer.font).ToSize().Width;
            } while (len < width);

            text = text.Substring(s.Length + 1);
            Init();
            return new TextElement(s, renderer);
        }

        public override string ToString()
        {
            return text;
        }
    }

    internal class FormulaElement : Element
    {
        private Image image;
        private string xmlText;

        private static Regex regexMtext =
            new Regex(@"<\s*mtext[^>]*>(.*?)<\s*/mtext\s*>", RegexOptions.IgnoreCase | RegexOptions.Singleline);

        private static Regex regexMtextConcat =
            new Regex(@"<\s*mtext([^>]*)>(.*?)<\s*/mtext\s*>\s*<\s*mtext\1>(.*?)<\s*/mtext\s*>",
                      RegexOptions.IgnoreCase | RegexOptions.Singleline);

        private StringBuilder stringBuilder = new StringBuilder();

        public FormulaElement(string xmlText, Renderer renderer) : base(renderer)
        {
            stringBuilder.Length = 0;
            stringBuilder.Append(xmlText);
            stringBuilder.Replace("&nbsp;", " ");
            for (;;)
            {
                Match m = regexMtextConcat.Match(stringBuilder.ToString());
                if (!m.Success) break;
                stringBuilder.Remove(m.Index, m.Length);
                stringBuilder.Insert(m.Index,
                                     String.Format("<mtext{0}>{1}{2}</mtext>", m.Groups[1], m.Groups[2], m.Groups[3]));
            }

            this.xmlText = stringBuilder.ToString();
            image = renderer.RenderFormula(this.xmlText);
            size = image.Size;
        }

        public override void Draw(Graphics graphics, Point pos)
        {
            graphics.DrawImageUnscaled(image, pos.X, pos.Y);
        }

        public override bool CanCut(int width)
        {
            return false;
        }

        public override Element Cut(int width)
        {
            throw new InvalidOperationException();
        }

        public override string ToString()
        {
            stringBuilder.Length = 0;
            Match m = regexMtext.Match(xmlText);
            while (m.Success)
            {
                stringBuilder.Append(m.Groups[1].Value);
                stringBuilder.Append(" ");
                m = m.NextMatch();
            }
            return stringBuilder.ToString();
        }
    }

    internal class NewLineElement : Element
    {
        public NewLineElement(Renderer renderer) : base(renderer)
        {
            size = new Size(0, 0);
        }

        public override void Draw(Graphics graphics, Point pos)
        {
        }

        public override bool CanCut(int width)
        {
            return false;
        }

        public override Element Cut(int width)
        {
            throw new InvalidOperationException();
        }

        public override string ToString()
        {
            return " ";
        }
    }
}
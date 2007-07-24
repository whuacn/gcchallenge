using System;
using System.Collections;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using GmatClubTest.Common;
using GmatClubTest.Data;
using MathML;
using MathML.Rendering;

namespace GmatClubTest.QuestionRenderer
{
    /// <summary>
    /// Renders questions.
    /// </summary>
    public class Renderer
    {
        private MathMLControl mathMLcontrol = new MathMLControl();
        private MathMLDocument mathMLDocument = new MathMLDocument();

        private Bitmap activeBuffer, smallBuffer, largeBuffer, smallBufferA, largeBufferA;
        internal Graphics activeGraphics, smallGraphics, largeGraphics, smallGraphicsA, largeGraphicsA;
        internal Font font = new Font("Arial", 10);
        private Point cursor = new Point(0, 0);
        private Pen pen = new Pen(Color.Gray);
        private Regex regex;
        private StringBuilder stringBuilder = new StringBuilder();
        internal Regex regexWord;
        private ArrayList elements = new ArrayList();

        public Renderer()
        {
            mathMLcontrol.BackColor = Color.White;
            largeBuffer = new Bitmap(655, 1200, PixelFormat.Format16bppRgb555);
            largeBufferA = new Bitmap(625, 1200, PixelFormat.Format16bppRgb555);
            smallBuffer = new Bitmap(318, 1200, PixelFormat.Format16bppRgb555);
            smallBufferA = new Bitmap(298, 1200, PixelFormat.Format16bppRgb555);
            largeGraphics = Graphics.FromImage(largeBuffer);
            smallGraphics = Graphics.FromImage(smallBuffer);
            largeGraphicsA = Graphics.FromImage(largeBufferA);
            smallGraphicsA = Graphics.FromImage(smallBufferA);
            regex = new Regex(@"<\s*math.*?<\s*/math\s*>", RegexOptions.IgnoreCase | RegexOptions.Singleline);
            regexWord = new Regex(@"[^ ]+", RegexOptions.Singleline);
            activeGraphics = largeGraphics;
        }

        public void RenderToString(QuestionSetsResultDetailsSet questionSetsResultsDetails)
        {
            foreach (QuestionSetsResultDetailsSet.AnswersRow row in questionSetsResultsDetails.Answers)
                row.QuestionText = RenderToString(row.QuestionText);
        }

        public string RenderToString(string question)
        {
            ArrayList elements = CreateElements(question);
            stringBuilder.Length = 0;
            foreach (Element element in elements)
                stringBuilder.Append(element.ToString());

            String s = stringBuilder.ToString();
            stringBuilder.Length = 0;
            bool isLastSpace = true;

            foreach (char o in s)
            {
                if (o == ' ' || o == '\r' || o == '\n')
                {
                    if (!isLastSpace) stringBuilder.Append(" ");
                    isLastSpace = true;
                }
                else
                {
                    stringBuilder.Append(o);
                    isLastSpace = false;
                }
            }

            return stringBuilder.ToString();
        }

        public Image RenderPasssageToQuestion(QuestionSet.QuestionsRow passsage)
        {
            InitBuffer(smallBuffer);
            RenderText(passsage.Text);
            return CreateImageFromActiveBuffer();
        }

        //  не смогло перегрузиьт лень разбираться
        public Image RenderAsString(string text)
        {
            InitBuffer(largeBuffer);

            RenderText(text);

            cursor.Y += 10;
            activeGraphics.DrawLine(pen, 0, cursor.Y, activeBuffer.Width, cursor.Y);
            ++cursor.Y;

            Image image = CreateImageFromActiveBuffer();

            return image;
        }

        public ImageSet Render(QuestionAnswerSet.QuestionsRow question)
        {
            ImageSet s = new ImageSet();

            InitBuffer(question.SubtypeId != (int) BuisinessObjects.Subtype.ReadingComprehensionQuestionToPassage
                           ? largeBuffer
                           : smallBuffer);

            //Render question's picture
            Image picture = question.IsPictureNull() ? null : Image.FromStream(new MemoryStream(question.Picture));
            if (picture != null)
            {
                activeGraphics.DrawImageUnscaled(picture, (activeBuffer.Width - picture.Width)/2, 0);
                cursor.Y = picture.Height + 12;
            }

            RenderText(question.Text);

            cursor.Y += 10;
            activeGraphics.DrawLine(pen, 0, cursor.Y, activeBuffer.Width, cursor.Y);
            ++cursor.Y;

            s.question = CreateImageFromActiveBuffer();

            QuestionAnswerSet.AnswersRow[] ar = question.GetAnswersRows();
            s.answers = new Bitmap[ar.Length];
            int i = 0;
            foreach (QuestionAnswerSet.AnswersRow row in ar)
            {
                InitBuffer(question.SubtypeId != (int) BuisinessObjects.Subtype.ReadingComprehensionQuestionToPassage
                               ? largeBufferA
                               : smallBufferA);
                RenderText(row.Text);
                s.answers[i] = CreateImageFromActiveBuffer();
                ++i;
            }

            return s;
        }

        private Image CreateImageFromActiveBuffer()
        {
            Image s = new Bitmap(activeBuffer.Width, Math.Min(cursor.Y, activeBuffer.Height));
            Graphics qg = Graphics.FromImage(s);
            qg.DrawImageUnscaled(activeBuffer, 0, 0);
            return s;
        }

        private void InitBuffer(Bitmap buffer)
        {
            activeBuffer = buffer;

            for (;;)
            {
                if (buffer == largeBuffer)
                {
                    activeGraphics = largeGraphics;
                    break;
                }
                if (buffer == largeBufferA)
                {
                    activeGraphics = largeGraphicsA;
                    break;
                }
                if (buffer == smallBuffer)
                {
                    activeGraphics = smallGraphics;
                    break;
                }
                if (buffer == smallBufferA)
                {
                    activeGraphics = smallGraphicsA;
                    break;
                }
            }

            cursor.X = 0;
            cursor.Y = 0;

            activeGraphics.FillRectangle(Brushes.White, 0, 0, activeBuffer.Width, activeBuffer.Height);
        }

        private void RenderText(string text)
        {
            ArrayList elements = CreateElements(text);
            RenderElements(elements, activeGraphics, activeBuffer.Width, ref cursor);
        }

        private void RenderElements(ArrayList elements, Graphics graphics, int width, ref Point cursor)
        {
            int lineWidth = 0;
            int maxElementHeight = 0;
            ArrayList line = new ArrayList(elements.Count);
            Point p = new Point();
            int x = cursor.X;

            foreach (Element element in elements)
            {
                int newWidth = lineWidth + element.Size.Width;
                if (newWidth > width || element is NewLineElement)
                {
                    int toCut = width - lineWidth;
                    if (element.CanCut(toCut))
                    {
                        Element ne = element.Cut(toCut);
                        line.Add(ne);
                        if (ne.Size.Height > maxElementHeight)
                            maxElementHeight = ne.Size.Height;
                        newWidth = element.Size.Width;
                    }
                    else
                        newWidth = 0;

                    foreach (Element e in line)
                    {
                        p.X = cursor.X;
                        p.Y = cursor.Y + (maxElementHeight - e.Size.Height)/2;
                        e.Draw(graphics, p);
                        cursor.X += e.Size.Width;
                    }

                    cursor.X = x;
                    cursor.Y += maxElementHeight;

                    line.Clear();
                    maxElementHeight = 0;
                    lineWidth = 0;
                }

                lineWidth = newWidth;
                line.Add(element);
                if (element.Size.Height > maxElementHeight)
                    maxElementHeight = element.Size.Height;
            }

            foreach (Element e in line)
            {
                p.X = cursor.X;
                p.Y = cursor.Y + (maxElementHeight - e.Size.Height)/2;
                e.Draw(graphics, p);
                cursor.X += e.Size.Width;
            }

            if (line.Count > 0)
                cursor.Y += maxElementHeight;
        }

        private void AddText(String s)
        {
            stringBuilder.Length = 0;
            foreach (char c in s)
            {
                if (c == '\n')
                {
                    if (stringBuilder.Length > 0) elements.Add(new TextElement(stringBuilder.ToString(), this));
                    elements.Add(new NewLineElement(this));
                    stringBuilder.Length = 0;
                }
                else
                    stringBuilder.Append(c);
            }
            if (stringBuilder.Length > 0) elements.Add(new TextElement(stringBuilder.ToString(), this));
        }

        private ArrayList CreateElements(string text)
        {
            elements.Clear();
            int lastCapturePos = -1;
            Match m = regex.Match(text);
            while (m.Success)
            {
                if (lastCapturePos + 1 != m.Groups[0].Index)
                    AddText(text.Substring(lastCapturePos + 1, m.Groups[0].Index - lastCapturePos - 1));

                elements.Add(new FormulaElement(m.Groups[0].Value, this));

                lastCapturePos = m.Groups[0].Index + m.Groups[0].Length - 1;

                m = m.NextMatch();
            }

            if (text.Length > lastCapturePos + 1)
                AddText(text.Substring(lastCapturePos + 1));

            return elements;
        }

        internal Image RenderFormula(string xml)
        {
            mathMLDocument.LoadXml(xml);
            mathMLcontrol.MathElement = (MathMLMathElement) mathMLDocument.DocumentElement;
            return mathMLcontrol.GetImage(typeof (Bitmap));
        }
    }
}
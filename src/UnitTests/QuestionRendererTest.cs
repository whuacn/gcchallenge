using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;
using GmatClubTest.QuestionRenderer;
using NUnit.Framework;

namespace GmatClubTest.UnitTests
{
    /// <summary>
    /// Summary description for QuestionRendererTest.
    /// </summary>
    [TestFixture]
    public class QuestionRendererTest
    {
        private Random random = new Random();
        private Manager manager;
        private Renderer renderer = new Renderer();
        private String text;

        [TestFixtureSetUp]
        public void Init()
        {
            manager = Manager.CreareManagerUseSql(SystemInformation.ComputerName, "re2085", "sys1157");
            /*UserSet u = new UserSet();*/
            manager.CreateUser("UnitTestUser" + random.Next().ToString(), random.Next().ToString(), "UnitTestUserName",
                               u);
            manager.UserId = u.Users[0].Id;

            String formula1 = "<math><mfrac><mi>x</mi><mi>y</mi></mfrac></math>";
            String formula2 =
                @"<math display = 'block'>
  <mrow>
    <mi>x</mi>
    <mo>=</mo>
    <mrow>
      <munderover>
        <mo>&sum;</mo>
        <mn>1</mn>
        <mn>1</mn>
      </munderover>
      <mfrac numalign='left' denomalign='right' bevelled='true'>
        <mn>3</mn>
        <mn>4</mn>
      </mfrac>
      <mo>&lowast;</mo>
    </mrow>
    <mroot>
      <mrow>
        <mi mathvariant = 'italic'>cos</mi>
        <mtext>&nbsp;</mtext>
        <mi>x</mi>
      </mrow>
      <mn>3</mn>
    </mroot>
  </mrow>
</math>";
            String formula3 =
                @"<math display = 'block'>
  <mtable columnalign = 'left'>
    <mtr>
      <mtd>
        <mtext>Test</mtext>
        <mtext>&nbsp;</mtext>
        <mtext>question</mtext>
      </mtd>
    </mtr>
    <mtr>
      <mtd>
        <mtext mathsize = '17pt'>Wha</mtext>
        <mtext mathsize = '17pt'>t</mtext>
        <mtext mathsize = '17pt'>&nbsp;is&nbsp;this?</mtext>
      </mtd>
    </mtr>
    <mtr> 
      <mtd>
        <mrow></mrow>
      </mtd>
    </mtr>
    <mtr>
      <mtd>
        <mrow></mrow>
      </mtd>
    </mtr>
    <mtr>
      <mtd>
        <mi>s</mi>
        <mo>=</mo>
        <mfrac>
          <mroot>
            <mrow>
              <mi mathvariant = 'italic'>cos</mi>
              <mtext>&nbsp;</mtext>
              <mi>x</mi>
            </mrow>
            <mn>2</mn>
          </mroot>
          <mrow>
            <mi mathvariant = 'italic'>sin</mi>
            <mtext>&nbsp;</mtext>
            <mi mathvariant = 'italic'>&pi;</mi>
          </mrow>
        </mfrac>
        <mo>&rArr;</mo>
        <mrow>
          <msubsup>
            <mo>&prod;</mo>
            <mi>a</mi>
            <mi>b</mi>
          </msubsup>
          <msub>
            <mi mathvariant = 'italic'>&Psi;</mi>
            <mn>2</mn>
          </msub>
        </mrow>
      </mtd>
    </mtr>
    <mtr>
      <mtd>
        <mrow></mrow>
      </mtd>
    </mtr>
    <mtr>
      <mtd>
        <mtext>The&nbsp;end</mtext>
      </mtd>
    </mtr>
  </mtable>
</math>";

            text =
                "Test Question.\nIt is a very long line. It is a very long line. It is a very long line. It is a very long line. It is a very long line. It is a very long line. It is a very long line.\nFormula1: '" +
                formula1 + "' Continue!\nFormula2: '" + formula2 + "'\n" + formula3 + "\n----------";
        }

        [TestFixtureTearDown]
        public void Dispose()
        {
            UserSet u = new UserSet();
            manager.GetUsers(u);

            foreach (UserSet.UsersRow row in u.Users.Rows)
                if (row.Login.StartsWith("UnitTestUser")) row.Delete();

            manager.UpdateUsers(u);

            manager.Dispose();
        }

        [Test]
        public void RenderToString()
        {
            Console.WriteLine(renderer.RenderToString(text));
        }

        [Test]
        public void Render()
        {
            string fileName = "c:\\test.gif";
            File.Exists(fileName);
            File.Delete(fileName);

            QuestionAnswerSet q = new QuestionAnswerSet();

            Bitmap bitmap = new Bitmap(50, 50, PixelFormat.Format16bppRgb555);

            for (int i = 0; i < 50; ++i)
                bitmap.SetPixel(i, i, Color.Red);

            MemoryStream stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Gif);

            byte[] picture = stream.GetBuffer();

            QuestionAnswerSet.QuestionsRow row =
                q.Questions.AddQuestionsRow((byte) Question.Type.Quantitative, (byte) Question.Subtype.DataSufficiency,
                                            0, text, picture);

            ImageSet set = renderer.Render(row);

            //set.Question.Save(fileName, ImageFormat.Gif);

            int j = 0;
            foreach (Image image in set.Answers)
            {
                image.Save(fileName + j.ToString(), ImageFormat.Gif);
                ++j;
            }
        }
    }
}
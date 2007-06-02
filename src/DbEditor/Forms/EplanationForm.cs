using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Win32;

namespace GmatClubTest.DbEditor.Forms
{
    public partial class EplanationForm : Form
    {
        public EplanationForm(string text)
        {
            InitializeComponent();
            textBox.Text = text;
            textBox.Enabled = !TextWithFormula;
        }

        public override void Refresh()
        {
            base.Refresh();
            textBox.Enabled = !TextWithFormula;
        }

        private bool TextWithFormula
        {
            get { return textBox.Text.Contains("<math display"); }
        }

        public string EplanationText
        {
            get { return textBox.Text; }
            private set { textBox.Text = value; }
        }

        private void editFormulaButton_Click(object sender, EventArgs e)
        {
            string formulatorPath;
            try
            {
                formulatorPath = (String)Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Hermitech Laboratory\Formulator\Settings\").GetValue(@"path");
            }
            catch
            {
                MessageBox.Show("Formulator not installeted! Plese reinstall this application.", "Formulator", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (!TextWithFormula)
            {
                if (MessageBox.Show("Convert simple answer to answer with farmulas?", "Formulator", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }

                EplanationText = EplanationText.Insert(0, "<math display = 'block'><mrow><mi mathvariant = 'italic'>");
                EplanationText = EplanationText.Insert(EplanationText.Length, "</mi></mrow></math>");

                File.WriteAllText(Application.StartupPath + @"\eplanation.xml", EplanationText);
                ProcessStartInfo pInfo = new ProcessStartInfo();
                pInfo.Arguments = "\"" + Application.StartupPath + @"\answer.xml" + "\"";
                pInfo.FileName = formulatorPath + "Formulator.exe";
                Process p = Process.Start(pInfo);
                while (!p.HasExited)
                {
                    Thread.Sleep(100);
                }
                EplanationText = File.ReadAllText(Application.StartupPath + @"\eplanation.xml");
            }

            Refresh();
        }
        
    }
}
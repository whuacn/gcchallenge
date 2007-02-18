using System;
using System.Collections;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Windows.Forms;
using GmatClubTest.Common;
using GmatClubTest.DbEditor.BusinessObjects;

namespace GmatClubTest.DbEditor
{
    /// <summary>
    /// Summary description for TypeSelectionForm.
    /// </summary>
    public class TypeSelectionForm : Form
    {
        private Button okButton;
        private Button cancelButton;
        private GroupBox groupBox1;
        private Container components = null;
        private RadioButton radioMixed;
        private RadioButton radioQauantitative;
        private RadioButton radioVerbal;
        private RadioButton radioAlgebra;
        private RadioButton radioArithmetic;
        private RadioButton radioReadingComprehension;
        private RadioButton radioSentenceCorrection;
        private RadioButton radioCriticalReasoning;
        private QuestionType baseQuestionType;
        private QuestionType questionType;
        private ListDictionary radioButtonToQuestionType = new ListDictionary();
        private RadioButton radioStatistics;
        private RadioButton radioProbability;
        private RadioButton radioGeometry;
        private RadioButton radioCombinations;
        private RadioButton radioWordProblems;
        private ListDictionary questionTypeToRadioButton = new ListDictionary();

        public TypeSelectionForm()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();

            radioButtonToQuestionType.Add(radioMixed, QuestionType.CreateMixed());
            radioButtonToQuestionType.Add(radioQauantitative, new QuestionType(QuestionType.Type.Quantitative));
            radioButtonToQuestionType.Add(radioVerbal, new QuestionType(QuestionType.Type.Verbal));
            radioButtonToQuestionType.Add(radioAlgebra, new QuestionType(BuisinessObjects.Subtype.Algebra));
            radioButtonToQuestionType.Add(radioArithmetic, new QuestionType(BuisinessObjects.Subtype.Arithmetic));
            radioButtonToQuestionType.Add(radioCombinations, new QuestionType(BuisinessObjects.Subtype.Combinations));
            radioButtonToQuestionType.Add(radioCriticalReasoning, new QuestionType(BuisinessObjects.Subtype.CriticalReasoning));
            radioButtonToQuestionType.Add(radioGeometry, new QuestionType(BuisinessObjects.Subtype.Geometry));
            radioButtonToQuestionType.Add(radioProbability, new QuestionType(BuisinessObjects.Subtype.Probability));
            radioButtonToQuestionType.Add(radioSentenceCorrection, new QuestionType(BuisinessObjects.Subtype.SentenceCorrection));
            radioButtonToQuestionType.Add(radioStatistics, new QuestionType(BuisinessObjects.Subtype.Statistics));
            radioButtonToQuestionType.Add(radioWordProblems, new QuestionType(BuisinessObjects.Subtype.WordProblems));
            radioButtonToQuestionType.Add(radioReadingComprehension,
                                          new QuestionType(BuisinessObjects.Subtype.ReadingComprehensionQuestionToPassage));
            //radioButtonToQuestionType.Add(radioCriticalReasoning,
            //                              new QuestionType(BuisinessObjects.Subtype.CriticalReasoning));
            //radioButtonToQuestionType.Add(radioSentenceCorrection,
            //                              new QuestionType(BuisinessObjects.Subtype.SentenceCorrection));

            foreach (DictionaryEntry e in radioButtonToQuestionType)
                questionTypeToRadioButton.Add(e.Value, e.Key);
            
            BaseQuestionType = QuestionType.CreateMixed();
            QuestionType = QuestionType.CreateMixed();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypeSelectionForm));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioMixed = new System.Windows.Forms.RadioButton();
            this.radioQauantitative = new System.Windows.Forms.RadioButton();
            this.radioVerbal = new System.Windows.Forms.RadioButton();
            this.radioAlgebra = new System.Windows.Forms.RadioButton();
            this.radioArithmetic = new System.Windows.Forms.RadioButton();
            this.radioReadingComprehension = new System.Windows.Forms.RadioButton();
            this.radioSentenceCorrection = new System.Windows.Forms.RadioButton();
            this.radioCriticalReasoning = new System.Windows.Forms.RadioButton();
            this.radioCombinations = new System.Windows.Forms.RadioButton();
            this.radioGeometry = new System.Windows.Forms.RadioButton();
            this.radioProbability = new System.Windows.Forms.RadioButton();
            this.radioStatistics = new System.Windows.Forms.RadioButton();
            this.radioWordProblems = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.okButton.ImageIndex = 1;
            this.okButton.Location = new System.Drawing.Point(223, 290);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(88, 24);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cancelButton.ImageIndex = 0;
            this.cancelButton.Location = new System.Drawing.Point(317, 290);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(88, 24);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "Cancel";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioWordProblems);
            this.groupBox1.Controls.Add(this.radioStatistics);
            this.groupBox1.Controls.Add(this.radioProbability);
            this.groupBox1.Controls.Add(this.radioGeometry);
            this.groupBox1.Controls.Add(this.radioCombinations);
            this.groupBox1.Controls.Add(this.radioMixed);
            this.groupBox1.Controls.Add(this.radioQauantitative);
            this.groupBox1.Controls.Add(this.radioVerbal);
            this.groupBox1.Controls.Add(this.radioAlgebra);
            this.groupBox1.Controls.Add(this.radioArithmetic);
            this.groupBox1.Controls.Add(this.radioReadingComprehension);
            this.groupBox1.Controls.Add(this.radioSentenceCorrection);
            this.groupBox1.Controls.Add(this.radioCriticalReasoning);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(9, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(398, 273);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Question Types";
            // 
            // radioMixed
            // 
            this.radioMixed.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioMixed.Location = new System.Drawing.Point(16, 26);
            this.radioMixed.Name = "radioMixed";
            this.radioMixed.Size = new System.Drawing.Size(48, 24);
            this.radioMixed.TabIndex = 0;
            this.radioMixed.Text = "Mixed";
            this.radioMixed.CheckedChanged += new System.EventHandler(this.typeCheckedChanged);
            // 
            // radioQauantitative
            // 
            this.radioQauantitative.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioQauantitative.Location = new System.Drawing.Point(116, 26);
            this.radioQauantitative.Name = "radioQauantitative";
            this.radioQauantitative.Size = new System.Drawing.Size(80, 24);
            this.radioQauantitative.TabIndex = 1;
            this.radioQauantitative.Text = "Quantitative";
            this.radioQauantitative.CheckedChanged += new System.EventHandler(this.typeCheckedChanged);
            // 
            // radioVerbal
            // 
            this.radioVerbal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioVerbal.Location = new System.Drawing.Point(248, 26);
            this.radioVerbal.Name = "radioVerbal";
            this.radioVerbal.Size = new System.Drawing.Size(64, 24);
            this.radioVerbal.TabIndex = 4;
            this.radioVerbal.Text = "Verbal";
            this.radioVerbal.CheckedChanged += new System.EventHandler(this.typeCheckedChanged);
            // 
            // radioAlgebra
            // 
            this.radioAlgebra.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioAlgebra.Location = new System.Drawing.Point(116, 56);
            this.radioAlgebra.Name = "radioAlgebra";
            this.radioAlgebra.Size = new System.Drawing.Size(101, 24);
            this.radioAlgebra.TabIndex = 2;
            this.radioAlgebra.Text = "Algebra";
            this.radioAlgebra.CheckedChanged += new System.EventHandler(this.typeCheckedChanged);
            // 
            // radioArithmetic
            // 
            this.radioArithmetic.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioArithmetic.Location = new System.Drawing.Point(116, 86);
            this.radioArithmetic.Name = "radioArithmetic";
            this.radioArithmetic.Size = new System.Drawing.Size(96, 24);
            this.radioArithmetic.TabIndex = 3;
            this.radioArithmetic.Text = "Arithmetic";
            this.radioArithmetic.CheckedChanged += new System.EventHandler(this.typeCheckedChanged);
            // 
            // radioReadingComprehension
            // 
            this.radioReadingComprehension.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioReadingComprehension.Location = new System.Drawing.Point(248, 56);
            this.radioReadingComprehension.Name = "radioReadingComprehension";
            this.radioReadingComprehension.Size = new System.Drawing.Size(136, 24);
            this.radioReadingComprehension.TabIndex = 5;
            this.radioReadingComprehension.Text = "Reading Comprehension";
            this.radioReadingComprehension.CheckedChanged += new System.EventHandler(this.typeCheckedChanged);
            // 
            // radioSentenceCorrection
            // 
            this.radioSentenceCorrection.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioSentenceCorrection.Location = new System.Drawing.Point(248, 116);
            this.radioSentenceCorrection.Name = "radioSentenceCorrection";
            this.radioSentenceCorrection.Size = new System.Drawing.Size(128, 24);
            this.radioSentenceCorrection.TabIndex = 7;
            this.radioSentenceCorrection.Text = "Sentence Correction";
            this.radioSentenceCorrection.CheckedChanged += new System.EventHandler(this.typeCheckedChanged);
            // 
            // radioCriticalReasoning
            // 
            this.radioCriticalReasoning.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioCriticalReasoning.Location = new System.Drawing.Point(248, 86);
            this.radioCriticalReasoning.Name = "radioCriticalReasoning";
            this.radioCriticalReasoning.Size = new System.Drawing.Size(112, 24);
            this.radioCriticalReasoning.TabIndex = 6;
            this.radioCriticalReasoning.Text = "Critical Reasoning";
            this.radioCriticalReasoning.CheckedChanged += new System.EventHandler(this.typeCheckedChanged);
            // 
            // radioCombinations
            // 
            this.radioCombinations.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioCombinations.Location = new System.Drawing.Point(116, 116);
            this.radioCombinations.Name = "radioCombinations";
            this.radioCombinations.Size = new System.Drawing.Size(101, 24);
            this.radioCombinations.TabIndex = 8;
            this.radioCombinations.Text = "Combinations";
            // 
            // radioGeometry
            // 
            this.radioGeometry.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioGeometry.Location = new System.Drawing.Point(116, 146);
            this.radioGeometry.Name = "radioGeometry";
            this.radioGeometry.Size = new System.Drawing.Size(101, 24);
            this.radioGeometry.TabIndex = 9;
            this.radioGeometry.Text = "Geometry";
            // 
            // radioProbability
            // 
            this.radioProbability.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioProbability.Location = new System.Drawing.Point(116, 176);
            this.radioProbability.Name = "radioProbability";
            this.radioProbability.Size = new System.Drawing.Size(101, 24);
            this.radioProbability.TabIndex = 10;
            this.radioProbability.Text = "Probability";
            // 
            // radioStatistics
            // 
            this.radioStatistics.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioStatistics.Location = new System.Drawing.Point(116, 206);
            this.radioStatistics.Name = "radioStatistics";
            this.radioStatistics.Size = new System.Drawing.Size(101, 24);
            this.radioStatistics.TabIndex = 11;
            this.radioStatistics.Text = "Statistics";
            // 
            // radioWordProblems
            // 
            this.radioWordProblems.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioWordProblems.Location = new System.Drawing.Point(116, 236);
            this.radioWordProblems.Name = "radioWordProblems";
            this.radioWordProblems.Size = new System.Drawing.Size(101, 24);
            this.radioWordProblems.TabIndex = 12;
            this.radioWordProblems.Text = "Word Problems";
            // 
            // TypeSelectionForm
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(417, 320);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TypeSelectionForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Question Type";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public QuestionType BaseQuestionType
        {
            get { return baseQuestionType; }
            set
            {
                baseQuestionType = value;
                ReenableButtons();
                FixQuestionType();
            }
        }

        public QuestionType QuestionType
        {
            get { return questionType; }
            set
            {
                questionType = value;
                SetActiveRadioButton();
                FixQuestionType();
            }
        }

        private void SetActiveRadioButton()
        {
            ((RadioButton) questionTypeToRadioButton[questionType]).Checked = true;
        }

        private void ReenableButtons()
        {
            foreach (DictionaryEntry entry in radioButtonToQuestionType)
            {
                RadioButton rb = (RadioButton) entry.Key;
                QuestionType qt = (QuestionType) entry.Value;

                rb.Enabled = qt.IsSubsetOf(baseQuestionType);
            }
        }

        private void FixQuestionType()
        {
            if (!questionType.IsSubsetOf(baseQuestionType)) QuestionType = baseQuestionType;
        }

        private void typeCheckedChanged(object sender, EventArgs e)
        {
            questionType = (QuestionType) radioButtonToQuestionType[sender];
        }
    }
}
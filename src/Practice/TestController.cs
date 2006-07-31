using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;
using GmatClubTest.QuestionRenderer;

namespace GmatClubTest.Practice
{
	public class EndTestException: Exception
	{
		public EndTestException(): base("") {}
		public EndTestException(string msg): base(msg) {}
	}

	public class TestController
	{
		private TestSet.TestsRow testRow;

		private QuestionAnswerSet questionAnswerSet = new QuestionAnswerSet();
		private QuestionAnswerSet.AnswersRow[] answersRow;
		private QuestionAnswerSet.QuestionsRow question;
		private QuestionSetSet.QuestionSetsRow questionSet;
		private PracticeForm practiceForm;
		private TestForm testForm;
		private int answerIndex = -1;
		private INavigator navigator;
		private ITestForm iTestForm;
		private bool isPractice;
		private RadioButton answerRadioButton;
		private RichTextBox descriptionRichTextBox;
		private ListView questionStatuslistView;
		private MainForm mainForm;
		private DescriptionForm df = new DescriptionForm();
		private Button reviewButton;
		private System.Windows.Forms.ListView setStatusListView;
		private bool isClockVisible = true;
		private PictureBox questionPictureBox;
		private PictureBox answerPictureBox;
		private System.Windows.Forms.Panel questionPanel;
		private Control[] answerControls = null;
		private Control[] answerPictureControls = null;
		private GeneralQuestionPanel generalQuestionPanel = new GeneralQuestionPanel();
		//internal static string _undefinedName1 = "Wb2VX7zrlOIO4ps2OLLefhE3l/s";
        internal static string _undefinedName1 = "jevNY0Ut8jnxR3YkfE5axGCs8Uc";
		internal static string _undefinedName2 = "3RxPCq8ALxSb80WrqYnKWEI5kKI";
		// internal static string _undefinedName3 = "Srcs8hLw4qh72Ho";
        internal static string _undefinedName3 = "vUJ5Cf3IIYGiwP0";
		private ReadingComprehensionPanel readingComprehensionPanel = new ReadingComprehensionPanel();
		private System.Windows.Forms.StatusBar statusBar;
		private PictureBox passagePictureBox;
		private System.Timers.Timer clockTimer;
		private ReviewForm review = null;
		private Renderer renderer = new Renderer(); 
		private ImageSet imageSet = new ImageSet();
		private Manager manager = null;
		
		private enum ReviewType
		{
			Return = 0,
			Exit = 1
		};

	
		public TestController(TestSet.TestsRow testRow, INavigator navigator, MainForm mainForm, Manager manager)
		{
			mainForm.RegisterTestController(this);

			mainForm.Hide();

			this.mainForm = mainForm;
			this.isPractice = testRow.IsPractice;
			this.testRow = testRow;
			this.navigator = navigator;
			this.manager = manager;

		}

		private void ShowDescriptionDialog(bool isTestDescription)
		{
			if (isTestDescription)
			{
				CreateTestDescription();
			}else
			{
				CreateSetDescription();
			}
			df.ShowDialog();
			if(df.DialogResult != DialogResult.OK)
				throw new EndTestException();
		}

		public void Run()
		{
			descriptionRichTextBox = df.descriptionRichTextBox;
			iTestForm = df;

			ShowDescriptionDialog(true);

			if (!navigator.HasNextSet)
				throw new EndTestException("Test has no sets of questions.");

			GetNextSet();
			ShowDescriptionDialog(false);
			if (!navigator.HasNextQuestion)
			{
				throw new EndTestException("Set of questions has no questions.");
			}

			if (isPractice)
			{
				practiceForm = new PracticeForm(this);
				iTestForm = practiceForm;
				practiceForm.Show();
			
			}
			else
			{
				testForm = new TestForm(this);
				iTestForm = testForm;
				testForm.Show();
			}
		}

		public void ShowHelp()
		{
			MainForm.ShowHelpForm((HelpForm.HelpSubtype) question.SubtypeId);
		}

		public void TransitionOnSelectQuestion(int selectedSetNamberOfComboBox, int questionNamberOfList)
		{
			if (!navigator.HasRandomSetAccess)
			{
				MessageBox.Show("Random access to quest is impossible on this test.", MainForm.APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (!navigator.HasRandomQuestionAccess)
			{
				MessageBox.Show("Random access to quest is impossible on this test.", MainForm.APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			navigator.SetActiveSet(navigator.Sets.QuestionSets[selectedSetNamberOfComboBox].Id);
			navigator.SetActiveQuestion(navigator.QuestionsAnswers[selectedSetNamberOfComboBox].Questions[questionNamberOfList].Id);
			review.Close();
			ShowQuestion();
		}

		public void OnRewievFormClosing()
		{
			review.setStatusListView.Items.Clear();
		}

		private void CheckAnswerBoxOnTransitionOfQuestion()
		{
			int i;
			Question.Status status;
			status = navigator.GetQuestionStatus(question.Id);
			if (status.status == Question.Status.StatusType.NOT_SEEN || status.status == Question.Status.StatusType.SEEN)
			{
				return;
			}

            for (i = 0; i<= answersRow.Length; ++i)
            {
            	if (answersRow[i].Id == status.answeredId)
            	{
            		answerControls[i].Select();
					return;
            	}
            }
		}
	
		private void ShowQuestion()
		{
			answerIndex = -1;
			GetActivQuestion();
			PrepareForms();
			iTestForm.ReEnableButtons(navigator);
		}

		public void SelectedSetChanged()
		{
			InitReviewForm(false);
		}


		public void SectionExit()
		{
			DialogResult result = MessageBox.Show("You will not be able to return to this section. Do you really want to exit from the current section?", MainForm.APP_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (result == DialogResult.Yes)
			{
				if (navigator.HasNextSet)
				{
					GetNextSet();
					ShowDescriptionDialog(false);
					if (!navigator.HasNextQuestion)
					{
						MessageBox.Show("Set has no questions.", MainForm.APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						NextQuestion();
					}
				}else
				{
					try
					{
						navigator.CommitResult();
						ShowResultDetailsOnEndTest();
					} 
					catch (Exception e)
					{
						MessageBox.Show("Cannot commit the results of the test to the database: " + e.Message, MainForm.APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					throw new EndTestException();
				}
			}
		}


		private void InitReviewForm(bool isFirstInit)
		{
			int questionCount;
			QuestionAnswerSet qas;
			Question.Status status;

			if(review == null)
				review = new ReviewForm(this);

			questionStatuslistView = review.questionStatusListView;
			setStatusListView = review.setStatusListView;
			if (setStatusListView.Items.Count == 0)
			{
				ListViewItem setItems;
				for (int i = 0; i < navigator.QuestionsAnswers.Length; i++)
				{
					setItems = setStatusListView.Items.Add((i+1).ToString());
					setItems.SubItems.Add(navigator.Sets.QuestionSets[i].Name);
					qas = navigator.QuestionsAnswers[i];
					questionCount = navigator.QuestionsAnswers[i].Questions.Count;
					double setScore = 0;
					for (int j = 0; j < questionCount; ++j)
					{
						status = navigator.GetQuestionStatus(qas.Questions[j].Id);
						setScore += status.score;
					}
					setItems.SubItems.Add(setScore.ToString());
				}
			}

			if (isFirstInit)
			{
				setStatusListView.Items[0].Selected = true;
				qas = navigator.QuestionsAnswers[0];
				questionCount = navigator.QuestionsAnswers[0].Questions.Count;

			}else
			{
				qas = navigator.QuestionsAnswers[setStatusListView.SelectedItems[0].Index];
				questionCount = navigator.QuestionsAnswers[setStatusListView.SelectedItems[0].Index].Questions.Count;
			}
			
			questionStatuslistView.BeginUpdate();
			questionStatuslistView.Items.Clear();
			for (int i = 0; i < questionCount; ++i)
			{
				ListViewItem it = questionStatuslistView.Items.Add((i+1).ToString());
				status = navigator.GetQuestionStatus(qas.Questions[i].Id);
				it.ImageIndex = (int)status.status - 1;
				it.SubItems.Add(renderer.RenderToString(qas.Questions[i].Text));
				switch ((int)status.status)
				{
					case 0:
						it.SubItems.Add("Not seen");
						break;
					case 1:
						it.SubItems.Add("Not answered");
						break;
					case 2:
						it.SubItems.Add("Correct");
						break;
					case 3:
						it.SubItems.Add("Incorrect");
						break;
				}
			}
			questionStatuslistView.EndUpdate();
		}

		private DialogResult ShowReviewForm(ReviewType reviewType)
		{
			InitReviewForm(true);
			reviewButton = review.button;
			if(reviewType == ReviewType.Return)
			{
				reviewButton.Text = "&Return";
				reviewButton.ImageIndex = 0;
			}
			if(reviewType == ReviewType.Exit)
			{
				reviewButton.Text = "&Exit test";
				reviewButton.ImageIndex = 1;
			}
			review.ShowDialog();
			return review.DialogResult;
		}

		public void ReviewButton_Click()
		{
			ShowReviewForm(ReviewType.Return);
		}

		private void CreateTestDescription()
		{
			string path = Application.StartupPath + "\\TestDescription.rtf";
			string rtfString = (new StreamReader(path)).ReadToEnd();
			
			string typeCaption = (testRow.IsPractice ? "Practice" : "Computer-Adaptive Test") + 
				((testRow.IsQuestionTypeIdNull())?(""):(": " + Question.Type.GetName(typeof(Question.Type), testRow.QuestionTypeId).ToString()));
			
			string caption = testRow.Name;
			
			iTestForm.ChangeCaption(caption);
			rtfString = rtfString.Replace("%Type%", typeCaption);
			rtfString = rtfString.Replace("%Description%", testRow.Description.ToString());
			rtfString = rtfString.Replace("%Caption%", caption);
			if (navigator.TotalTime != TimeSpan.MaxValue)
			{
				rtfString = rtfString.Replace("%Time%", String.Format("{0} min", navigator.TotalTime.TotalMinutes));
			}else
			{
				rtfString = rtfString.Replace("%Time%", "unlimited");
			}
			rtfString = rtfString.Replace("%NumberOfQuestions%", navigator.TotalNumberOfQuestions.ToString());
			descriptionRichTextBox.Rtf = rtfString;
		}

		private void CreateSetDescription()
		{
			string path = Application.StartupPath + "\\SectionDescription.rtf";
			string rtfString = (new StreamReader(path)).ReadToEnd();

			string typeCaption = "Section " + ((questionSet.IsQuestionTypeIdNull())?(""):(": " + Question.Type.GetName(typeof(Question.Type), questionSet.QuestionTypeId).ToString()));
			
			string caption =  questionSet.Name;
			
			iTestForm.ChangeCaption(caption);
			rtfString = rtfString.Replace("%Type%", typeCaption);
			rtfString = rtfString.Replace("%Description%", questionSet.Description.ToString());
			rtfString = rtfString.Replace("%Caption%", caption);
			if (navigator.RemainedTime != TimeSpan.MaxValue)
			{
				rtfString = rtfString.Replace("%Time%", String.Format("{0} min", questionSet.TimeLimit));
			}else
			{
				rtfString = rtfString.Replace("%Time%", "unlimited");
			}
			if (isPractice)
			{
				rtfString = rtfString.Replace("%NumberOfQuestions%", questionSet.NumberOfQuestionsToPick.ToString());
			}else
			{
				rtfString = rtfString.Replace("%NumberOfQuestions%", (questionSet.NumberOfQuestionsInZone1 + questionSet.NumberOfQuestionsInZone2 + questionSet.NumberOfQuestionsInZone3).ToString());
			}
			descriptionRichTextBox.Rtf = rtfString;
		}

		private void DeleteAnswerRadioButton()
		{
			int i;
			for (i=0; i < answerControls.Length; i++)
			{
				answerControls[i].Dispose();
				answerPictureControls[i].Dispose();
			}
		}


		private void PreparePracticeForms()
		{
			if (question.SubtypeId == (int)Question.Subtype.ReadingComprehensionQuestionToPassage)
			{
				practiceForm.panel.Controls.Remove(generalQuestionPanel);
				practiceForm.panel.Controls.Add(readingComprehensionPanel);
				passagePictureBox = readingComprehensionPanel.passagePictureBox;
				questionPictureBox = readingComprehensionPanel.questionPictureBox;
				questionPanel = readingComprehensionPanel.questionPanel;
				clockTimer = practiceForm.clockTimer;
				statusBar = practiceForm.statusBar;
				imageSet = renderer.Render(question);
				questionPictureBox.Image = imageSet.Question;
				passagePictureBox.Image = renderer.RenderPasssageToQuestion(navigator.GetPasssageToQuestion(question.Id));
			
				}
			else
			{
				practiceForm.panel.Controls.Remove(readingComprehensionPanel);
				practiceForm.panel.Controls.Add(generalQuestionPanel);
				questionPictureBox = generalQuestionPanel.questionPictureBox;
				questionPanel = generalQuestionPanel.questionPanel;
				clockTimer = practiceForm.clockTimer;
				statusBar = practiceForm.statusBar;
				imageSet = renderer.Render(question);
				questionPictureBox.Image = imageSet.Question;

			}
			
		}
		public bool IsQuestionAnswered()
		{

			if(navigator.GetQuestionStatus(question.Id).status == Question.Status.StatusType.ANSWER_IS_CORRECT || navigator.GetQuestionStatus(question.Id).status == Question.Status.StatusType.ANSWER_IS_INCORRECT)
			{
				return true;
			}
			else
				return false;
		}
		private void PrepareTestForm()
		{
			if (question.SubtypeId == (int)Question.Subtype.ReadingComprehensionQuestionToPassage)
			{
				testForm.panel.Controls.Remove(generalQuestionPanel);
				testForm.panel.Controls.Add(readingComprehensionPanel);
				statusBar = testForm.statusBar;
				passagePictureBox = readingComprehensionPanel.passagePictureBox;
				questionPictureBox = readingComprehensionPanel.questionPictureBox;
				questionPanel = readingComprehensionPanel.questionPanel;
				clockTimer = testForm.clockTimer;
				imageSet = renderer.Render(question);
				questionPictureBox.Image = imageSet.Question;
				passagePictureBox.Image = renderer.RenderPasssageToQuestion(navigator.GetPasssageToQuestion(question.Id));
			}
			else
			{
				testForm.panel.Controls.Remove(readingComprehensionPanel);
				testForm.panel.Controls.Add(generalQuestionPanel);
				statusBar = testForm.statusBar;
				questionPictureBox = generalQuestionPanel.questionPictureBox;
				questionPanel = generalQuestionPanel.questionPanel;
				clockTimer = testForm.clockTimer;
				imageSet = renderer.Render(question);
				questionPictureBox.Image = imageSet.Question;
			}
			
		}
		private void PrepareForms()
		{
            if (question.SubtypeId == (int)Question.Subtype.ReadingComprehensionPassage)
            {
                throw new EndTestException("Set have unknown type question. Check your databese");
            }
			if (isPractice)
			{
				PreparePracticeForms();
			}
			else
			{
				PrepareTestForm();
			}
			if (answerControls != null)
			{
				DeleteAnswerRadioButton();
			}
			CreateAnswerRadioButtons();
			iTestForm.ReEnableButtons(navigator);
			CheckAnswerBoxOnTransitionOfQuestion();
		}
		public void NextQuestion()
		{
			if (navigator.HasNextQuestion)
			{
				GetNextQuestion();
                answerIndex = -1;
				PrepareForms();
			}else
			{
				if(navigator.HasNextSet)
				{
					GetNextSet();
					ShowDescriptionDialog(false);
					if (!navigator.HasNextQuestion)
					{
						MessageBox.Show("Set has no questions.", MainForm.APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						NextQuestion();
					}
				}else
				{
					if (!isPractice)
					{
						try
						{
							navigator.CommitResult();
							ShowResultDetailsOnEndTest();
						} 
						catch (Exception e)
						{
							MessageBox.Show("Cannot commit the results of the test to the database: " + e.Message, MainForm.APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						throw new EndTestException();
					}
					else
					{
						if (ShowReviewForm(ReviewType.Exit) == DialogResult.OK)
							 throw new EndTestException();
					}
				}
			}
		}

		private void ShowResultDetailsOnEndTest() 
		{
			ResultDetailsForm resultDetailsForm = new ResultDetailsForm(navigator.ResultResultDetailSet.Results[0].Id , manager);
			resultDetailsForm.ShowDialog();
		}

		public void PrevQuestion()
		{
			if (navigator.HasPreviousQuestion)
			{
				answerIndex = -1;
				GetPrevQuestion();
				PrepareForms();
			}else
			{
				if (navigator.HasPreviousSet)
				{
					GetPrevSet();
					CreateSetDescription();
					ShowDescriptionDialog(false);
					PrevQuestion();
				}
			}
		}

		private void CreateAnswerRadioButtons()
		{
			int i;
			int x = 5;
			Control[] controls;
			answerControls = new Control[imageSet.Answers.Length];
			answerPictureControls = new Control[imageSet.Answers.Length];
			for (i = 0; i < imageSet.Answers.Length; i++)
			{
				if (i != 0)
				{
					controls = InitAnswerRadioButton(x,  answerPictureControls[i-1].Location.Y + answerPictureControls[i-1].Height + 5, i, imageSet.Answers[i]);
				}
				else
				{
					controls = InitAnswerRadioButton(x, questionPictureBox.Image.Height + 10, i, imageSet.Answers[i]);
				}
				answerControls[i] = controls[0];
				answerPictureControls[i] = controls[1];
			}
		}

		public void answerRadioButton_Click(object sender, EventArgs e)
		{
			answerIndex = (int)((RadioButton )(sender)).Tag;
			navigator.SetUserAnswer(answersRow[answerIndex].Id);
			iTestForm.ReEnableButtons(navigator);
		}
	
		public void AnswerCheck_Click()
		{
			if (answerIndex == -1)
			{
				MessageBox.Show("Your answer is incorrect.", MainForm.APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Warning);		
				return;
			}
			if (answersRow[answerIndex].IsCorrect)
			{
				MessageBox.Show("Your answer is correct.", MainForm.APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Information);	
				return;
			}else
			{
				MessageBox.Show("Your answer is incorrect.", MainForm.APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Warning);		
				return;
			}
		}

	
		private void GetNextSet()
		{
			questionSet = navigator.GetNextSet();
		}

		private void GetPrevSet()
		{
			questionSet = navigator.GetPreviousSet();
		}

		private void GetActivQuestion()
		{
			navigator.GetActiveQuestion(questionAnswerSet);
			question = questionAnswerSet.Questions[0];
			answersRow = question.GetAnswersRows();
		}
		private void GetPrevQuestion()
		{
			navigator.GetPreviousQuestion(questionAnswerSet);
			question = questionAnswerSet.Questions[0];
			answersRow = question.GetAnswersRows();
		}

		private void GetNextQuestion()
		{
			navigator.GetNextQuestion(questionAnswerSet);
			question = questionAnswerSet.Questions[0];
			answersRow = question.GetAnswersRows();
		}

		public void FormLoading()
		{
			if (isPractice)
				iTestForm.ChangeCaption("Practice - " + testRow.Name);
			else
				iTestForm.ChangeCaption("Verbal - " + testRow.Name);

			NextQuestion();
		}

		public Control[] InitAnswerRadioButton(int locationX, int locationY, int idAnswer, Image answerImage)
		{
			answerPictureBox = new PictureBox();
			answerPictureBox.Name = "answerPictureBox";
			answerPictureBox.Size = new System.Drawing.Size(15, 15);
			answerPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			answerPictureBox.Image = answerImage;
			answerPictureBox.Location = new Point(locationX + 15, locationY);
			questionPanel.Controls.Add(answerPictureBox);

			answerRadioButton = new RadioButton();
			answerRadioButton.Name = "answerRadioButton";
			answerRadioButton.Tag = idAnswer;
			answerRadioButton.Cursor = Cursors.Hand;
			answerRadioButton.Size = new System.Drawing.Size(15, 15);
			answerRadioButton.FlatStyle = FlatStyle.Popup;
			//answerRadioButton.Location = new Point(locationX, locationY +  ((answerPictureBox.Image.Height > 15)?(answerPictureBox.Image.Height/2 - 5):(2)));
			int dt;
			if (answerPictureBox.Image.Height > answerRadioButton.Height)
				dt = (answerPictureBox.Image.Height - answerRadioButton.Height) / 2;
			else
				dt = 0;
			answerRadioButton.Location = new Point(locationX, locationY + dt + 1);

			questionPanel.Controls.Add(answerRadioButton);

			answerRadioButton.Click += new EventHandler(answerRadioButton_Click);

			return new Control[] {answerRadioButton, answerPictureBox};
		}

		public void OnTimerElapsed()
		{
			ChangeStatusBar();
			if (navigator.RemainedTime.TotalMilliseconds <= 0 && !clockTimer.Enabled) TimeIsUp();
		}

		public void ChangeStatusBar()
		{
			if (!isClockVisible)
				return;
			if (navigator.RemainedTime != TimeSpan.MaxValue)
			{
				statusBar.Text = String.Format("{0:00}:{1:00}:{2:00}", navigator.RemainedTime.Hours, navigator.RemainedTime.Minutes, navigator.RemainedTime.Seconds);
            }//else
            //statusBar.Text = "unlimited";
		}

		public void TimeButton_Click()
		{
			if(!isClockVisible)
			{
				ChangeStatusBar();
				isClockVisible = true;
			}else
			{	
				statusBar.Text = "";
				isClockVisible = false;
			}
		}

		internal void EndTest()
		{
			try
			{
				if (isPractice)
				{
					try
					{
						navigator.CommitResult();	
					} 
					catch (Exception e)
					{
						MessageBox.Show("Cannot commit the results of the test to the database: " + e.Message, MainForm.APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				df.Dispose();
				if (practiceForm != null)
				{
					practiceForm.Dispose();
				}
				if (testForm != null)
				{
					testForm.Dispose();
				}

				mainForm.Show();	
			} finally
			{
				mainForm.UnregisterTestController(this);
			}
			
		}

		public void ConfirmExit()
		{
			DialogResult result = MessageBox.Show("You will not be able to continue the test. Do you really want to quit?", MainForm.APP_CAPTION, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);	
			if (result == DialogResult.Yes) throw new EndTestException();
		}

		public void TimeIsUp()
		{
			clockTimer.Enabled = false;
			clockTimer.Stop();

			MessageBox.Show("Your time is up.", MainForm.APP_CAPTION, MessageBoxButtons.OK, MessageBoxIcon.Warning);
			if (navigator.HasNextSet)
			{
				GetNextSet();
				ShowDescriptionDialog(false);
				clockTimer.Start();
				NextQuestion();
			}else
			{
				if (ShowReviewForm(ReviewType.Exit) == DialogResult.OK)
					throw new EndTestException(); 
			}
			
		}
	}
}

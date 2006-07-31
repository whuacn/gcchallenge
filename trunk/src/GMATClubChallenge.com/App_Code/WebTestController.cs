using System;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;
using GmatClubTest.QuestionRenderer;
using GMATClubTest.Web;

namespace GmatClubTest.Web
{
 
	public class WebTestController
	{
	
		private Manager manager = null;
		private INavigator navigator;
		private bool isPractice = new bool();
		public TestSet.TestsRow testRow;
        private QuestionSetSet.QuestionSetsRow questionSet;
		private QuestionAnswerSet questionAnswerSet = new QuestionAnswerSet();
		private QuestionAnswerSet.QuestionsRow question;
		private QuestionAnswerSet.AnswersRow[] answersRow;
		//private int answerIndex = -1;
		private string descriptionTestString;
/*
		private string descriptionSetString;
*/
/*
		private bool isTestDrscriptionShowed;
*/
		private RadioButtonList answerRadioButtonList;
		private Label statusLabel;
		private Label timeLabel;
		private HyperLink loginStatusHyperLink;
		private ReviewWebForm reviewWebForm;
		private int activSetNumber = 0;
		private TestWebForm testWebForm;
		private string nextClickScript;
		private string answerConfirmClickScript;
		Guid answerGUID;
		Guid questionGUID;
		Guid passageGUID;
		Guid[] answerGUIDMas = new Guid[20];
		private Renderer renderer = new Renderer();
		private ImageSet imageSet;
        string mapPath = HttpContext.Current.Request.MapPath("GMATClubChallenge.com");
	    private PracticeGeneralWebForm practicelWebForm;
        bool setDescriptionShoweded = false;
        bool testDescriptionShoweded = false;
        int selectedAnswer;
      
		//private PracticeGeneralWebForm practicelWebForm = new PracticeGeneralWebForm();

		public WebTestController(TestSet.TestsRow testRow ,Manager manager)
		{
            mapPath = mapPath.Replace("\\gmatclubchallenge.com\\gmatclubchallenge.com", "\\gmatclubchallenge.com");
            mapPath = mapPath.Replace("\\GMATClubChallenge.com\\GMATClubChallenge.com", "\\GMATClubChallenge.com");
            mapPath = mapPath.Replace("\\gmatclubchallenge.com\\GMATClubChallenge.com", "\\GMATClubChallenge.com");
			isPractice = testRow.IsPractice;
			this.manager = manager;
			this.testRow = testRow;
			navigator = manager.RunTest(testRow);
			if (navigator.HasNextSet)
			{
				GetNextSet();
				GetNextQuestion();
				//PrepareTestDescription();
			}
		}

		 ~WebTestController()
		{
			DeletePicturesFiles();
		}

		public void DeletePicturesFiles()
		{
			int i;
			try
			{
				File.Delete(mapPath + @"\images\Question&AnswerTempPictures\" + questionGUID.ToString() + ".gif");
			}
			catch
			{
				
			}
			try
			{
				File.Delete(mapPath + @"\images\Question&AnswerTempPictures\" + passageGUID.ToString() + ".gif");
			}
			catch
			{
				
			}
			try
			{
				for(i=0; i<= answerGUIDMas.Length; i++)
				{
					File.Delete(mapPath + @"\images\Question&AnswerTempPictures\" + answerGUIDMas[i].ToString() + ".gif");
				}
			}
			catch
			{
				
			}

		}
        public void PrepareTestDescription(IDescriptionWebForm form)
        {
            descriptionTestString = "";
            if (testDescriptionShoweded)
            {
                setDescriptionShoweded = false;
                PrepareSetDescription(form);
                return;
            }
            testDescriptionShoweded = true;
            string caption = testRow.Name;
            descriptionTestString += "<< " + caption + " >>" + "<p>";
            string typeCaption = (testRow.IsPractice ? "Practice" : "Computer-Adaptive Test") + 
            ((testRow.IsQuestionTypeIdNull())?(""):(": " + Question.Type.GetName(typeof(Question.Type), testRow.QuestionTypeId).ToString()));
            descriptionTestString +=  typeCaption + "<p>";
            if (navigator.TotalTime != TimeSpan.MaxValue)
            {
            descriptionTestString += "Time: " + String.Format("{0} min", navigator.TotalTime.TotalMinutes) + "<p>";
        }
            else
            {
            descriptionTestString += "Time: " + "unlimited" + "<p>"; ;
        }
            descriptionTestString += "Number of questions: " + navigator.TotalNumberOfQuestions.ToString() + "<p>";
            descriptionTestString += testRow.Description.ToString() + "<p>";
            form.Caption("Description: " + testRow.Name);
            form.DescriptionString(descriptionTestString);
          
        }

        public void PrepareSetDescription(IDescriptionWebForm form)
	    {
            descriptionTestString = "";
            if (setDescriptionShoweded)
	        {
                if (isPractice) { form.Response.Redirect("practiceWebForm.aspx"); } else { form.Response.Redirect("testWebForm.aspx"); }
	            return;
	        }
            setDescriptionShoweded = true;
            string caption = testRow.Name;
            descriptionTestString += "<< " + caption + " >>" + "<p>";
            string typeCaption = (testRow.IsPractice ? "Practice" : "Computer-Adaptive Test") +
                ((testRow.IsQuestionTypeIdNull()) ? ("") : (": " + Question.Type.GetName(typeof(Question.Type), testRow.QuestionTypeId).ToString()));
            descriptionTestString += typeCaption + "<p>";
            if (navigator.TotalTime != TimeSpan.MaxValue)
            {
                descriptionTestString += "Time: " + String.Format("{0} min", questionSet.TimeLimit) + "<p>";
            }
            else
            {
                descriptionTestString += "Time: " + "unlimited" + "<p>"; ;
            }
            if (isPractice)
            {
                 descriptionTestString += "Number of questions: " + questionSet.NumberOfQuestionsToPick.ToString()+  "<p>";
            }
            else
            {
                 descriptionTestString += "Number of questions: " + (questionSet.NumberOfQuestionsInZone1 + questionSet.NumberOfQuestionsInZone2 + questionSet.NumberOfQuestionsInZone3).ToString()+ "<p>";
            }
           //descriptionTestString += "Number of questions: " + navigator.TotalNumberOfQuestions.ToString() + "<p>";
            descriptionTestString += questionSet.Description.ToString() + "<p>";
	        
            form.Caption("Description: " + testRow.Name);
            form.DescriptionString(descriptionTestString);
	    }
    
       
		public void PracticeWebForm_Load(PracticeGeneralWebForm practicelWebForm)
		{
			
            this.practicelWebForm = practicelWebForm;
			practicelWebForm.clockHiddenParam += "<INPUT id=\"timehh\" type=\"hidden\" value=\"" +navigator.RemainedTime.Hours.ToString()+ "\" name=\"timehh\">";
			practicelWebForm.clockHiddenParam += "<INPUT id=\"timemm\" type=\"hidden\" value=\"" +navigator.RemainedTime.Minutes.ToString()+ "\" name=\"timemm\">";
			practicelWebForm.clockHiddenParam += "<INPUT id=\"timess\" type=\"hidden\" value=\"" +navigator.RemainedTime.Seconds.ToString()+ "\" name=\"timess\">";
			
			if(practicelWebForm.IsPostBack)
			{
				return;
			}
			PracticeFormInit(practicelWebForm);
		}

		private void PracticeFormInit(PracticeGeneralWebForm practicelWebForm)
		{
			loginStatusHyperLink.Text = "Log out...";
            loginStatusHyperLink.NavigateUrl = "loginWebForm.aspx";
			questionGUID = Guid.NewGuid();

            statusLabel.Visible = false;
            practicelWebForm.PassageImage.Visible = false;
           // practicelWebForm.PassageImage.Visible = true;
		   if (question.SubtypeId == (int)Question.Subtype.ReadingComprehensionPassage)
			{
				// To Do Exeption
			}
			if (question.SubtypeId == (int)Question.Subtype.ReadingComprehensionQuestionToPassage)
			{
				passageGUID = Guid.NewGuid();
				imageSet =  renderer.Render(question);
			    //practicelWebForm.PassageImage.Visible = true;
                practicelWebForm.PassageImage.Visible = true;
                imageSet.Question.Save(mapPath + @"\images\Question&AnswerTempPictures\" + questionGUID.ToString() + ".gif", ImageFormat.Gif);
                practicelWebForm.QuestionImage.ImageUrl = @"images/Question&AnswerTempPictures/" + questionGUID.ToString() + ".gif";
				(renderer.RenderPasssageToQuestion(navigator.GetPasssageToQuestion(question.Id))).Save(mapPath + @"\images\Question&AnswerTempPictures\" + passageGUID.ToString()  + ".gif", ImageFormat.Gif);
                practicelWebForm.PassageImage.ImageUrl = @"images/Question&AnswerTempPictures/" + passageGUID.ToString() + ".gif";
				PrepareAndRenderAnswers();
			}
			else
			{
				imageSet =  renderer.Render(question);
				//imageSet.Question.Save(HttpContext.Current.Request.MapPath("www.GMATClubChallenge.com") + mapPath + @"\images\Question&AnswerTempPictures\" + questionGUID.ToString() + ".gif", ImageFormat.Gif);
                string path = (mapPath + "\\images\\Question&AnswerTempPictures\\" + questionGUID.ToString()+ ".gif");
                imageSet.Question.Save(path, ImageFormat.Gif);
                practicelWebForm.QuestionImage.ImageUrl = @"images/Question&AnswerTempPictures/" + questionGUID.ToString() + ".gif";
				PrepareAndRenderAnswers();
			}

            if (!navigator.HasPreviousQuestion)
            {
                practicelWebForm.PrewImageButton.Enabled = false;
            }
            else
            {
                practicelWebForm.PrewImageButton.Enabled = true;
            }
			
		}
		private void PrepareAndRenderAnswers()
		{
			int i;
			answerRadioButtonList.Items.Clear();
			for (i = 0; i < imageSet.Answers.Length; i++)
			{
				answerGUID = Guid.NewGuid();
				answerGUIDMas[i] = answerGUID;
				imageSet.Answers[i].Save(mapPath + @"\images\Question&AnswerTempPictures\"+  answerGUID.ToString() + ".gif", ImageFormat.Gif);
				InitAnswerRadioButton(i);
			}
			CheckAnswerBoxOnTransitionOfQuestion();
		}

		public void InitAnswerRadioButton(int answerNam)
		{
			answerRadioButtonList.Items.Add(answerNam.ToString());
			answerRadioButtonList.Items[answerNam].Value = answerNam.ToString();
			answerRadioButtonList.Items[answerNam].Text = "<img src=\"images/Question&AnswerTempPictures/" + answerGUID.ToString() +".gif\" alt=\"\" border=\"0\" />";
		}

        public void PracticeGeneralWebForm_Init(PracticeGeneralWebForm practicelWebForm)
		{
            answerRadioButtonList = practicelWebForm.AnswerRadioButtonList;
            statusLabel = practicelWebForm.StatusLabel;
            timeLabel = practicelWebForm.TimeLabel;
            loginStatusHyperLink = practicelWebForm.LoginStatusHyperLink;
            practicelWebForm.StatusLabel.Visible = false; 
			if (practicelWebForm.IsPostBack)
			{
				DeletePicturesFiles();
			}

         
            
			switch (practicelWebForm.status)
			{
				case "NONE":
					break;
				case "answerConfirm":
					break;
				case "sectionExit":
					SectionExit(practicelWebForm);
					break;
				case "exit":
				break;
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
            //navigator.SetActiveQuestion(question.Id);
			answersRow = question.GetAnswersRows();
		}

		private void GetNextQuestion()
		{
			navigator.GetNextQuestion(questionAnswerSet);
			question = questionAnswerSet.Questions[0];
            //navigator.SetActiveQuestion(question.Id);
			answersRow = question.GetAnswersRows();
		}

		

		public void DescriptionCancelImageButton_Click(DescriptionWebForm descriptionWebForm)
		{
			descriptionWebForm.Response.Redirect("mainwebform.aspx");
		}

		public void PracticeWebForm_NextButtonClick(PracticeGeneralWebForm form)
        {   //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
            int id = questionAnswerSet.Answers[selectedAnswer].Id;
            navigator.SetUserAnswer(id);
		    //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
            if (navigator.HasNextQuestion)
			{
				GetNextQuestion();
				PracticeFormInit(form);
			}else
			{
				if (navigator.HasNextSet)
				{
					GetNextSet();
                    GetNextQuestion();
					form.Response.Redirect("descriptionwebform.aspx");
				}else
				{
					navigator.CommitResult();
                    bool b = true;
                    form.Session.Add("IsEndTest", b);
                    form.Response.Redirect("resultsWebForm.aspx");
				}
	
			}
		}

        public void PracticeWebForm_PrewButtonClick(PracticeGeneralWebForm practicelWebForm)
		{
			if (navigator.HasPreviousQuestion)
			{
				GetPrevQuestion();
				PracticeFormInit(practicelWebForm);
			}
			else
			{
				if (navigator.HasPreviousSet)
				{
					GetPrevSet();
				    GetPrevQuestion();
					practicelWebForm.Response.Redirect("descriptionwebform.aspx");
				}
				else
				{
					//form.Response.Redirect("reviewWebForm.aspx");
				}
	
			}
			
		}

		public void PracticeWebForm_answerCheckClick(PracticeGeneralWebForm form)
		{
			statusLabel.Visible = true; 
			if (answerRadioButtonList.SelectedIndex != -1)
			{
				if (answersRow[answerRadioButtonList.SelectedIndex].IsCorrect)
				{
					statusLabel.Text = "Your answer is correct.";
				}else
				{
					statusLabel.Text = "Your answer is incorrect.";
				}
			}else
			{
				statusLabel.Text = "Your answer is incorrect.";
			}
		}
		
		public void ReviewWebForm_Init(ReviewWebForm form)
		{
			reviewWebForm = form;
			form.ErrorLabel.Visible = true;
			QuestionAnswerSet qas;
		    
            if (!((navigator.HasNextSet) || (navigator.HasNextQuestion)))
            {
                form.ImageButton.ImageUrl = @"images/exitTestButton.gif";
            }
            else
            {
                form.ImageButton.ImageUrl = @"images/returnButton.gif";
            }
       
			//form.ImageButton.Click += new ImageClickEventHandler(imageButton_Click);

		    int questionCount;
		    Question.Status status;
			TableRow tr = new TableRow();
			TableCell tc = new TableCell();
			tc.BorderStyle = BorderStyle.Double;
			int rows = 0;
			form.SetsTable.Rows.Add(tr);
			form.SetsTable.Rows[rows].Cells.Add(tc);
			form.SetsTable.Rows[rows].Cells[0].Text = "#";
			tc = new TableCell();
			tc.BorderStyle = BorderStyle.Double;
			form.SetsTable.Rows[rows].Cells.Add(tc);
			form.SetsTable.Rows[rows].Cells[1].Text = "Section name";
			tc = new TableCell();
			tc.BorderStyle = BorderStyle.Double;
			form.SetsTable.Rows[rows].Cells.Add(tc);
			form.SetsTable.Rows[rows].Cells[2].Text = "Score";
			++rows;
			for (int i = 0; i < navigator.QuestionsAnswers.Length; i++)
			{
				int cells = 0;
				tr = new TableRow();
				
				form.SetsTable.Rows.Add(tr);
				form.SetsTable.Rows[rows].Cells.Add(tc);
				tc = new TableCell();
				tc.BorderStyle = BorderStyle.Double;
				form.SetsTable.Rows[rows].Cells.Add(tc);
				form.SetsTable.Rows[rows].Cells[cells].Text = (i+1).ToString();
                
				++cells;
				tc = new TableCell();
				tc.BorderStyle = BorderStyle.Double;
				tc = new TableCell();
				tc.BorderStyle = BorderStyle.Double;
				form.SetsTable.Rows[rows].Cells.Add(tc);
				LinkButton setLinkButton = new LinkButton();
				setLinkButton.Text = navigator.Sets.QuestionSets[i].Name;
				setLinkButton.ID = i.ToString();
				setLinkButton.Click += new EventHandler(setLinkButton_Click);
				form.SetsTable.Rows[rows].Cells[cells].Controls.Add(setLinkButton);
				++cells;
				qas = navigator.QuestionsAnswers[i];
				questionCount = navigator.QuestionsAnswers[i].Questions.Count;
				double setScore = 0;
				for (int j = 0; j < questionCount; ++j)
				{
					status = navigator.GetQuestionStatus(qas.Questions[j].Id);
					setScore += status.score;
				}
				tc = new TableCell();
				tc.BorderStyle = BorderStyle.Double;
				tc = new TableCell();
				tc.BorderStyle = BorderStyle.Double;
				form.SetsTable.Rows[rows].Cells[cells].Text = setScore.ToString(); 
				++rows;
			}

			qas = navigator.QuestionsAnswers[activSetNumber];
			questionCount = navigator.QuestionsAnswers[activSetNumber].Questions.Count;

	
			tr = new TableRow();
			tc = new TableCell();
			
			tc.BorderStyle = BorderStyle.Double;

			rows = 0;
	
			tc = new TableCell();
			tc.BorderStyle = BorderStyle.Double;
			form.QuestionTable.Rows.Add(tr);
			form.QuestionTable.Rows[rows].Cells.Add(tc);
			form.QuestionTable.Rows[rows].Cells[0].Text = "#";
			tc = new TableCell();	
			tc.BorderStyle = BorderStyle.Double;
			form.QuestionTable.Rows[rows].Cells.Add(tc);
			form.QuestionTable.Rows[rows].Cells[1].Text = "Question";
			tc = new TableCell();	
			tc.BorderStyle = BorderStyle.Double;
			form.QuestionTable.Rows[rows].Cells.Add(tc);
			form.QuestionTable.Rows[rows].Cells[2].Text = "Status";
			++rows;


			for (int i = 0; i < questionCount; ++i)
			{

				int cells = 0;
				tr = new TableRow();
				form.QuestionTable.Rows.Add(tr);
			
				status = navigator.GetQuestionStatus(qas.Questions[i].Id);
				tc = new TableCell();
				tc.BorderStyle = BorderStyle.Double;
				form.QuestionTable.Rows[rows].Cells.Add(tc);
				form.QuestionTable.Rows[rows].Cells[cells].Text += (i+1).ToString();
				++cells;

				tc = new TableCell();
				tc.BorderStyle = BorderStyle.Double;
				form.QuestionTable.Rows[rows].Cells.Add(tc);
				LinkButton questoinLinkButton = new LinkButton();
				//form.questionTable.Rows[rows].Cells[cells].Text = "<input type=\"image\" src=/" + "images/status/" + Question.Status.StatusType.GetName(typeof(Question.Status.StatusType), (int)status.status).ToString() + ".bmp"+">";
				questoinLinkButton.Text = "<input type=\"image\" src=" + "images/status/" + Question.Status.StatusType.GetName(typeof(Question.Status.StatusType), (int)status.status).ToString() + ".gif"+">";
				questoinLinkButton.Text += renderer.RenderToString(qas.Questions[i].Text);
				questoinLinkButton.ID = i.ToString();
				questoinLinkButton.Click += new EventHandler(questoinLinkButton_Click);
				questoinLinkButton.ID = "questoinLinkButton" + i.ToString();
				form.QuestionTable.Rows[rows].Cells[cells].Controls.Add(questoinLinkButton);
				++cells;

				tc = new TableCell();
				tc.BorderStyle = BorderStyle.Double;
				form.QuestionTable.Rows[rows].Cells.Add(tc);
				switch ((int)status.status)
				{
					case 0:
						form.QuestionTable.Rows[rows].Cells[cells].Text = "Not seen";
						break;
					case 1:
						form.QuestionTable.Rows[rows].Cells[cells].Text = "Not answered";
						break;
					case 2:
						form.QuestionTable.Rows[rows].Cells[cells].Text = "Correct";
						break;
					case 3:
						form.QuestionTable.Rows[rows].Cells[cells].Text = "Incorrect";
						break;
				}
				++rows;
			}
			

		}

		public void imageButton_Click(object sender, ImageClickEventArgs e)
		{
            if (!((navigator.HasNextSet) || (navigator.HasNextQuestion)))
            {
                navigator.CommitResult();
                reviewWebForm.Response.Redirect("resultsWebForm.aspx");
            }
            else
            {
               reviewWebForm.Response.Redirect("practicewebform.aspx");
            }
          }

		private void TransitionOnSelectSet(int selectedSetNamber)
		{

			if (!navigator.HasRandomSetAccess)
			{
				reviewWebForm.ErrorLabel.Text = "Random access to quest is impossible on this test.";
				return;
			}
			if (!navigator.HasRandomQuestionAccess)
			{
				reviewWebForm.ErrorLabel.Text = "Random access to quest is impossible on this test.";
				return;
			}
			navigator.SetActiveSet(navigator.Sets.QuestionSets[selectedSetNamber].Id);
			activSetNumber = selectedSetNamber;
		}

		private void TransitionOnSelectQuestion(int questionNamber, int selectedSetNamber)
		{
			if (!navigator.HasRandomSetAccess)
			{
				reviewWebForm.ErrorLabel.Text = "Random access to quest is impossible on this test.";
				return;
			}
			if (!navigator.HasRandomQuestionAccess)
			{
				reviewWebForm.ErrorLabel.Text = "Random access to quest is impossible on this test.";
				return;
			}
			navigator.SetActiveQuestion(navigator.QuestionsAnswers[selectedSetNamber].Questions[questionNamber].Id);
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
					answerRadioButtonList.Items[i].Selected = true;
                    selectedAnswer = i;
					return;
				}
			}
		}

		private void questoinLinkButton_Click(object sender, EventArgs e)
		{
			int qn = Convert.ToInt32(((LinkButton)sender).ID.Substring(18));
			TransitionOnSelectQuestion(qn, activSetNumber);
			GetActivQuestion();
			reviewWebForm.Response.Redirect("practicewebform.aspx");
		}

		private void setLinkButton_Click(object sender, EventArgs e)
		{
			int sn;
		    sn = Convert.ToInt32(((LinkButton)sender).ID);
		    TransitionOnSelectSet(sn);
			reviewWebForm.Response.Redirect("reviewWebForm.aspx");
		}

		public void PracticeWebForm_ReviewClick(PracticeGeneralWebForm form)
		{
			form.Response.Redirect("reviewWebForm.aspx");
		}

		public void PracticeWebForm_answerSelectedIndexChanged(PracticeGeneralWebForm form, object sender)
		{
            //if (questionAnswerSet.Answers[((RadioButtonList)sender).SelectedIndex].Id == -1)
            //{
            //    navigator.SetUserAnswer(questionAnswerSet.Answers[selectedAnswer].Id);
                
            //}else
            //{
            //    navigator.SetUserAnswer(questionAnswerSet.Answers[((RadioButtonList)sender).SelectedIndex].Id);
            //}
            selectedAnswer = ((RadioButtonList)sender).SelectedIndex;
		}

		public void TestWebForm_AnswerConfirm(TestWebForm testWebForm)
		{
			navigator.SetUserAnswer(questionAnswerSet.Answers[testWebForm.AnswerRadioButtonList.SelectedIndex].Id);
			if (navigator.HasNextQuestion)
			{
				GetNextQuestion();
			}else
			{
				if (navigator.HasNextSet)
				{
					GetNextSet();
                    GetNextQuestion();
					testWebForm.Response.Redirect("descriptionWebForm.aspx");
				}else
				{
					endTest(testWebForm);
				}
			}
        }

		private void endTest(TestWebForm form)
		{
			navigator.CommitResult();
			form.Session.Add("resultId",navigator.ResultResultDetailSet.Results[0].Id);
            bool b = true;
            form.Session.Add("IsEndTest", b);
			testWebForm.Response.Redirect("resultDetailsWebForm.aspx");
			
		}
	
		private void endPractice(PracticeGeneralWebForm form)
		{
			navigator.CommitResult();
            bool b = true;
            form.Session.Add("IsEndTest", b);
            form.Response.Redirect("resultsWebForm.aspx");
		}
		public void SectionExit(TestWebForm form)
		{
			if (navigator.HasNextSet)
			{
				GetNextSet();
				form.Response.Redirect("descriptionWebForm.aspx");
			}else
			{
				endTest(form);
			}
		}

		public void SectionExit(PracticeGeneralWebForm form)
		{
			if (navigator.HasNextSet)
			{
				GetNextSet();
				form.Response.Redirect("descriptionWebForm.aspx");
			}
			else
			{
				endPractice(form);
			}
		}

		public void TestWebForm_Exit(TestWebForm form)
		{
			form.Response.Redirect("mainwebform.aspx");	
		}
		public void TestWebForm_Load(TestWebForm form)
		{
			testWebForm = form;
			switch (form.status)
			{
				case "NONE":
						break;
				case "answerConfirm":
						TestWebForm_AnswerConfirm(form);
						break;
				case "sectionExit":
						SectionExit(form);
						break;
				case "exit":
						TestWebForm_Exit(form);
						break;
			}
		
			TestFormInit(testWebForm);
		}

		private void TestFormInit(TestWebForm testWebForm)
		{
				
			loginStatusHyperLink.Text = "Log out...";
            loginStatusHyperLink.NavigateUrl = "loginWebForm.aspx";
			questionGUID = Guid.NewGuid();
			testWebForm.PassageImage.Visible = false;
			if (question.SubtypeId == (int)Question.Subtype.ReadingComprehensionPassage)
			{
		
			}
			if (question.SubtypeId == (int)Question.Subtype.ReadingComprehensionQuestionToPassage)
			{
				passageGUID = Guid.NewGuid();
				imageSet =  renderer.Render(question);
				testWebForm.PassageImage.Visible = true;
				imageSet.Question.Save(mapPath + @"\images\Question&AnswerTempPictures\" + questionGUID.ToString() + ".gif", ImageFormat.Gif);
				testWebForm.QuestionImage.ImageUrl = @"images/Question&AnswerTempPictures/" + questionGUID.ToString() + ".gif";
				(renderer.RenderPasssageToQuestion(navigator.GetPasssageToQuestion(question.Id))).Save(mapPath + @"\images\Question&AnswerTempPictures\" + passageGUID.ToString()  + ".gif", ImageFormat.Gif);
				testWebForm.PassageImage.ImageUrl = @"images/Question&AnswerTempPictures/" +passageGUID.ToString() +  ".gif";
				PrepareAndRenderAnswers();
			}
			else
			{
				imageSet =  renderer.Render(question);
				imageSet.Question.Save(mapPath + @"\images\Question&AnswerTempPictures\" + questionGUID.ToString() + ".gif", ImageFormat.Gif);
				testWebForm.QuestionImage.ImageUrl = @"images/Question&AnswerTempPictures/" + questionGUID.ToString() + ".gif";
				PrepareAndRenderAnswers();
			}
			
		
			testWebForm.clockHiddenParam += "<INPUT id=\"timehh\" type=\"hidden\" value=\"" +navigator.RemainedTime.Hours.ToString()+ "\" name=\"timehh\">";
			testWebForm.clockHiddenParam += "<INPUT id=\"timemm\" type=\"hidden\" value=\"" +navigator.RemainedTime.Minutes.ToString()+ "\" name=\"timemm\">";
			testWebForm.clockHiddenParam += "<INPUT id=\"timess\" type=\"hidden\" value=\"" +navigator.RemainedTime.Seconds.ToString()+ "\" name=\"timess\">";

			//<INPUT id="isAnswerConfirm" type="hidden" value="false" name="isAnswerConfirm"><INPUT id="Hidden1" type="hidden" name="endData">
			
		}

		public void TestWebForm_Init(TestWebForm testWebForm)
		{
			answerRadioButtonList = testWebForm.AnswerRadioButtonList;
			statusLabel = testWebForm.StatusLabel;
		    
		    
			//testWebForm.answerConfirmImagebutton.Visible = true;
			loginStatusHyperLink = testWebForm.LoginStatusHyperLink;
			statusLabel.Visible = false; 
			if (testWebForm.IsPostBack)
			{
				DeletePicturesFiles();
			}
			
           }

		public void showHelp(TestWebForm form)
		{
			string path = mapPath + @"\help_templates.html";
			string help = (new StreamReader(path)).ReadToEnd();
			help = help.Replace("%url%", "\"http://GMATClubChallenge.com/TestWebForm.aspx\"");
			StreamWriter sr = File.CreateText(mapPath + @"\help.html");
			sr.Write(help);
			sr.Close();
			form.Response.Redirect("help.html");
		}

		public void showHelp(PracticeGeneralWebForm form)
		{
			string path = mapPath + @"\help_templates.html";
			string help = (new StreamReader(path)).ReadToEnd();
			help = help.Replace("%url%", "\"http://GMATClubChallenge.com/practicewebform.aspx\"");
			StreamWriter sr = File.CreateText(mapPath + @"\help.html");
			sr.Write(help);
			sr.Close();
			form.Response.Redirect("help.html");
		}

		public void TestWebForm_CreateScripts(TestWebForm form)
		{
			for (int i = 0; i < questionAnswerSet.Answers.Count; i++)
			{
                nextClickScript += "if (document.Form1.answerRadioButtonList_" + i.ToString() + ".checked) {document.Form1.answerConfirmImg.src ='images/answerConfirm.gif'; document.Form1.nextButton.src = 'images/_nextButton.gif'; document.Form1.isAnswerConfirm.value=\"nextClicking\"} ";
                //answerConfirmClickScript += "if (document.Form1.answerRadioButtonList_" + i.ToString() + ".checked) {document.Form1.isAnswerConfirm.value=\"answerConfirm\";document.Form1.submit(''); "; 
			}
            answerConfirmClickScript += "if (document.Form1.isAnswerConfirm.value == \"nextClicking\"){document.Form1.isAnswerConfirm.value=\"answerConfirm\";document.Form1.submit(''); }";//
			form.nextClickScript = nextClickScript;
			form.answerConfirmClickScript = answerConfirmClickScript;
		}


	    public void PracticeGeneralWebForm_Exit(PracticeGeneralWebForm form)
	    {
            navigator.CommitResult();
	        form.Response.Redirect("mainWebForm.aspx");
	    }

	   
	}
}

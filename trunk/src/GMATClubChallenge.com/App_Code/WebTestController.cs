using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GmatClubTest.BusinessLogic;
using GmatClubTest.Data;
using GmatClubTest.QuestionRenderer;
using GMATClubTest.Web;

namespace GMATClubTest.Web
{
    public class WebTestController
    {
       
        //Use child class!
        protected Manager manager = null;
        protected INavigator navigator;
        //
        
        private bool isPractice = new bool();
        public  TestSet.TestsRow testRow;
        private QuestionSetSet.QuestionSetsRow questionSet;
        private QuestionAnswerSet questionAnswerSet = new QuestionAnswerSet();
        private QuestionAnswerSet.QuestionsRow question;
        private QuestionAnswerSet.AnswersRow[] answersRow;
        private string descriptionTestString;
        private RadioButtonList answerRadioButtonList;
        private Label statusLabel;
        private Label timeLabel;
        private HyperLink loginStatusHyperLink;
        private ReviewWebForm _reviewWebForm;
        protected int activSetNumber = 0;
        private TestWebForm testWebForm;
        private string nextClickScript;
        private string answerConfirmClickScript;
        private Guid answerGUID;
        private Guid questionGUID;
        private Guid passageGUID;
        private Guid[] answerGUIDMas = new Guid[20];
        protected Renderer renderer = new Renderer();
        private ImageSet imageSet;
        private string mapPath = HttpContext.Current.Request.MapPath(".");
        private PracticeGeneralWebForm practicelWebForm;
        private int selectedAnswer;
        private bool started = false;
                
        
        public WebTestController(TestSet.TestsRow testRow, Manager manager)
        {
            isPractice = testRow.IsPractice;
            this.manager = manager;
            this.testRow = testRow;
            navigator = manager.RunTest(testRow);
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
                for (i = 0; i <= answerGUIDMas.Length; i++)
                {
                    File.Delete(mapPath + @"\images\Question&AnswerTempPictures\" + answerGUIDMas[i].ToString() + ".gif");
                }
            }
            catch
            {
            }
        }

        public void PrepareTestDescription(IDescription form)
        {
            descriptionTestString = "";
            string caption = testRow.Name;
            descriptionTestString += "<< " + caption + " >>" + "<p>";
            string typeCaption = (testRow.IsPractice ? "Practice" : "Computer-Adaptive Test") +
                                 ((testRow.IsQuestionTypeIdNull())
                                      ? ("")
                                      :
                                  (": " +
                                   Question.Type.GetName(typeof (Question.Type), testRow.QuestionTypeId).ToString()));
            descriptionTestString += typeCaption + "<p>";
            if (navigator.TotalTime != TimeSpan.MaxValue)
            {
                descriptionTestString += "Time: " + String.Format("{0} min", navigator.TotalTime.TotalMinutes) + "<p>";
            }
            else
            {
                descriptionTestString += "Time: " + "unlimited" + "<p>";
                
            }
            descriptionTestString += "Number of questions: " + navigator.TotalNumberOfQuestions.ToString() + "<p>";
            descriptionTestString += testRow.Description.ToString() + "<p>";
            form.Caption("Description: " + testRow.Name);
            form.DescriptionString(descriptionTestString);
        }

        public void PrepareSetDescription(IDescription form)
        {
            descriptionTestString = "";
            string caption = questionSet.Name;
            descriptionTestString += "<< " + caption + " >>" + "<p>";
            string typeCaption = "Section " +
                                 ((questionSet.IsQuestionTypeIdNull())
                                      ? ("")
                                      :
                                  (": " +
                                   Question.Type.GetName(typeof (Question.Type), questionSet.QuestionTypeId).ToString()));
            descriptionTestString += typeCaption + "<p>";
            if (navigator.TotalTime != TimeSpan.MaxValue)
            {
                descriptionTestString += "Time: " + String.Format("{0} min", questionSet.TimeLimit) + "<p>";
            }
            else
            {
                descriptionTestString += "Time: " + "unlimited" + "<p>";
                
            }
            if (isPractice)
            {
                descriptionTestString += "Number of questions: " + questionSet.NumberOfQuestionsToPick.ToString() +
                                         "<p>";
            }
            else
            {
                descriptionTestString += "Number of questions: " +
                                         (questionSet.NumberOfQuestionsInZone1 + questionSet.NumberOfQuestionsInZone2 +
                                          questionSet.NumberOfQuestionsInZone3).ToString() + "<p>";
            }
            //descriptionTestString += "Number of questions: " + navigator.TotalNumberOfQuestions.ToString() + "<p>";
            descriptionTestString += questionSet.Description.ToString() + "<p>";

            form.Caption("Description: " + questionSet.Name);
            form.DescriptionString(descriptionTestString);
        }


        public void PracticeWebForm_Load(PracticeGeneralWebForm practicelWebForm)
        {
            this.practicelWebForm = practicelWebForm;
            practicelWebForm.clockHiddenParam += "<INPUT id=\"timehh\" type=\"hidden\" value=\"" +
                                                 navigator.RemainedTime.Hours.ToString() + "\" name=\"timehh\">";
            practicelWebForm.clockHiddenParam += "<INPUT id=\"timemm\" type=\"hidden\" value=\"" +
                                                 navigator.RemainedTime.Minutes.ToString() + "\" name=\"timemm\">";
            practicelWebForm.clockHiddenParam += "<INPUT id=\"timess\" type=\"hidden\" value=\"" +
                                                 navigator.RemainedTime.Seconds.ToString() + "\" name=\"timess\">";

            if (practicelWebForm.IsPostBack)
            {
                return;
            }
            PracticeFormInit(practicelWebForm);
        }

        private void PracticeFormInit(PracticeGeneralWebForm practicelWebForm)
        {
            GetNextQuestion();

            loginStatusHyperLink.Text = "Log out...";
            loginStatusHyperLink.NavigateUrl = "loginWebForm.aspx";
            practicelWebForm.PracticeNameLabel.Text = testRow.Name;
            questionGUID = Guid.NewGuid();

            statusLabel.Visible = false;
            practicelWebForm.PassageImage.Visible = false;
            // practicelWebForm.PassageImage.Visible = true;
            if (question.SubtypeId == (int) Question.Subtype.ReadingComprehensionPassage)
            {
                // To Do Exeption
            }
            if (question.SubtypeId == (int) Question.Subtype.ReadingComprehensionQuestionToPassage)
            {
                passageGUID = Guid.NewGuid();
                imageSet = renderer.Render(question);
                //practicelWebForm.PassageImage.Visible = true;
                practicelWebForm.PassageImage.Visible = true;
                imageSet.Question.Save(
                    mapPath + @"\images\Question&AnswerTempPictures\" + questionGUID.ToString() + ".gif",
                    ImageFormat.Gif);
                practicelWebForm.QuestionImage.ImageUrl = @"images/Question&AnswerTempPictures/" +
                                                          questionGUID.ToString() + ".gif";
                (renderer.RenderPasssageToQuestion(navigator.GetPasssageToQuestion(question.Id))).Save(
                    mapPath + @"\images\Question&AnswerTempPictures\" + passageGUID.ToString() + ".gif", ImageFormat.Gif);
                practicelWebForm.PassageImage.ImageUrl = @"images/Question&AnswerTempPictures/" + passageGUID.ToString() +
                                                         ".gif";
                PrepareAndRenderAnswers();
            }
            else
            {
                imageSet = renderer.Render(question);
                //imageSet.Question.Save(HttpContext.Current.Request.MapPath("www.GMATClubChallenge.com") + mapPath + @"\images\Question&AnswerTempPictures\" + questionGUID.ToString() + ".gif", ImageFormat.Gif);
                string path = (mapPath + "\\images\\Question&AnswerTempPictures\\" + questionGUID.ToString() + ".gif");
                imageSet.Question.Save(path, ImageFormat.Gif);
                practicelWebForm.QuestionImage.ImageUrl = @"images/Question&AnswerTempPictures/" +
                                                          questionGUID.ToString() + ".gif";
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
                imageSet.Answers[i].Save(
                    mapPath + @"\images\Question&AnswerTempPictures\" + answerGUID.ToString() + ".gif", ImageFormat.Gif);
                InitAnswerRadioButton(i);
            }
            CheckAnswerBoxOnTransitionOfQuestion();
        }

        public void InitAnswerRadioButton(int answerNam)
        {
            answerRadioButtonList.Items.Add(answerNam.ToString());
            answerRadioButtonList.Items[answerNam].Value = answerNam.ToString();
            answerRadioButtonList.Items[answerNam].Text = "<img src=\"images/Question&AnswerTempPictures/" +
                                                          answerGUID.ToString() + ".gif\" alt=\"\" border=\"0\" />";
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

        protected void GetActivQuestion()
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
            if (!navigator.HasNextQuestion)
            {
                throw new ApplicationException("No next question");
            }
            navigator.GetNextQuestion(questionAnswerSet);
            question = questionAnswerSet.Questions[0];
            answersRow = question.GetAnswersRows();
        }


        public void DescriptionCancelImageButton_Click(DescriptionWebForm descriptionWebForm)
        {
            descriptionWebForm.Response.Redirect("mainwebform.aspx");
        }

        public void PracticeWebForm_NextButtonClick(PracticeGeneralWebForm form)
        {
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
            int id = questionAnswerSet.Answers[selectedAnswer].Id;
            //TODO: Review flag!
            navigator.SetUserAnswer(id, true);
            //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!1
            if (navigator.HasNextQuestion)
            {
                PracticeFormInit(form);
            }
            else
            {
                if (navigator.HasNextSet)
                {
                    GetNextSet();
                    form.Response.Redirect("descriptionwebform.aspx");
                }
                else
                {
                    navigator.CommitResult();
                    
                    form.Session.Add("IsEndTest", true);
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
                    //form.Response.Redirect("_reviewWebForm.aspx");
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
                }
                else
                {
                    statusLabel.Text = "Your answer is incorrect.";
                }
            }
            else
            {
                statusLabel.Text = "Your answer is incorrect.";
            }
        }

        public void ReviewWebForm_Init(ReviewWebForm form)
        {
            _reviewWebForm = form;
            form.ErrorLabel.Visible = true;
            QuestionAnswerSet qas;
            if (_reviewWebForm.Session["IReviewFormController"] == null)
            {
                _reviewWebForm.Session.Add("IReviewFormController", new ReviewFormController(testRow, manager));
            }
            ((IReviewFormController)_reviewWebForm.Session["IReviewFormController"]).Init(_reviewWebForm);
        }

        public void imageButton_Click(object sender, ImageClickEventArgs e)
        {
            if (!((navigator.HasNextSet) || (navigator.HasNextQuestion)))
            {
                navigator.CommitResult();
                _reviewWebForm.Response.Redirect("resultsWebForm.aspx");
            }
            else
            {
                _reviewWebForm.Response.Redirect("practicewebform.aspx");
            }
        }

       
        protected void TransitionOnSelectSet(int selectedSetNamber)
        {
            if (!navigator.HasRandomSetAccess)
            {
                _reviewWebForm.ErrorLabel.Text = "Random access to quest is impossible on this test.";
                return;
            }
            if (!navigator.HasRandomQuestionAccess)
            {
                _reviewWebForm.ErrorLabel.Text = "Random access to quest is impossible on this test.";
                return;
            }
            navigator.SetActiveSet(navigator.Sets.QuestionSets[selectedSetNamber].Id);
            activSetNumber = selectedSetNamber;
        }

        protected void TransitionOnSelectQuestion(int questionNamber, int selectedSetNamber)
        {
            if (!navigator.HasRandomSetAccess)
            {
                _reviewWebForm.ErrorLabel.Text = "Random access to quest is impossible on this test.";
                return;
            }
            if (!navigator.HasRandomQuestionAccess)
            {
                _reviewWebForm.ErrorLabel.Text = "Random access to quest is impossible on this test.";
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

            for (i = 0; i <= answersRow.Length; ++i)
            {
                if (answersRow[i].Id == status.answeredId)
                {
                    answerRadioButtonList.Items[i].Selected = true;
                    selectedAnswer = i;
                    return;
                }
            }
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
            selectedAnswer = ((RadioButtonList) sender).SelectedIndex;
        }

        public void TestWebForm_AnswerConfirm(TestWebForm testWebForm)
        {
            navigator.SetUserAnswer(questionAnswerSet.Answers[testWebForm.AnswerRadioButtonList.SelectedIndex].Id);
            if (!navigator.HasNextQuestion)
            {
                if (navigator.HasNextSet)
                {
                    GetNextSet();
                    testWebForm.Response.Redirect("descriptionWebForm.aspx");
                }
                else
                {
                    endTest(testWebForm);
                }
            }
        }

        private void endTest(TestWebForm form)
        {
            navigator.CommitResult();
            form.Session.Add("resultId", navigator.ResultResultDetailSet.Results[0].Id);
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
            }
            else
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
            GetNextQuestion();

            loginStatusHyperLink.Text = "Log out...";
            loginStatusHyperLink.NavigateUrl = "loginWebForm.aspx";
            questionGUID = Guid.NewGuid();
            testWebForm.PassageImage.Visible = false;
            if (question.SubtypeId == (int) Question.Subtype.ReadingComprehensionPassage)
            {
            }
            if (question.SubtypeId == (int) Question.Subtype.ReadingComprehensionQuestionToPassage)
            {
                passageGUID = Guid.NewGuid();
                imageSet = renderer.Render(question);
                testWebForm.PassageImage.Visible = true;
                imageSet.Question.Save(
                    mapPath + @"\images\Question&AnswerTempPictures\" + questionGUID.ToString() + ".gif",
                    ImageFormat.Gif);
                testWebForm.QuestionImage.ImageUrl = @"images/Question&AnswerTempPictures/" + questionGUID.ToString() +
                                                     ".gif";
                (renderer.RenderPasssageToQuestion(navigator.GetPasssageToQuestion(question.Id))).Save(
                    mapPath + @"\images\Question&AnswerTempPictures\" + passageGUID.ToString() + ".gif", ImageFormat.Gif);
                testWebForm.PassageImage.ImageUrl = @"images/Question&AnswerTempPictures/" + passageGUID.ToString() +
                                                    ".gif";
                PrepareAndRenderAnswers();
            }
            else
            {
                imageSet = renderer.Render(question);
                imageSet.Question.Save(
                    mapPath + @"\images\Question&AnswerTempPictures\" + questionGUID.ToString() + ".gif",
                    ImageFormat.Gif);
                testWebForm.QuestionImage.ImageUrl = @"images/Question&AnswerTempPictures/" + questionGUID.ToString() +
                                                     ".gif";
                PrepareAndRenderAnswers();
            }


            testWebForm.clockHiddenParam += "<INPUT id=\"timehh\" type=\"hidden\" value=\"" +
                                            navigator.RemainedTime.Hours.ToString() + "\" name=\"timehh\">";
            testWebForm.clockHiddenParam += "<INPUT id=\"timemm\" type=\"hidden\" value=\"" +
                                            navigator.RemainedTime.Minutes.ToString() + "\" name=\"timemm\">";
            testWebForm.clockHiddenParam += "<INPUT id=\"timess\" type=\"hidden\" value=\"" +
                                            navigator.RemainedTime.Seconds.ToString() + "\" name=\"timess\">";

            testWebForm.TestNameLabel.Text = "Test: " + testRow.Name;

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
                nextClickScript += "if (document.Form1.answerRadioButtonList_" + i.ToString() +
                                   ".checked) {document.Form1.answerConfirmImg.src ='images/answerConfirm.gif'; document.Form1.nextButton.src = 'images/_nextButton.gif'; document.Form1.isAnswerConfirm.value=\"nextClicking\"} ";
                //answerConfirmClickScript += "if (document.Form1.answerRadioButtonList_" + i.ToString() + ".checked) {document.Form1.isAnswerConfirm.value=\"answerConfirm\";document.Form1.submit(''); "; 
            }
            answerConfirmClickScript +=
                "if (document.Form1.isAnswerConfirm.value == \"nextClicking\"){document.Form1.isAnswerConfirm.value=\"answerConfirm\";document.Form1.submit(''); }";
            //
            form.nextClickScript = nextClickScript;
            form.answerConfirmClickScript = answerConfirmClickScript;
        }

        public void PracticeGeneralWebForm_Exit(PracticeGeneralWebForm form)
        {
            navigator.CommitResult();
            form.Response.Redirect("mainWebForm.aspx");
        }

        public void OnDescriptionOk(Page form)
        {
            if (!started)
            {
                started = true;
                GetNextSet();
            }

            if (isPractice)
            {
                form.Response.Redirect("practiceWebForm.aspx");
            }
            else
            {
                form.Response.Redirect("testWebForm.aspx");
            }
        }

        public void PrepareDescription(IDescription form)
        {
            if (!started)
                PrepareTestDescription(form);
            else
                PrepareSetDescription(form);
        }
    }
}
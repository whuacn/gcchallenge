function reviewFlag_Click()
{
    if(document.Form1.reviewFlag.value == "False")
    {
        document.Form1.reviewFlag.value = "True"; 
        //document.Form1.reviewFlagImg.src = "/FlagForReviewChecked.gif";  
        document.images['reviewFlagImg'].src = "FlagForReviewChecked.gif";     
    }
    else
    {
        document.Form1.reviewFlag.value = "False"; 
        //document.Form1.reviewFlagImg.src = "/FlagForReview.gif";
        document.images['reviewFlagImg'].src = "FlagForReview.gif";
    }
}
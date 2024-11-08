namespace ReportError.DTO;

public class ErrorRequest
{
    public string Shop{get;set;}
    public string IssueReporter{get;set;}
    public DateTime TimeReport{get;set;}
    public string DescriptionError{get;set;}
    public string ErrorChecker { get; set; }
    public string ErrorDetails { get; set; }
    public string RootCause{get;set;}
}
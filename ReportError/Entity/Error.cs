using System.ComponentModel.DataAnnotations;

namespace ReportError;

public class Error
{
    [Key]public string ErrorId { get; set; }
    public string Shop{get;set;}
    public string IssueReporter{get;set;}
    public DateTime TimeReport{get;set;}
    public string DescriptionError{get;set;}
    public string ErrorChecker { get; set; }
    public string ErrorDetails { get; set; }
    public string RootCause{get;set;}
    public string Solution { get; set; }
    
    
    
    
}
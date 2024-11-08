using System.ComponentModel.DataAnnotations;

namespace ReportError;

public class User
{
    [Key] public int Id { set; get; } 
    public string Username { set; get; }
    public string Password{set;get;}
    public string Role{set;get;}
    
    public string NumberPhone{set;get;}
    
    
}
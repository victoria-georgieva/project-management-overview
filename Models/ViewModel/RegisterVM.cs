using System.ComponentModel.DataAnnotations;

public class RegisterVM
{
    [Required(ErrorMessage = "The Username is required"), MaxLength(50)]
    public string Username
    {
        get;
        set;
    }
    [Required(ErrorMessage = "The Email is required"), DataType(DataType.EmailAddress)]
    public string Email
    {
        get;
        set;
    }
    [Required(ErrorMessage = "The Password is required"), DataType(DataType.Password)]
    public string Password
    {
        get;
        set;
    }

    public int role{get;set;}
}
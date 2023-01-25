using System.ComponentModel.DataAnnotations;

public class SignInVM
{
    [Required(ErrorMessage = "The UsernameOrEmail is required")]
    public string UsernameOrEmail
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

}
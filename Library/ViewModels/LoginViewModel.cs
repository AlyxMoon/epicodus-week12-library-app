using System.ComponentModel.DataAnnotations;

namespace Library.ViewModels
{
  public class LoginViewModel
  {
    public string Username { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }
  }
}
namespace WebApi.Models.Users;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class UpdateRequest
{
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TypeRoom
    {
        get=> _typeroom;
        set=> _typeroom = value;
    }

    if(TypeRoom not null)&&(TypeRoom=="single")
        int Pret=100;
    else
      if(TypeRoom not null)&&(TypeRoom=="double")
        int Pret=150;
      else
        int Pret=200;

    private string _facilities;
    public string Facilities
    {
        get => _facilities; 
        set => _facilities = replaceEmptyWithNull(value);
    }
    if(Facilities not null)&&(Facilities=="breakfast")
        int Pret=Pret+15;
    else
      if(Facilities not null)&&(Facilities=="room cleaning")
        int Pret=Pret+25;
    else
      if(Facilities not null)&&(Facilities=="mini-bar")
        int Pret=Pret+50;
    else
      int Pret=Pret+60;

    [EnumDataType(typeof(Role))]
    public string Role { get; set; }

    [EmailAddress]
    public string Email { get; set; }

    // treat empty string as null for password fields to 
    // make them optional in front end apps
    private string _password;
    [MinLength(6)]
    public string Password
    {
        get => _password;
        set => _password = replaceEmptyWithNull(value);
    }

    private string _confirmPassword;
    [Compare("Password")]
    public string ConfirmPassword 
    {
        get => _confirmPassword;
        set => _confirmPassword = replaceEmptyWithNull(value);
    }

    // helpers

    private string replaceEmptyWithNull(string value)
    {
        // replace empty string with null to make field optional
        return string.IsNullOrEmpty(value) ? null : value;
    }
}
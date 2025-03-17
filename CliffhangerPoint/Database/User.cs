using System;
using System.Data.Common;
using Microsoft.AspNetCore.Identity;

namespace CliffhangerPoint.Database;

public class User : IdentityUser
{
  public string login {get; set;}

  public string password {get; set;}

}

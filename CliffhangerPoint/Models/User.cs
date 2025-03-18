using System;
using System.Data.Common;
using Microsoft.AspNetCore.Identity;

namespace CliffhangerPoint.Database;

public class User : IdentityUser
{
  public string? Initials {get; set;}

}

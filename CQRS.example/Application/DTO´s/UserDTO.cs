using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dcaba.users.Models;

public class UserDTO
{
  
    public int Id { get; set; }

    public string? UsrName { get; set; }

    public string? UsrPassword { get; set; }


}

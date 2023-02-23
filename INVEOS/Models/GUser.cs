using System;
using System.Collections.Generic;

namespace INVEOS.Models;

public partial class GUser
{
    public int Id { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool Status { get; set; }

    public int Phone { get; set; }

    public string Email { get; set; } = null!;

    public string Gender { get; set; } = null!;
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SMDP.SMDPModels;

[Table("Users", Schema = "Codal")]
public partial class User
{
    [StringLength(50)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    public string? LastName { get; set; }

    [Key]
    [StringLength(16)]
    [Unicode(false)]
    public string UserName { get; set; } = null!;

    public byte[] PasswordHash { get; set; } = null!;

    public byte[]? PasswordSalt { get; set; }

    [StringLength(13)]
    [Unicode(false)]
    public string? Mobile { get; set; }

    public int? Role { get; set; }

    public int? StatusId { get; set; }

    public int? TypeId { get; set; }

    public int? RegDate { get; set; }

    public int? RegTime { get; set; }
}

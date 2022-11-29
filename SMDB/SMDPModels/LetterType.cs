using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SMDP.SMDPModels;

[Table("LetterTypes", Schema = "Codal")]
public partial class LetterType
{
    [Key]
    public int Id { get; set; }

    public int? LetterTypeId { get; set; }

    [StringLength(255)]
    public string? Code { get; set; }

    [StringLength(255)]
    public string? Name { get; set; }

    public int? PublisherTypeId { get; set; }

    public int? LetterGroupId { get; set; }
}

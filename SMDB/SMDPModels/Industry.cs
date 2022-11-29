using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SMDP.SMDPModels;

public partial class Industry
{
    [Key]
    public int Id { get; set; }

    [StringLength(255)]
    public string? IndustryName { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? IndustryNameEnglish { get; set; }

    public int? RegDate { get; set; }

    public int? RegTime { get; set; }
}

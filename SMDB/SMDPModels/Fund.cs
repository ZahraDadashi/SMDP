using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SMDP.SMDPModels;

[Table("Funds", Schema = "Fund")]
public partial class Fund
{
    [Key]
    public int Id { get; set; }

    [Column("CFundId")]
    public int? CfundId { get; set; }

    public int? InstituteTypeId { get; set; }

    [StringLength(255)]
    public string? InstituteType { get; set; }

    [StringLength(2048)]
    public string? InstituteKindId { get; set; }

    [StringLength(2048)]
    public string? InstituteKind { get; set; }

    [Column("SEORegisterNo")]
    public int? SeoregisterNo { get; set; }

    [StringLength(2048)]
    public string? Website { get; set; }

    [StringLength(255)]
    public string? Name { get; set; }

    [StringLength(255)]
    public string? NationalId { get; set; }

    [Column("CEO")]
    [StringLength(2048)]
    public string? Ceo { get; set; }

    [Column("CEOMobileNo")]
    public int? CeomobileNo { get; set; }

    public int? StateId { get; set; }

    [StringLength(2048)]
    public string? State { get; set; }

    public int? RegDate { get; set; }

    public int? RegTime { get; set; }

    [StringLength(50)]
    public string? Type { get; set; }

    [Column("NAVUrl")]
    [StringLength(2048)]
    public string? Navurl { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SMDB.SMDPModels;

[Table("DailyPrice")]
[Index("Deven", Name = "NonClusteredIndex-20210912-132637", AllDescending = true)]
[Index("InsCode", Name = "NonClusteredIndex-20211108-102000")]
public partial class DailyPrice
{
    [Key]
    public int Id { get; set; }

    public long? InsCode { get; set; }

    [Column("DEven")]
    public int? Deven { get; set; }

    [Column("PClosing")]
    public double? Pclosing { get; set; }

    [Column("PDrCotVal")]
    public double? PdrCotVal { get; set; }

    [Column("ZTotTran")]
    public double? ZtotTran { get; set; }

    [Column("QTotTran5J")]
    public double? QtotTran5J { get; set; }

    [Column("QTotCap")]
    public double? QtotCap { get; set; }

    public double? PriceMin { get; set; }

    public double? PriceMax { get; set; }

    public double? PriceYesterday { get; set; }

    public double? PriceFirst { get; set; }

    public int? RegDate { get; set; }

    public int? RegTime { get; set; }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SMDB.SMDPModels;

[Keyless]
[Table("Instruments", Schema = "Tsetmc")]
public partial class Instrument
{
    [Column("DEVen")]
    public int? Deven { get; set; }

    public long? InsCode { get; set; }

    [Column("InstrumentID")]
    public string? InstrumentId { get; set; }

    [Column("CValMne")]
    public string? CvalMne { get; set; }

    [Column("LVal18")]
    public string? Lval18 { get; set; }

    [Column("CSocCSAC")]
    public string? CsocCsac { get; set; }

    [Column("LSoc30")]
    public string? Lsoc30 { get; set; }

    [Column("LVal18AFC")]
    public string? Lval18Afc { get; set; }

    [Column("LVal30")]
    public string? Lval30 { get; set; }

    [Column("CIsin")]
    public string? Cisin { get; set; }

    [Column("QNmVlo", TypeName = "decimal(18, 0)")]
    public decimal? QnmVlo { get; set; }

    [Column("ZTitad", TypeName = "decimal(18, 0)")]
    public decimal? Ztitad { get; set; }

    [Column("DESop")]
    public int? Desop { get; set; }

    [Column("YOPSJ")]
    public byte? Yopsj { get; set; }

    [Column("CGdSVal")]
    public string? CgdSval { get; set; }

    [Column("CGrValCot")]
    public string? CgrValCot { get; set; }

    [Column("DInMar")]
    public int? DinMar { get; set; }

    [Column("YUniExpP")]
    public byte? YuniExpP { get; set; }

    [Column("YMarNSC")]
    public string? YmarNsc { get; set; }

    [Column("CComVal")]
    public string? CcomVal { get; set; }

    [Column("CSecVal")]
    public string? CsecVal { get; set; }

    [Column("CSoSecVal")]
    public string? CsoSecVal { get; set; }

    [Column("YDeComp")]
    public byte? YdeComp { get; set; }

    [Column("PSaiSMaxOkValMdv", TypeName = "decimal(18, 0)")]
    public decimal? PsaiSmaxOkValMdv { get; set; }

    [Column("PSaiSMinOkValMdv", TypeName = "decimal(18, 0)")]
    public decimal? PsaiSminOkValMdv { get; set; }

    public long? BaseVol { get; set; }

    [Column("YVal")]
    public int? Yval { get; set; }

    [Column("QPasCotFxeVal", TypeName = "decimal(18, 0)")]
    public decimal? QpasCotFxeVal { get; set; }

    [Column("QQtTranMarVal")]
    public int? QqtTranMarVal { get; set; }

    public byte? Flow { get; set; }

    public long? QtitMinSaiOmProd { get; set; }

    public long? QtitMaxSaiOmProd { get; set; }

    public byte? Valid { get; set; }
}

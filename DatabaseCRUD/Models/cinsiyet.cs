using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


public class cinsiyet
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int cinsiyetId { get; set; }

    [Required]
    public string cinsiyetAdi { get; set; }
}
public class personel
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int personelNo { get; set; }
    [Required(ErrorMessage = "ad boş bırakılamaz")]
    public string ad { get; set; }
    [Required] public string soyad { get; set; }

    [ForeignKey("cinsiyetId")]
    public cinsiyet cinsiyet { get; set; }
    public int cinsiyetId { get; set; }
}


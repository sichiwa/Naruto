using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Naruto.Models
{
    [Table("CheckReportItems", Schema = "SDMGR")]
    public class CheckReportItems
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "流水號")]
        public int SN { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Display(Name = "主機名稱")]
        public string ServerName { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Display(Name = "主機IP")]
        public string ServerIP { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(4000)]
        [Display(Name = "檢查訊息")]
        public string CheckMsg { get; set; }

        [Required]
        [Display(Name = "檢查日期")]
        public DateTime CheckDate { get; set; }

        [Required]
        [Display(Name = "寫入時間")]
        public DateTime insertTime { get; set; }

    }
}

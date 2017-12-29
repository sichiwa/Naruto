using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naruto.Models
{
    [Table("CheckReportSummaries", Schema = "SDMGR")]
    public class CheckReportSummaries
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

        [Display(Name = "檢查目錄個數")]
        public int DirCount { get; set; }

        [Display(Name = "檢查檔案個數(不會變)")]
        public int DataCount { get; set; }

        [Display(Name = "檢查Log檔個數(變動)")]
        public int LogCount { get; set; }

        //[Column(TypeName = "nvarchar")]
        //[StringLength(4000)]
        //[Display(Name = "檢查訊息")]
        //public string CheckMsg { get; set; }

        [Required]
        [Display(Name = "檢查結果")]
        public bool CheckResult { get; set; }

        [Required]
        [Display(Name = "最後異動時間")]
        public DateTime UpdateTime { get; set; }

    }
}

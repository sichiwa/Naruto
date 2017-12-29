using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naruto.Models
{
    [Table("CheckServers", Schema = "SDMGR")]
    public class CheckServers
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "流水號")]
        public int SN { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(100)]
        [Display(Name = "主機名稱")]
        public string Name { get; set; }

        [Column(TypeName = "nvarchar")]
        [StringLength(200)]
        [Display(Name = "主機IP")]
        public string IP { get; set; }

        [Required]
        [DefaultValue(true)]
        [Display(Name = "是否啟用")]
        public bool Enable { get; set; }

        [Required]
        [DefaultValue(true)]
        [Display(Name = "是否啟用資料檢查")]
        public bool EnableDataCheck { get; set; }

        [Required]
        [DefaultValue(true)]
        [Display(Name = "是否啟用Log檢查")]
        public bool EnableLogCheck { get; set; }

        [Display(Name = "目錄清單最後異動時間(不會變)")]
        public DateTime DirListTime { get; set; }
        
        [Display(Name = "檔案最後異動時間(不會變)")]
        public DateTime DataListTime { get; set; }

        [Display(Name = "Log目錄清單最後異動時間(變動)")]
        public DateTime LogDirListTime { get; set; }

        [Display(Name = "檢核開始時間")]
        public DateTime CheckStartTime { get; set; }

        [Display(Name = "檢核結束時間")]
        public DateTime CheckEndTime { get; set; }

        [Display(Name = "檢核花費時間(毫秒)")]
        public decimal CheckCost { get; set; }

        [Display(Name = "是否完成檢核")]
        public bool Finish { get; set; }

        [DefaultValue("1911-01-01")]
        [Display(Name = "最後異動時間")]
        public DateTime UpdateTime { get; set; }
    }
}

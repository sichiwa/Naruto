using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Naruto.Models
{
    [Table("CheckedDirs", Schema = "SDMGR")]
    public class CheckedDirs
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SN { get; set; }

        /// <summary>
        /// 名稱
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>

        [StringLength(1000)]
        public string FullName { get; set; }

        public DateTime CheckDate { get; set; }

        public int CheckSN { get; set; }

        [Required]
        [Display(Name = "主機代號")]
        public int ServerSN { get; set; }

        /// <summary>
        /// HASH值
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        ///
        [StringLength(600)]
        public string HashValue { get; set; }

        /// <summary>
        /// 是否被檢查過了
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool Checked { get; set; }
    }
}

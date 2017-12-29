using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Naruto.Models
{
    [Table("CheckedDataFiles", Schema = "SDMGR")]
    public class CheckedDataFiles
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

        [StringLength(1000)]
        public string FilePath { get; set; }

        public DateTime CheckDate { get; set; }

        public int CheckSN { get; set; }

        [Required]
        [Display(Name = "主機代號")]
        public int ServerSN { get; set; }

        /// <summary>
        /// 是否為檔案
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool isFile { get; set; }
       

        /// <summary>
        /// 建立時間
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public DateTime CreateTime { get; set; }
    
        /// <summary>
        /// 最後存取時間
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public DateTime LastAccessTime { get; set; }
      
        /// <summary>
        /// 最後寫入時間
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public DateTime LastWriteTime { get; set; }

        /// <summary>
        /// 是否唯讀
        /// </summary>
        /// <value></value>
        /// <returns></returns>
        /// <remarks></remarks>
        public bool ReadOnly { get; set; }

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

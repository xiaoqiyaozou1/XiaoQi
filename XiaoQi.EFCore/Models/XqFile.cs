using System;
using System.Collections.Generic;

namespace XiaoQi.EFCore.Models
{
    public partial class XqFile
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string StorageType { get; set; }
        public string OriginalFileName { get; set; }
        public long? Size { get; set; }
        public string Suffix { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string FilePath { get; set; }
        public string FullFilePath { get; set; }
        public string FileHash { get; set; }
        public string UploadType { get; set; }
        public DateTime? UploadStartTime { get; set; }
        public DateTime? UploadEndTime { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? UpdateTime { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace alisanljoj.Model
{
    [Table("RequestBt")]
    public class RequestBt
    {
        [Key]
        public int RequestId { get; set; }
        public int RequestNo { get; set; }
        public string Requestor { get; set; }
        public string RequestDate { get; set; }
        public string SystemName { get; set; }
        public string AccessType { get; set; }
        public string[] AccessType2 { get; set; }
        public string Description { get; set; }
        public string? Status { get; set; }
        public string? DescriptionDeny { get; set; }
        public string? DescriptionDenyIt { get; set; }


    }
}

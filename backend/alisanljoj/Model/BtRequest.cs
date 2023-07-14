using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace alisanljoj.Model
{
    [Table("BtRequest")]
    public class BtRequest

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


    }
}

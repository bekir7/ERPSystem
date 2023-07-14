using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alisanljoj.Model
{
    [Table("Fatura")]
    public class FaturaRequest
    {
        [Key]
        public int RequestId { get; set; }
        public int RequestNo { get; set; }
        public string Requestor { get; set; }
        public string RequestDate { get; set; }
        public string? RequestCategory { get; set; }
        public string? RequestDepot { get; set; }
        public string? RequestSupplier { get; set; }
        public string? RequestMaterial { get; set; }
        public string RequestPaymentType { get; set; }
        public int RequestPieces { get; set; }
        public string RequestDescription { get; set; }
    }
}

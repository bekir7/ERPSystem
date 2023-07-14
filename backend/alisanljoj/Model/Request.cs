using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alisanljoj.Model
{
    [Table("Request")]
    public class Request
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
        public string? Status { get; set; }
        public string? DescriptionDeny { get; set; }
        public string? DescriptionDeny2 { get; set; }



    }
}

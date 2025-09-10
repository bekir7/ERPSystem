using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alisanljoj.Model
{
    [Table("Sipariş")]
    public class SiparisRequest : BaseRequest
    {
        [StringLength(50, ErrorMessage = "Request category cannot exceed 50 characters")]
        public string? RequestCategory { get; set; }
        
        [StringLength(50, ErrorMessage = "Request depot cannot exceed 50 characters")]
        public string? RequestDepot { get; set; }
        
        [StringLength(100, ErrorMessage = "Request supplier cannot exceed 100 characters")]
        public string? RequestSupplier { get; set; }
        
        [StringLength(100, ErrorMessage = "Request material cannot exceed 100 characters")]
        public string? RequestMaterial { get; set; }
        
        [Required(ErrorMessage = "Request payment type is required")]
        [StringLength(50, ErrorMessage = "Request payment type cannot exceed 50 characters")]
        public string RequestPaymentType { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Request pieces is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Request pieces must be greater than 0")]
        public int RequestPieces { get; set; }
    }
}

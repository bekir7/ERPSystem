using System.ComponentModel.DataAnnotations;

namespace alisanljoj.DTOs
{
    public class RequestDto
    {
        public int RequestId { get; set; }
        public int RequestNo { get; set; }
        public string Requestor { get; set; } = string.Empty;
        public string RequestDate { get; set; } = string.Empty;
        public string? RequestCategory { get; set; }
        public string? RequestDepot { get; set; }
        public string? RequestSupplier { get; set; }
        public string? RequestMaterial { get; set; }
        public string RequestPaymentType { get; set; } = string.Empty;
        public int RequestPieces { get; set; }
        public string RequestDescription { get; set; } = string.Empty;
        public string? Status { get; set; }
        public string? DescriptionDeny { get; set; }
        public string? DescriptionDeny2 { get; set; }
    }

    public class CreateRequestDto
    {
        [Required(ErrorMessage = "Request number is required")]
        public int RequestNo { get; set; }
        
        [Required(ErrorMessage = "Requestor is required")]
        [StringLength(100, ErrorMessage = "Requestor name cannot exceed 100 characters")]
        public string Requestor { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Request date is required")]
        public string RequestDate { get; set; } = string.Empty;
        
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
        
        [Required(ErrorMessage = "Request description is required")]
        [StringLength(200, ErrorMessage = "Request description cannot exceed 200 characters")]
        public string RequestDescription { get; set; } = string.Empty;
    }

    public class UpdateRequestStatusDto
    {
        [Required(ErrorMessage = "Request number is required")]
        public int RequestNo { get; set; }
        
        [Required(ErrorMessage = "Status is required")]
        [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters")]
        public string Status { get; set; } = string.Empty;
        
        [StringLength(500, ErrorMessage = "Description deny cannot exceed 500 characters")]
        public string? DescriptionDeny { get; set; }
        
        [StringLength(500, ErrorMessage = "Description deny 2 cannot exceed 500 characters")]
        public string? DescriptionDeny2 { get; set; }
    }
}

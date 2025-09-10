using System.ComponentModel.DataAnnotations;

namespace alisanljoj.Model
{
    public abstract class BaseSystemRequest
    {
        [Key]
        public int RequestId { get; set; }
        
        [Required(ErrorMessage = "Request number is required")]
        public int RequestNo { get; set; }
        
        [Required(ErrorMessage = "Requestor is required")]
        [StringLength(100, ErrorMessage = "Requestor name cannot exceed 100 characters")]
        public string Requestor { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Request date is required")]
        public string RequestDate { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "System name is required")]
        [StringLength(100, ErrorMessage = "System name cannot exceed 100 characters")]
        public string SystemName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Access type is required")]
        [StringLength(50, ErrorMessage = "Access type cannot exceed 50 characters")]
        public string AccessType { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Access type 2 is required")]
        public string[] AccessType2 { get; set; } = Array.Empty<string>();
        
        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; } = string.Empty;
    }
}

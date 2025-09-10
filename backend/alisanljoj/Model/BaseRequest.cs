using System.ComponentModel.DataAnnotations;

namespace alisanljoj.Model
{
    public abstract class BaseRequest
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
        
        [StringLength(200, ErrorMessage = "Request description cannot exceed 200 characters")]
        public string RequestDescription { get; set; } = string.Empty;
    }
}

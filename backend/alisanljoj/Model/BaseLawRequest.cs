using System.ComponentModel.DataAnnotations;

namespace alisanljoj.Model
{
    public abstract class BaseLawRequest
    {
        [Key]
        public int Id { get; set; }
        
        public int? ArchiveId { get; set; } // arşiv no
        
        [StringLength(100, ErrorMessage = "Client name cannot exceed 100 characters")]
        public string? ClientName { get; set; } // müvekkil
        
        [StringLength(50, ErrorMessage = "Client status cannot exceed 50 characters")]
        public string? ClientStatus { get; set; } // müvekkil konumu(davalı,davacı)
        
        [StringLength(50, ErrorMessage = "Case status cannot exceed 50 characters")]
        public string? CaseStatus { get; set; } // dava durumu
        
        public string? Date { get; set; } // tarih
        
        [StringLength(50, ErrorMessage = "Court type cannot exceed 50 characters")]
        public string? CourtType { get; set; } // mahkeme türü
        
        [StringLength(50, ErrorMessage = "Case type cannot exceed 50 characters")]
        public string? CaseType { get; set; } // dava türü
        
        [StringLength(50, ErrorMessage = "City cannot exceed 50 characters")]
        public string? City { get; set; } // il
        
        [StringLength(50, ErrorMessage = "County cannot exceed 50 characters")]
        public string? County { get; set; } // ilçe
        
        [StringLength(100, ErrorMessage = "Court cannot exceed 100 characters")]
        public string? Court { get; set; } // mahkeme
        
        [StringLength(50, ErrorMessage = "Basis number cannot exceed 50 characters")]
        public string? BasisNo { get; set; } // esas no
        
        [StringLength(50, ErrorMessage = "Type cannot exceed 50 characters")]
        public string? Type { get; set; } // Karşı taraf türü (şahıs,şirket.....)
        
        [StringLength(50, ErrorMessage = "Counterparty status cannot exceed 50 characters")]
        public string? CounterpartyStatus { get; set; } // Karşı taraf konumu (davalı,davacı.....)
        
        [StringLength(100, ErrorMessage = "Counterparty name cannot exceed 100 characters")]
        public string? CounterpartyName { get; set; } // Karşı taraf adı
        
        [Range(10000000000, 99999999999, ErrorMessage = "TC must be 11 digits")]
        public int? TC { get; set; } // Karşı taraf Tc
        
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters")]
        public string? Description { get; set; } // açıklama
        
        public int? Time { get; set; }
        public int? Time2 { get; set; }
    }
}

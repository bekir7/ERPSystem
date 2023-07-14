using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alisanljoj.Model
{
    [Table("Duruşma")]
    public class HukukDurusma
    {
        [Key]
        public int Id { get; set; }
        public int? ArchiveId { get; set; }//arşiv no
        public string? ClientName { get; set; }//müvekkil
        public string? ClientStatus { get; set; }//müvekkil konumu(davalı,davacı)
        public string? CaseStatus { get; set; }//dava durumu
        public string? Date { get; set; }//tarih
        public string? CourtType { get; set; }//mahkeme türü
        public string? CaseType { get; set; }//dava türü
        public string? City { get; set; }//il
        public string? County { get; set; }//ilçe
        public string? Court { get; set; } //mahkeme
        public string? BasisNo { get; set; } //esas no
        public string? Type { get; set; } //Karşı taraf türü (şahıs,şirket.....)
        public string? CounterpartyStatus { get; set; } //Karşı taraf konumu (davalı,davacı.....)
        public string? CounterpartyName { get; set; } //Karşı taraf adı 
        public int? TC { get; set; } //Karşı taraf Tc 
        public string? Description { get; set; } //açıklama 
        public int? Time { get; set; }
        public int? Time2 { get; set; }

    }
}

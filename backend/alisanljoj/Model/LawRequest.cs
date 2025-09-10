using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace alisanljoj.Model
{
    [Table("LawRequest")]
    public class LawRequest : BaseLawRequest
    {
        // BaseLawRequest'ten tüm özellikler gelir
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace alisanljoj.Model
{
    [Table("RequestBt")]
    public class RequestBt : BaseSystemRequestWithApproval
    {
        // BaseSystemRequestWithApproval'den tüm özellikler gelir
    }
}

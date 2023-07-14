using alisanljoj.Model;
using Microsoft.EntityFrameworkCore;

namespace alisanljoj.Data
{
    public class RequestContext:DbContext
    {
        public RequestContext(DbContextOptions<RequestContext> options) : base(options) { }
        public DbSet<Request> Requests { get; set; }
        public DbSet<FaturaRequest> FaturaRequests { get; set; }
        public DbSet<YoneticiRequest> YoneticiRequests { get; set; }
        public DbSet<SiparisRequest> SiparisRequests { get; set; }
        public DbSet<KargoRequest> KargoRequests { get; set; }
        public DbSet<KargoYonetici> KargoYoneticis { get; set; }
        public DbSet<RequestBt> RequestBts { get; set; }
        public DbSet<BtRequest> BtRequests { get; set; }
        public DbSet<ItRequest> ItRequests { get; set; }
        public DbSet<LawRequest> LawRequests { get; set; }
        public DbSet<HukukDurusma> HukukDurusmas { get; set; }
        public DbSet<HukukSonuc> HukukSonucs { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;

namespace RandomUserApp.Models
{
    public class APPConfiguration
    {
        public int ID { get; set; }
        public string BaseAddress { get; set; }
        public string ApiURL { get; set; }
    }
}

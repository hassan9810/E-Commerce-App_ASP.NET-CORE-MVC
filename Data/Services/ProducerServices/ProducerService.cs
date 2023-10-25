using eCommerce.Context;
using eCommerce.Data.Entity;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data.Services.ProducerServices
{
    public class ProducerService : EntityRepository<Producer>, IProducerService
    {
        public ProducerService(AppDbContext context) : base(context) { }
    }
}

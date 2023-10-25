using eCommerce.Context;
using eCommerce.Data.Entity;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data.Services.ActorServices
{
    public class ActorService : EntityRepository<Actor>, IActorsService
    {
        public ActorService(AppDbContext context) : base(context) { }
    }
}

using eCommerce.Context;
using eCommerce.Data.Entity;
using eCommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Data.Services.ProducerServices
{
    public class CinemaService : EntityRepository<Cinema>, ICinemaService
    {
       public CinemaService(AppDbContext context) : base(context) { }
    }
}

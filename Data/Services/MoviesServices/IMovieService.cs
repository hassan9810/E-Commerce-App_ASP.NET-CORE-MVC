using eCommerce.Data.Entity;
using eCommerce.Data.ViewModels;
using eCommerce.Models;

namespace eCommerce.Data.Services.ProducerServices
{
    public interface IMovieService : IEntityRepository<Movie>
    {
        Task<Movie> GetMovieByIdAsync(int id);
        Task<NewMovieDropdownsVM> GetNewMovieDropdownsValues();
        Task AddNewMovieAsync(NewMovieVM data);
        Task UpdateMovieAsync(NewMovieVM data);
    }
}

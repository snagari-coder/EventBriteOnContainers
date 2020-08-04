using EventWebMvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventWebMvc.Services
{
    public interface ICatalogService
    {
        Task<EventCatalog> GetEventCatalogItemsAsync(int page, int size, int? category, int? format);
        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
        Task<IEnumerable<SelectListItem>> GetFormatsAsync();
        Task AddItemToFavorites(EventItem product);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using EventWebMvc.Models;
using EventWebMvc.Services;
using EventWebMvc.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;

namespace EventWebMvc.Controllers
{
    public class EventCatalogController : Controller
    {
        private readonly ICatalogService _service;
        public EventCatalogController(ICatalogService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index(int? page, int? categoryFilterApplied, int? formatFilterApplied)
        {
            var itemsOnPage = 10;
            var eventcatalog = await _service.GetEventCatalogItemsAsync(page ?? 0, itemsOnPage, categoryFilterApplied, formatFilterApplied);

            var vm = new CatalogIndexViewModel
            {
                EventItems = eventcatalog.Data,
                Categories = await _service.GetCategoriesAsync(),
                Formats = await _service.GetFormatsAsync(),
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = eventcatalog.PageSize,
                    TotalItems = eventcatalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)eventcatalog.Count / itemsOnPage)
                },
                CategoryFilterApplied = categoryFilterApplied ?? 0,
                FormatFilterApplied = formatFilterApplied ?? 0
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddToFavorite(EventItem selectedEvent)
        {
            var check = selectedEvent.Id;
            try
            {
                if (selectedEvent.Id > 0)
                {
                    selectedEvent.Favorite = 1;
                    //var product = new EventItem()
                    //{
                    //    Favorite = 1
                    //};
                    await _service.AddItemToFavorites(selectedEvent);
                }
                return RedirectToAction("Index", "EventCatalog");
            }
            catch (BrokenCircuitException)
            {
                                
                HandleBrokenCircuitException();
            }

            return RedirectToAction("Index", "EventCatalog");
        }

        private void HandleBrokenCircuitException()
        {
            TempData["BasketInoperativeMsg"] = "cart Service is inoperative, please try later on. (Business Msg Due to Circuit-Breaker)";
        }

        [Authorize]
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";


            return View();
        }
    }
}

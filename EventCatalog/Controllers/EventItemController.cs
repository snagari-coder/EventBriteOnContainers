using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalog.Data;
using EventCatalog.Domain;
using EventCatalog.ViewModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Routing.Template;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace EventCatalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class EventItemController : ControllerBase
    {
        private readonly EventCatalogContext _context;

        private readonly IWebHostEnvironment _env;

        private readonly IConfiguration _config;
        public EventItemController(EventCatalogContext context, IWebHostEnvironment env, IConfiguration config)
        {
            _context = context;
            _env = env;
            _config = config;
            
        }

        public class FileUpload
        {
            public IFormFile File;
        }




        [HttpPost("[action]")]
        public async Task<IActionResult> EventDetails([FromForm] EventInputData eventInput, IFormFile File)
        {



            var result = await EventCatalogSeed.UpdateEvent(eventInput, _context, File, _env);
            if (result == "Event Addition Succesful")
                return Ok(result);
            else
                return Problem(result);
        }


        [HttpGet("[action]")]

        public async Task<IActionResult> Items(

          [FromQuery]int pageIndex = 0,

          [FromQuery]int pageSize = 3)

        {
            var itemscount = await _context.EventItems.LongCountAsync();
            var items = await _context.EventItems

                            .OrderBy(c => c.Event_Name)

                            .Skip(pageIndex * pageSize)

                            .Take(pageSize)

                            .ToListAsync();

            items = ChangePictureUrl(items);

            var model = new PaginatedItemsViewModel<EventItem>
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemscount,
                Data = items
            };

            return Ok(model);

        }


        [HttpGet("[action]")]
        public async Task<IActionResult> EventFormats()
        {
            var formats = await _context.EventFormats.ToListAsync();
            return Ok(formats);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventAudiences()
        {
            var audiences = await _context.EventAudiences.ToListAsync();
            return Ok(audiences);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventKinds()
        {
            var kinds = await _context.EventKinds.ToListAsync();
            return Ok(kinds);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventLanguages()
        {
            var languages = await _context.EventLanguages.ToListAsync();
            return Ok(languages);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventLocations()
        {
            var locations = await _context.EventLocations.ToListAsync();
            return Ok(locations);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> EventZipcodes()
        {
            var zipcodes = await _context.EventZipCodes.ToListAsync();
            return Ok(zipcodes);
        }


        private List<EventItem> ChangePictureUrl(List<EventItem> items)
        {


            foreach (var item in items)
            {
                if (item.Event_Pictureurl != "Not Provided")
                {
                    item.Event_Pictureurl = item.Event_Pictureurl.Replace(item.Event_Pictureurl, (_config["ExternalCatalogBaseUrl"] + "/api/Pic/" + item.Event_Pictureurl));
                }
            }

            return items;

        }



     

        [HttpGet("[action]/category/{EventCategoryId}/audience/{EventAudienceId}/format/{EventFormatId}/kind/{EventKindId}/language/{EventLanguageId}/location/{EventLocationId}/zipcode/{EventZipCodeId}")]
        [HttpGet("[action]/category/{EventCategoryId}")]
        [HttpGet("[action]/format/{EventFormatId}")]
        [HttpGet("[action]/ZipCode/{EventZipCodeId}")]
        [HttpGet("[action]/language/{EventLanguageId}")]
        [HttpGet("[action]/location/{EventLocationId}")]
        [HttpGet("[action]/Kind/{EventKindId}")]
        [HttpGet("[action]/category/{EventCategoryId}/format/{EventFormatId}")]
        [HttpGet("[action]/category/{EventCategoryId}/audience/{EventAudienceId}")]
        public async Task<IActionResult> GetItems(
           int? EventCategoryId,
           int? EventAudienceId,
           int? EventFormatId,
           int? EventKindId,
           int? EventLanguageId,
           int? EventLocationId,
           int? EventZipCodeId,
           [FromQuery]int pageIndex = 0,
           [FromQuery]int pageSize = 3
            )
        {
          
            var query = (IQueryable<EventItem>)_context.EventItems;

            if (EventCategoryId.HasValue)
            {
                query = query.Where(e => e.Event_CategoryId == EventCategoryId);
            }
            if (EventAudienceId.HasValue)
            {
                query = query.Where(e => e.Event_AudienceId == EventAudienceId);
            }
            if (EventFormatId.HasValue)
            {
                query = query.Where(e => e.Event_FormatId == EventFormatId);
            }
            if (EventKindId.HasValue)
            {
                query = query.Where(e => e.Event_KindId == EventKindId);
            }
            if (EventLanguageId.HasValue)
            {
                query = query.Where(e => e.Event_LanguageId == EventLanguageId);
            }
            if (EventLocationId.HasValue)
            {
                query = query.Where(e => e.Event_LocationId == EventLocationId);
            }
            if (EventZipCodeId.HasValue)
            {
                query = query.Where(e => e.Event_ZipCodeId == EventZipCodeId);
            }

            var itemsCount = await query.LongCountAsync();
            var items = await query
                             .OrderBy(e => e.Event_Name)
                             .Skip(pageIndex * pageSize)
                             .Take(pageSize)
                             .ToListAsync();
           
                items = ChangePictureUrl(items);
                var model = new PaginatedItemsViewModel<EventItem>
                {
                    PageIndex = pageIndex,
                    PageSize = items.Count,
                    Count = itemsCount,
                    Data = items
                };

                return Ok(model);
          

        }

        

        [HttpGet("[action]/{dateval}")]
        public async Task<IActionResult> GetItemsbyDate(
            DateTime dateval, 
           [FromQuery]int pageIndex = 0,
           [FromQuery]int pageSize = 3)
        {

            var query = (IQueryable<EventItem>)_context.EventItems;
            query = (IQueryable<EventItem>)query.Where(e => e.Event_Start_Time.Date == dateval.Date);

            var itemsCount = query.LongCountAsync();

            var items = await query
                             .OrderBy(c => c.Event_Name)
                            .Skip(pageIndex * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

            items = ChangePictureUrl(items);
            var model = new PaginatedItemsViewModel<EventItem>
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount.Result,
                Data = items
            };

            return Ok(model);
           


        }

        


    }
}
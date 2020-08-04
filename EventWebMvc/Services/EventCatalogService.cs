using EventWebMvc.Infrastructure;
using EventWebMvc.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EventWebMvc.Services
{
    public class EventCatalogService : ICatalogService
    {
        private readonly string _baseUrl;
        private readonly IHttpClient _client;
        public EventCatalogService(IConfiguration config, IHttpClient client)
        {
            _baseUrl = $"{config["EventCatalogUrl"]}/api/eventitem/";
            _client = client;
        }
        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var categoryuri = ApiPaths.Catalog.GetAllCategories(_baseUrl);
            var datastring = await _client.GetStringAsync(categoryuri);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected = true
                }
            };

            var categories = JArray.Parse(datastring);
            foreach (var category in categories)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = category.Value<string>("id"),
                        Text = category.Value<String>("event_Category")
                    });
                    
            }

            return items;
        
        }


        public async Task<EventCatalog> GetEventCatalogItemsAsync(int page, int size, int? category, int? format)
        {
           var eventCatalogItemsUri = ApiPaths.Catalog.GetAllEventItems(_baseUrl, page, size, category, format);
           var datastring = await _client.GetStringAsync(eventCatalogItemsUri);
           return JsonConvert.DeserializeObject<EventCatalog>(datastring);
        }

        public async Task<IEnumerable<SelectListItem>> GetFormatsAsync()
        {
            var formaturi = ApiPaths.Catalog.GetAllFormats(_baseUrl);
            var datastring = await _client.GetStringAsync(formaturi);
            var items = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Value = null,
                    Text = "All",
                    Selected = true
                }
            };

            var formats = JArray.Parse(datastring);
            foreach (var format in formats)
            {
                items.Add(
                    new SelectListItem
                    {
                        Value = format.Value<string>("id"),
                        Text = format.Value<String>("event_Format")
                    });

            }

            return items;
        }

        public async Task AddItemToFavorites(EventItem product)
        {
            var check = product.Id;
            product.Favorite = 1;
                   
            
            await UpdateEventItem(product);
        }

        public async Task<EventItem> UpdateEventItem(EventItem product)
        {

            var check = product;
            var updateEventUri = ApiPaths.Catalog.UpdateEvent(_baseUrl);
            
            var response = await _client.PostAsync(updateEventUri, product);
            response.EnsureSuccessStatusCode();

            return product;
        }
    }
}

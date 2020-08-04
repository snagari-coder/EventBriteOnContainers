using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventWebMvc.Infrastructure
{
    public static class ApiPaths
    {
        public static class Catalog
        {
            public static string GetAllCategories(string baseUri)
            {
                return $"{baseUri}eventcategories";
            }

            public static string GetAllFormats(string baseUri)
            {
                return $"{baseUri}eventformats";
            }

            public static string GetAllEventItems(string baseUri, int page, int take, int? category, int? format)
            {
                var filterQs = string.Empty;
                if(category.HasValue || format.HasValue)
                {
                    var categoryQs = (category.HasValue) ? category.Value.ToString() : " ";
                    var formatQs = (format.HasValue) ? format.Value.ToString() : " ";
                    filterQs = $"/category/{categoryQs}/format/{formatQs}";

                }

                return $"{baseUri}getitems{filterQs}?pageIndex={page}&pageSize={take}";
            }

            public static string UpdateEvent(string baseUri)
            {
                
                return $"{baseUri}PostEventProperty";
            }
        }
    }
}

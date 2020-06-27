using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalog.Domain
{
    public enum PickDate
    {
        PickADate,
        AnyDay,
        Today,
        Tomorrow,
        ThisWeekend,
        ThisWeek,
        NextWeek,
        ThisMonth,
        NextMonth,
        
    }
    public class EventDate
    {
        public int Id { get; set; }
        public string Event_PickDate { get; set; }

    }
}

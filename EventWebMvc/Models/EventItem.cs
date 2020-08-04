﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventWebMvc.Models
{
    public class EventItem
    {
        public int Id { get; set; }

        public string Event_Name { get; set; }

        public string Event_Desc { get; set; }

        public int Event_Capacity { get; set; }

        public int Favorite { get; set; }

        public DateTime Event_Start_Time { get; set; }

        public DateTime Event_End_Time { get; set; }

        public string Event_Pictureurl { get; set; }

        public string Event_Online_Link { get; set; } //Link for event if online  //Change the name online_lnk

        public string Event_Address { get; set; } //Address of the venue optional if online

        public decimal Event_Price { get; set; }

        public int Event_LocationId { get; set; } //Foreign Key for Location online or venue based

        public string Event_Location { get; set; } //EventLocation type to ensure no junk values entered for foreign key

        public int Event_CategoryId { get; set; } //Foreign key for category 

        public string Event_Category { get; set; }  //EventCategory type to ensure no junk values are entered for foreign key



        public int Event_LanguageId { get; set; }//EventLanguage foreign key

        public string Event_Language { get; set; }

        public int Event_KindId { get; set; }

        public string Event_Kind { get; set; }

        public string Event_ZipCode { get; set; }

        public int Event_ZipCodeId { get; set; }

        public string Event_UserId { get; set; }

        

        public int Event_AudienceId { get; set; }

        public string Event_Audience { get; set; }

        public int Event_FormatId { get; set; }

        public string Event_Format { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EventCatalog.Data;
using EventCatalog.Domain;

namespace EventCatalog.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    //public class EventUserController : ControllerBase
    //{
    //    private readonly EventCatalogContext _context;
    //    public EventUserController(EventCatalogContext context)
    //    {
    //        _context = context;

    //    }



    //    [HttpPost("[action]")]
    //    //public IActionResult UserDetails([FromForm] EventUserInfo UserInfo)
    //    //{
    //    //    try
    //    //    {
    //    //        EventUserInfo user = new EventUserInfo();
    //    //        user.UserName = UserInfo.UserName;
    //    //        user.Password = UserInfo.Password;
    //    //        user.Email_Id = UserInfo.Email_Id;
    //    //        _context.EventUserInfos.Add(user);
    //    //        _context.SaveChanges();

    //    //        return Ok(UserInfo);
    //    //    }
    //    //    catch(Exception ex)
    //    //    {
    //    //        return Problem(ex.GetType().Name +" : UserName Already Exists");
    //    //    }
    //    //}
    //}
}
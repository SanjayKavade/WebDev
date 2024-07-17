using Bloggie.Web.Data;
using Bloggie.Web.Models.Domain;
using Bloggie.Web.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Controllers
{
    [Authorize] //This will restict controller. If user not logged in then any of the action will not be accessible
    public class AdminTagsController : Controller
    {
        private BloggieDbContext _bloggieDbContext;

        public AdminTagsController(BloggieDbContext bloggieDbContext)
        {
            _bloggieDbContext = bloggieDbContext;
        }

        [HttpGet]
        //[Authorize] this is to restrict actions
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        //[Authorize] this is to restrict actions
        // [AllowAnonymous] this is to allow certain action from controller if entire controller is Authorize
        //[ActionName("Add")]
        public IActionResult SubmitTag(AddTagRequest addTagRequest ) 
        {
            //var name = Request.Form["name"];
            //var displayname = Request.Form["displayName"];

            //var name = addTagRequest.Name;
            //var displayName = addTagRequest.DisplayName;

            var tag = new Tag { Name = addTagRequest.Name, DisplayName = addTagRequest.DisplayName };
            
            _bloggieDbContext.Tags.Add(tag);

            _bloggieDbContext.SaveChanges();

            return View("Add");
        }

    }
}

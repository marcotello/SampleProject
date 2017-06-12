using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SampleProject.Controllers
{
    [Route("admin")]
    public class AdminController : Controller
    {
        //If nothing is provided in the URL, NVC will take this action as default
        [Route("")]
        //normal /Admin/Save
        [Route("save")]
        //If you want to put nothing in the root URL and redirect to this action
        [Route("~/save")]
        public string Save()
        {
            return "Saved";
        }

        [Route("delete/{id?}")]
        public string Delete(int id=0)
        {
            return String.Format("Deleted : {0}", id);
        }

        [Route("update")]
        public string Update(int id = 0)
        {
            return String.Format("Updated : {0}", id);
        }
    }
}

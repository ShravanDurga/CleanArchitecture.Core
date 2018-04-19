using Microsoft.AspNetCore.Mvc.Razor;
using System.Collections.Generic;

namespace CleanArchitecture.Core.Presentation.Admin
{
    public class CustomRazorViewEngine : IViewLocationExpander

    {

        //public CustomRazorViewEngine()
        //{
        //    ViewLocationFormats = new string[]
        //    {
        //        "~/{1}/Views/{0}.cshtml",
        //    };

        //    PartialViewLocationFormats = new string[]
        //    {
        //        "~/Shared/Views/{0}.cshtml"
        //    };
        //}

        public void PopulateValues(ViewLocationExpanderContext context)
        {
            context.Values["customviewlocation"] = nameof(CustomRazorViewEngine);
        }

        public IEnumerable<string> ExpandViewLocations(
              ViewLocationExpanderContext context,
              IEnumerable<string> viewLocations)
        {
            var viewLocationFormats = new[]
            {
            "~/{1}/Views/{0}.cshtml",
            "~/Shared/Views/{0}.cshtml"
        };
            return viewLocationFormats;
        }

    }
}

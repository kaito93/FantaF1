using FantaF1.Extentions;
using FantaF1.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace FantaF1
{
    public class UploadFileFilter : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var fileInformation = new List<FileInformation>();

            if (filterContext != null)
            {
                var request = filterContext.HttpContext.Request;
                if (request.Files.Count > 0)
                {
                    foreach (string uploadedFile in request.Files)
                    {
                        if (request.Files[uploadedFile] != null)
                        {
                            if (request.Files[uploadedFile].ContentLength > 0)
                            {
                                var fileInfo = request.Files[uploadedFile].GetFileInformation();
                                fileInformation.Add(fileInfo);
                            }
                        }
                    }
                }

                filterContext.ActionParameters["uploadedFiles"] = fileInformation;

            }

            base.OnActionExecuting(filterContext);
        }

    }
}
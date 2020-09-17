using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Globalization;
using System.IO;
using System.Text;

namespace _3dIntiriorClients.ErrorHandling
{
    public class CustomErrorHandling : Attribute, IExceptionFilter
    {
        [Obsolete]
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;

        [Obsolete]
        public CustomErrorHandling(
            IHostingEnvironment hostingEnvironment,
            IModelMetadataProvider modelMetadataProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }

        [Obsolete]
        public void OnException(ExceptionContext context)
        {
            if (!_hostingEnvironment.IsDevelopment())
            {
                return;
            }
            var errorFolder = Path.Combine(_hostingEnvironment.WebRootPath, "ErrorLogs");
            context.ExceptionHandled = true;
            if (!Directory.Exists(errorFolder))
            {
                Directory.CreateDirectory(errorFolder);
            }
            string timestamp = DateTime.Now.ToString("d-MMMM-yyyy", CultureInfo.InvariantCulture);
            var newFileName = $"Log_{timestamp}.txt";
            var filepath = Path.Combine(_hostingEnvironment.WebRootPath, "ErrorLogs") + $@"\{newFileName}";
            StringBuilder expectionStringBuilder = new StringBuilder();
            expectionStringBuilder.AppendLine("Message ---\n{0}" + context.Exception.Message);
            expectionStringBuilder.AppendLine("Source ---\n{0}" + context.Exception.Source);
            expectionStringBuilder.AppendLine("StackTrace ---\n{0}" + context.Exception.StackTrace);
            expectionStringBuilder.AppendLine("TargetSite ---\n{0}" + context.Exception.TargetSite);

            if (!File.Exists(filepath))
            {
                using (var writer = File.CreateText(filepath))
                {
                    var controllerName = context.RouteData.Values["controller"];
                    var actionName = context.RouteData.Values["action"];
                    writer.WriteLine($"ControllerName :-{controllerName}");
                    writer.WriteLine($"ActionName :- {actionName}");
                    writer.WriteLine("Exception");
                    writer.WriteLine(expectionStringBuilder);
                }
            }
            else
            {
                using (var writer = File.AppendText(filepath))
                {
                    var controllerName = context.RouteData.Values["controller"];
                    var actionName = context.RouteData.Values["action"];
                    writer.WriteLine($"ControllerName :-{controllerName}");
                    writer.WriteLine($"ActionName :- {actionName}");
                    writer.WriteLine("Exception");
                    writer.WriteLine(expectionStringBuilder);
                }
            }

            var result = new ViewResult { ViewName = "Error" };
            result.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
            result.ViewData.Add("Exception", context.Exception);

            context.Result = result;
        }
    }
}

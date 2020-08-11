using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace NbSites.Web.Boots
{
    public static partial class BootExt
    {
        public static void UseMyStaticFiles(this IApplicationBuilder app, IHostingEnvironment hostingEnvironment, ILogger logger)
        {
            //    var webRootFileProvider = hostingEnvironment.WebRootFileProvider;
            //    var myPhysicalFileProvider = new MyPhysicalFileProvider(webRootFileProvider);
            //    myPhysicalFileProvider.InitMap("", webRootFileProvider);
            //    hostingEnvironment.WebRootFileProvider = myPhysicalFileProvider;

            app.UseStaticFiles(new StaticFileOptions
            {
                ContentTypeProvider = new FileExtensionContentTypeProvider
                {
                    Mappings =
                    {
                        [".vue"] = "text/html"
                    }
                }
            });

            //list static files
            app.UseDirectoryBrowser();

            var rootPath = hostingEnvironment.ContentRootPath;
            var publicFiles = Directory.GetFiles(rootPath, "public_this_folder.txt", SearchOption.AllDirectories);
            foreach (var publicFile in publicFiles)
            {
                var publicFolder = Path.GetDirectoryName(publicFile);
                var requestPath = publicFolder.Replace(rootPath, string.Empty, StringComparison.OrdinalIgnoreCase);
                requestPath = requestPath.Replace('\\', '/').TrimEnd('/');
                logger.LogDebug(string.Format("{0} => {1}", publicFolder, requestPath));

                var physicalFileProvider = new PhysicalFileProvider(publicFolder);
                app.UseStaticFiles(new StaticFileOptions
                {
                    FileProvider = physicalFileProvider,
                    RequestPath = requestPath
                });
            }
        }
    }
    
    ///// <summary>
    ///// 解决Linux文件大小写的问题
    ///// </summary>
    //public class MyPhysicalFileProvider : IFileProvider
    //{
    //    private readonly IFileProvider _provider;

    //    public MyPhysicalFileProvider(IFileProvider provider)
    //    {
    //        _provider = provider;
    //        FileCache = new ConcurrentDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
    //    }

    //    public IDictionary<string, string> FileCache { get; set; }


    //    public IFileInfo GetFileInfo(string subPath)
    //    {
    //        if (FileCache.TryGetValue(subPath, out string _value))
    //        {
    //            if (subPath != _value)
    //            {
    //                return _provider.GetFileInfo(_value);
    //            }
    //        }
    //        return _provider.GetFileInfo(subPath);
    //    }

    //    public IDirectoryContents GetDirectoryContents(string subpath)
    //    {
    //        if (FileCache.TryGetValue(subpath, out string _value))
    //        {
    //            if (subpath != _value)
    //            {
    //                return _provider.GetDirectoryContents(_value);
    //            }
    //        }
    //        return _provider.GetDirectoryContents(subpath);
    //    }

    //    public IChangeToken Watch(string filter)
    //    {
    //        return _provider.Watch(filter);
    //    }

    //    public void InitMap(string parentPath, IFileProvider fileProvider)
    //    {
    //        var currentContents = fileProvider.GetDirectoryContents(parentPath);
    //        foreach (var currentContent in currentContents)
    //        {
    //            var currentPath = parentPath + "/" + currentContent.Name;
    //            FileCache.Add(currentPath, currentPath);
    //            if (currentContent.IsDirectory)
    //            {
    //                InitMap(currentPath, fileProvider);
    //            }
    //        }
    //    }
    //}
}

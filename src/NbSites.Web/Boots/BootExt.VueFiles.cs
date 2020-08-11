using System;
using System.IO;
using Common;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;

namespace NbSites.Web.Boots
{
    public static partial class BootExt
    {
        public static void UseMyVueFiles(this IApplicationBuilder app, IHostingEnvironment HostingEnvironment,
            ILogger logger)
        {
            var bagsHolder = BagsHolder.Resolve();
            var myApp = bagsHolder.GetBag("myApp", true);

            var vueComponents = myApp.MyGetIf("vueComponents", BagsHelper.Create(), true);
            //find *.vue auto register => wwwroot, 
            var webRootPath = HostingEnvironment.WebRootPath; // => base/wwwroot
            var contentRootPath = HostingEnvironment.ContentRootPath; // => base
            //var areasPath = System.IO.Path.Combine(HostingEnvironment.ContentRootPath, "Areas"); // => base/Areas
            var vueFiles = Directory.GetFiles(contentRootPath, "*.vue", SearchOption.AllDirectories);
            foreach (var vueFile in vueFiles)
            {
                var fileInfo = new FileInfo(vueFile);
                var requestPath = fileInfo.FullName
                    .Replace(webRootPath, string.Empty, StringComparison.OrdinalIgnoreCase)
                    .Replace(contentRootPath, string.Empty, StringComparison.OrdinalIgnoreCase)
                    .Replace('\\', '/')
                    .TrimEnd('/')
                    .TrimStart('/');

                var componentKey = System.IO.Path.GetFileNameWithoutExtension(fileInfo.Name);

                vueComponents.MySet(componentKey, "/" + requestPath);
                //todo: support register by theme
                //todo: check same key and throws
                //todo: fix linux path case in boots static file logic
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

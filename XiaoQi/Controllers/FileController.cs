using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using XiaoQi.Model;
using XiaoQi.Utilities;

namespace XiaoQi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private MessageModel messageModel = new MessageModel();
        private readonly long _fileSizeLimit;
        private readonly ILogger<FileController> _logger;
        private readonly string[] _permittedExtensions = { ".txt", ".png" };
        private readonly string _targetFilePath;
        // Get the default form options so that we can use them to set the default 
        // limits for request body data.
        private static readonly FormOptions _defaultFormOptions = new FormOptions();

        private readonly IFileProvider _fileProvider;

        public FileController(ILogger<FileController> logger,
            IConfiguration config, IFileProvider fileProvider)
        {
            _logger = logger;
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");
            // To save physical files to a path provided by configuration:
            _targetFilePath = config.GetValue<string>("StoredFilesPath");
            _fileProvider = fileProvider;
            _permittedExtensions = config.GetValue<string>("PermisionFiles").Split(";");
;
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile()
        {
            var saveName = "";//这个地方可以改成List  因为下面的文件是支持多文件上传的
            if (!MultipartRequestHelper.IsMultipartContentType(Request.ContentType))
            {
                messageModel.success = false;
                messageModel.response = "发送请求类型不对！";
                return new JsonResult(messageModel);
          
            }

            var boundary = MultipartRequestHelper.GetBoundary(
                MediaTypeHeaderValue.Parse(Request.ContentType),
                _defaultFormOptions.MultipartBoundaryLengthLimit);
            var reader = new MultipartReader(boundary, HttpContext.Request.Body);
            var section = await reader.ReadNextSectionAsync();

            while (section != null)
            {
                var hasContentDispositionHeader =
                    ContentDispositionHeaderValue.TryParse(
                        section.ContentDisposition, out var contentDisposition);

                if (hasContentDispositionHeader)
                {
                    // This check assumes that there's a file
                    // present without form data. If form data
                    // is present, this method immediately fails
                    // and returns the model error.
                    if (!MultipartRequestHelper
                        .HasFileContentDisposition(contentDisposition))
                    {
                        //ModelState.AddModelError("File",
                        //    $"The request couldn't be processed (Error 2).");
                        // Log error
                        messageModel.success = false;
                        messageModel.response = "错误我也不知道！";
                        return new JsonResult(messageModel);
 
                    }
                    else
                    {
                        // Don't trust the file name sent by the client. To display
                        // the file name, HTML-encode the value.
                        var trustedFileNameForDisplay = WebUtility.HtmlEncode(
                                contentDisposition.FileName.Value);
                        var trustedFileNameForFileStorage = Path.GetRandomFileName();
                        saveName = trustedFileNameForFileStorage = Guid.NewGuid().ToString() + Path.GetExtension(trustedFileNameForDisplay);
                        // **WARNING!**
                        // In the following example, the file is saved without
                        // scanning the file's contents. In most production
                        // scenarios, an anti-virus/anti-malware scanner API
                        // is used on the file before making the file available
                        // for download or for use by other systems. 
                        // For more information, see the topic that accompanies 
                        // this sample.

                        var streamedFileContent = await FileHelper.ProcessStreamedFile(
                            section, contentDisposition, ModelState,
                            _permittedExtensions, _fileSizeLimit);

                        if (!ModelState.IsValid)
                        {
                            messageModel.success = false;
                            messageModel.response = "文件类型不对！";
                            return new JsonResult(messageModel);
                        }

                        //判断文件夹是否存在 如果不存在 则创建
                        var savePath = Path.Combine(Directory.GetCurrentDirectory(),@"wwwroot\",_targetFilePath);
                        FileHelper.CheckDirExist(savePath);


                        using (var targetStream = System.IO.File.Create(
                            Path.Combine(savePath, trustedFileNameForFileStorage)))
                        {
                            await targetStream.WriteAsync(streamedFileContent);
                    
                        }
                    }
                }

                // Drain any remaining section body that hasn't been consumed and
                // read the headers for the next section.
                section = await reader.ReadNextSectionAsync();
            }
            messageModel.response = saveName;
            return new JsonResult(messageModel);
        }
    }
}

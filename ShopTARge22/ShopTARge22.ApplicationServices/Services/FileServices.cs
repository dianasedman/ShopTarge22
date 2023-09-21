using ShopTARge22.Core.Domain;
using ShopTARge22.Core.Dto;
using ShopTARge22.Core.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using ShopTARge22.Data;

namespace ShopTARge22.ApplicationServices.Services
{
    public class FileServices : IFileServices
    {
        private readonly IHostEnvironment _webHost;
        private readonly ShopTARge22Context _context;

        public FileServices
            (
                IHostEnvironment webhost,
                ShopTARge22Context context
            )
        {
            _webHost = webhost;
            _context = context; 
        }
        public void FilesToApi(SpaceshipDto dto, Spaceship spaceship)
        {
            if (dto.Files != null && dto.Files.Count > 0)
            {
                if (!Directory.Exists(_webHost.ContentRootPath + "\\multipleFileUpload\\")) 
                {
                    Directory.CreateDirectory(_webHost.ContentRootPath + "\\multipleFileUpload\\");
                }

                foreach (var file in dto.Files)
                {
                    string uploadFolder = Path.Combine(_webHost.ContentRootPath, "multipleFileUpload");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    string filePath = Path.Combine(uploadFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                        FileToApi path = new FileToApi
                        {
                            Id = Guid.NewGuid(),
                            ExistingFilePath = uniqueFileName,
                            SpaceshipId = spaceship.Id,
                        };

                        _context.FileToApis.AddAsync(path);
                    }
                }
            }
        }
    }
}

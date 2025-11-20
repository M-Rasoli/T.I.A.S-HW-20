using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace App.Infrastructure.FileService.Contracts
{
    public interface IFileService
    {
        public string Upload(IFormFile file, string folder);

    }
}

using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Dtos
{
    public class FileDto
    {
        public string FilenName { get; set; }
        public IFormFile FormFile { get; set; }
    }
}

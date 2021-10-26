using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;

namespace UploadFiles.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {

        [HttpPost]
        public ActionResult PostFiles([FromForm]List<IFormFile> files)
        {
            try
            {
                if(files.Count > 0){

                    foreach(var file in files){
                       
                        var path = Path.Combine(Directory.GetCurrentDirectory(), "DescargaArchivos",  file.FileName);
               
                        using (var stream=System.IO.File.Create(path))
                        {
                            file.CopyTo(stream);
                        }
                    
                    }
                } 
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
                    
    }
}

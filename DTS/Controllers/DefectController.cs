using DATALayer.Domain;
using ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Hosting;
using System.Web.Http;
using ViewModelLayer.ViewModels;

namespace DTS.Controllers
{
    [RoutePrefix("api/Defect")]
    public class DefectController : ApiController
    {

        public static int ID; //Global variable for holding the Defect ID


        private readonly IDefectService _defectData;

        /// <summary>
        /// Parameterized constructor 
        /// For invoking the service layer.
        /// </summary>
        /// <param name="defectData"></param>
        public DefectController(IDefectService defectData)
        {
            _defectData = defectData;
        }

        /// <summary>
        /// Author:Prasanjit Dey
        /// Created on:30-Nov-2016,6:27PM
        /// Method for getting the list of defects.
        /// </summary>
        /// <returns>List of Defect</returns>
        [Route("TotalDefect")]
        public IHttpActionResult Get()
        {
            return Ok(_defectData.GetAllDefect());
        }



        /// <summary>
        /// Author:Piyush Joshi.
        /// Method returning the filtered data on the basis of query.
        /// Created on:1-Dec-2016,11:43AM
        /// </summary>
        [Route("DefectList")]
        // GET api/defect/5
        public IHttpActionResult Get(string search, int page, int itemsPerPage = 5, string sortBy = " ", bool reverse = false)
        {
            return Ok(_defectData.GetDefectList(search, page, itemsPerPage, sortBy));
        }



        /// <summary>
        /// Author:Piyush Joshi.
        /// Store the posted data of Defect from front end.
        /// Created on:30-Nov-2016,6:27PM
        /// </summary>      
        // POST api/defect
        [Route("AddDefect")]
        public int Post([FromBody]DefectFileViewModel value)
        {
            var Id = _defectData.SaveDefectViewModel(value);
            ID = Id;
            return Id;
        }

        // PUT api/defect/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/defect/5
        public void Delete(int id)
        {
        }

        /// <summary>
        /// Author:Piyush Joshi
        /// Created on:5-Dec-2016
        ///Method to save the files in specified folder structure.
        /// </summary>
        /// <returns>Defect ID</returns>

        [Route("upload")]
        public HttpResponseMessage Add()
        {
            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;

            var DefektID = ID; //Variable holding the defect ID


            if (httpRequest.Files.Count > 0)
            {
                var GUID = Guid.NewGuid(); //Generating new GUID
                var docfiles = new List<string>(); //Holding multiple file in a list.
                foreach (string file in httpRequest.Files)
                {
                    string path = "~/UploadedFiles"; //Directory for uploading the attachment
                    path = CheckAndCreateDirectory(path); //Create folder Path if not exist//
                    path += "/" + DateTime.Now.Year.ToString(); //Dynamically creating new folder Current tear
                    path = CheckAndCreateDirectory(path); //checking whether folder already exist
                    path += "/" + String.Format("{0:MMMM}", DateTime.Now); //Dynamically creating new folder Current Month
                    path = CheckAndCreateDirectory(path); //checking whether folder already exist
                    path += "/" + DefektID;  //creating folder on the basis of ID
                    path = CheckAndCreateDirectory(path); //checking whether folder already exist


                    var postedFile = httpRequest.Files[file]; //List of files to be saved
                    var filePath = HttpContext.Current.Server.MapPath(path + "/" + GUID + postedFile.FileName ); //renaming the file name and adding a GUID to it
                    var FullFilePath = path;
                    postedFile.SaveAs(filePath); //saving the file path
                    var fileName = Path.GetFileName(filePath); //Full path name of the attachment

                     //Save Every Image To Attachment Entity
                    _defectData.SaveAttachment(new DefectDocuments()
                    {
                        DefectID = DefektID, //Defect ID for the attachment.
                        OriginalFileName = fileName, //origainal file name of the attachments
                        FilePath = FullFilePath //getting the full path of the file
                    });


                    docfiles.Add(fileName);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }

        //Method to create folder If Not exist
        private static string CheckAndCreateDirectory(string Path)
        {
            if (!Directory.Exists(HostingEnvironment.MapPath(Path))) //If directory not exists
                Directory.CreateDirectory(HostingEnvironment.MapPath(Path)); //If not exist create the directory

            return Path;
        }
    }
}

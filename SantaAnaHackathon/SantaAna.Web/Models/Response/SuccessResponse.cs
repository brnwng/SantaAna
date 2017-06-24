using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SantaAna.Web.Models.Response
{
    /// <summary>
    ///  This class sets IsSuccessful to true by default.
    ///  Many of the response classes will inherit this class
    ///  since they should be returning IsSuccessful = true
    /// </summary>
    public class SuccessResponse : BaseResponse
    {
        public SuccessResponse()
        {
            this.IsSuccessful = true;
        }
    }
}
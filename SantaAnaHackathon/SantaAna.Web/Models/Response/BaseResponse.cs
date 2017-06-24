using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SantaAna.Web.Models.Response
{
    /// <summary>
    /// The base class for the response models.
    /// If it is going out the door from the API it must inherit this class
    /// </summary>
    public abstract class BaseResponse
    {
        public bool IsSuccessful { get; set; }
        public string TransactionId { get; set; }

        public BaseResponse()
        {
            this.TransactionId = Guid.NewGuid().ToString();
        }
    }
}
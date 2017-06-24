using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SantaAna.Web.Models.Response
{
    /// <summary>
    /// generic item response class
    /// </summary>
    public class ItemResponse<T> : SuccessResponse
    {
        public T Item { get; set; }
    }
}
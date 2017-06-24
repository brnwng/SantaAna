using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SantaAna.Web.Models.Response
{
    /// <summary>
    /// Generic response class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ItemsResponse<T> : SuccessResponse
    {
        public List<T> Items { get; set; }
    }
}
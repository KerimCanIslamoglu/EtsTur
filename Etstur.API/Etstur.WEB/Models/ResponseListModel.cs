using Etstur.WEB.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etstur.WEB.Models
{
    public class ResponseListModel<T> : IResponseListModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public IList<T> Response { get; set; }
    }
}

using Etstur.API.Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etstur.API.Model
{
    public class ResponseObjectModel<T> : IResponseObjectModel<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public T Response { get; set; }
    }
}

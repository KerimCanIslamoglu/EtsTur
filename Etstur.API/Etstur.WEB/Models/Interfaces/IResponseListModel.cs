using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Etstur.WEB.Models.Interfaces
{
    public interface IResponseListModel<T>
    {
        bool Success { get; set; }
        string Message { get; set; }
        IList<T> Response { get; set; }
    }
}

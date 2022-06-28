using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public interface IComplexObjectResult<TModel,TErrorList>
    {
        TModel MainResult { set; get; }
        TErrorList Errors { set; get; }
    }
}

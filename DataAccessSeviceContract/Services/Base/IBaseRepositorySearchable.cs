using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessSeviceContract.Services.Base
{
    public interface IBaseRepositorySearchable<TModel,TKey,TSearchModel,TSearchResult>: IBaseRepository<TModel,TKey>
    {
        TSearchResult Search(TSearchModel sm, out int RecordCount);
    }
}

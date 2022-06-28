using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessSeviceContract.Services.Base
{
    public interface IBaseRepository<TModel, TKey>
    {
        OperationResult Delete(TKey Id);
        OperationResult Update(TModel Current);
        OperationResult AddNew(TModel Current);
        TModel Get(TKey Id);
        List<TModel> GetAll();

    }
}

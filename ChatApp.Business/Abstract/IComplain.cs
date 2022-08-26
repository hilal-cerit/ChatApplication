using ChatApp.Common.Result;
using ChatApp.DataLayer.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IComplain
    {
        IResult Add(Complain complain);
        IResult Delete(Complain complain);
        IResult Update(Complain complain);
        IDataResult<List<Complain>> GetAll();


    }
}

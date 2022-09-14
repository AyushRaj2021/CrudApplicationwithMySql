using CrudApplicationwithMySql.RepositoryLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplicationwithMySql.ServiceLayer
{
    public class CrudApplicationSL : ICRudApplicationSL
    {
        public readonly ICrudApplicationRL _crudApplicationRL;

        public CrudApplicationSL(ICrudApplicationRL crudApplicationRL)
        {
            _crudApplicationRL = crudApplicationRL;
        }
    }
}

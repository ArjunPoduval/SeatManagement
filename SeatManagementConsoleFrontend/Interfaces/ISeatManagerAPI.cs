using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsoleFrontend.Interfaces
{
    internal interface ISeatManagerAPI<T> where T : class
    {
        string CreateData(T data);
        List<T> GetData();
        string UpdateDetail(T data);
        void DeleteData(T data);
    }

}

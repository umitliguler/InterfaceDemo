using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    interface IDataBaseOperation
    {
        void Add();
        object Get();
        object Get(int id);
        void Update();
        void Delete();
    }
}

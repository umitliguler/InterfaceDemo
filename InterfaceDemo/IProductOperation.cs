using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    interface IProductOperation<T>
    {
        T AddProduct(T product);
        T GetProduct(int productNo);
    }
}

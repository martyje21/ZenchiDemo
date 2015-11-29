using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zenchi.Domain.ServiceInterfaces
{
    public interface ICacheService
    {
        object Get(string key);
        void Insert(string key, object value, DateTime expiration);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstrarctClass
{
    abstract public  class Entity
    {
        public abstract void Read();
        public abstract void Add();
        public abstract void Delete(int ID);
        public abstract void Create(int ID);
    }
}

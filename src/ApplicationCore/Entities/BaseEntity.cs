using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entities
{
    public abstract class BaseEntity
    {
        // get ve set'i değiştirilebilir yapmak amacıyla virtual yapıldı 
        public virtual int Id { get; set; }
    }
}

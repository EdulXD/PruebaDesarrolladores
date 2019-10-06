using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDEduardo.Models
{
    public interface IUserRepository
    {
        IEnumerable<Elements> GetAll();
        Elements Get(int id);
        Elements Add(Elements usuario);
        void Remove(int id);
        bool Update(Elements usuario);
    }
}

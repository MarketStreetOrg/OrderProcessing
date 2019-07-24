using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderProcessingCore.DAO.Generic
{
    public interface IGenericDAO<T>
    {
        List<T> GetAll();
        T GetByID(int id);
        T GetByName(string name);
        void Save(T model);
        T Update(T Model);
        void Delete(int id);
        void Delete(string param);
        Boolean Exists(T model);
        Task<List<T>> GetAllAsync();
    }
}

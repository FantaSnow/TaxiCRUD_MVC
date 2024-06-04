using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxi_serch.Service
{
    public interface IObjService<T, CreateDto, UpdateDto> where T : class where CreateDto : class where UpdateDto : class
    {
        void SetEndpoint(string endpoint);
        Task<List<T>> GetObjects();
        Task<T> GetObjectById(Guid id);
        Task<T> GetObjectByIdInt(int id);
        Task CreateObject(CreateDto obj);
        Task DeleteObject(Guid id);
        Task DeleteObjectInt(int id);
        Task UpdateObject(UpdateDto obj);
    }
}

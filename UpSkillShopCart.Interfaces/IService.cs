using System;
using System.Threading.Tasks;

namespace UpSkillShopCart.Interfaces
{
    public interface IService
    {
        Task<int> GetCount(int count);
    }
}

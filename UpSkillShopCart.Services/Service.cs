using System;
using System.Threading.Tasks;
using UpSkillShopCart.Interfaces;

namespace UpSkillShopCart.Services
{
    public class Service : IService
    {
        public Service()
        {

        }

        public async Task<int> GetCount(int count)
        {
            return count;
        }
    }
}

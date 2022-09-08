using System.Linq;
using TestApp1.Domain.Entity;

namespace TestApp1.Domain.Repository.Abstract
{
    public interface IUserStatisticRepository
    {
        IQueryable<UserStatistic> GetUserStatistic();
        UserStatistic GetUserStatisticById(int id);
        void SaveUserStatistic(UserStatistic entity);
        void DeleteUserStatistic(int id);
    }
}

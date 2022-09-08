using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestApp1.Domain.Entity;
using TestApp1.Domain.Repository.Abstract;

namespace TestApp1.Domain.Repository.EntityFramework
{
    public class EFUserStatisticRepository : IUserStatisticRepository
    {
        private readonly UserManagmentDbContext context;
        public EFUserStatisticRepository(UserManagmentDbContext context)
        {
            this.context = context;
        }

        public IQueryable<UserStatistic> GetUserStatistic()
        {
            return context.UserStatistic;
        }

        public UserStatistic GetUserStatisticById(int id)
        {
            return context.UserStatistic.FirstOrDefault(x => x.Id == id);
        }

        public void SaveUserStatistic(UserStatistic entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteUserStatistic(int id)
        {
            context.UserStatistic.Remove(new UserStatistic() { Id = id });
            context.SaveChanges();
        }
    }
}

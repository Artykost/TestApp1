using TestApp1.Domain.Repository.Abstract;

namespace TestApp1.Domain
{
    public class DataManager
    {
        public IUserStatisticRepository UserStatistic { get; set; }

        public DataManager(IUserStatisticRepository userStatisticRepository)
        {
            UserStatistic = userStatisticRepository;
        }
    }
}
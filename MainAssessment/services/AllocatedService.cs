using MainAssessment.Interface;
using MainAssessment.Tables;

namespace MainAssessment.services
{
    public class AllocatedService : IAllocatedReportCall
    {

        private readonly IRepository<AllocatedSeat> repository;

        public AllocatedService(IRepository<AllocatedSeat> repository)
        {
            this.repository = repository;
        }
        public IEnumerable<AllocatedSeat> GetAll()
        {

            return repository.GetAll();
        }
    }
}

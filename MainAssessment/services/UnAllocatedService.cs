using MainAssessment.Interface;
using MainAssessment.Tables;

namespace MainAssessment.services
{
    public class UnAllocatedService : IUnAllocatedReportCall
    {
        private readonly IRepository<UnAllocatedSeat> repository;

        public UnAllocatedService(IRepository<UnAllocatedSeat> repository)
        {
            this.repository = repository;
        }
        public IEnumerable<UnAllocatedSeat> GetAll()
        {

            return repository.GetAll();
        }
    }
}

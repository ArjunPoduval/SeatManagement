using MainAssessment.CustomException;
using MainAssessment.DTO;
using MainAssessment.Exceptions;
using MainAssessment.Interface;
using MainAssessment.Tables;

namespace MainAssessment.services
{
    public class DepartmentService : IDepartment
    {
        private readonly IRepository<Department> _departmentRepository;

        public DepartmentService(IRepository<Department> repository)
        {
            this._departmentRepository = repository;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _departmentRepository.GetAll();
        }

        public void AddDepartment(DepartmentCreationDTO newDepartment)
        {
            //Validation
            Department? departmentcreation = _departmentRepository.GetAll().FirstOrDefault(c => c.DepartmentName == newDepartment.departmentName);
            if (departmentcreation != null)
            {
                throw new ObjectAlreadyExistException("Department");
            }
            //Creation
            Department item = new()
            {
                DepartmentName = newDepartment.departmentName
            };
            _departmentRepository.Add(item);
            _departmentRepository.Save();
        }

        public void RemoveDepartment(int DepId)
        {
            //Validation
            Department item = _departmentRepository.GetById(DepId);
            if (item == null)
            {
                throw new ObjectDoNotExist("Department");
            }
            //Removing
            else
            {
                _departmentRepository.Remove(item);
                _departmentRepository.Save();
            }
        }
    }
}

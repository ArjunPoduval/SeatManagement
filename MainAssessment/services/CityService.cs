using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;
using Microsoft.AspNetCore.Mvc;

namespace MainAssessment.services
{
    public class CityService : ICity
    {
        private readonly IRepository<City> repository;

        public CityService(IRepository<City> repository)
        {
            this.repository = repository;
        }

        
        public IEnumerable<City> GetAllCity()
        {

            return repository.GetAll();
        }
        public void AddCity(CityDTO city)
        {
        //Validation

            var cityCreationCheck = repository.GetAll().FirstOrDefault(c => c.CityName == city.City || c.CityAbbreviation==city.Abbreviation);
            if (cityCreationCheck != null)
            {
                throw new Exception("Similar city Name or Abbreviation already exist.");
            }
        //creation
            var item = new City()
            {
                CityAbbreviation = city.Abbreviation,
                CityName = city.City
            };
            repository.Add(item);
            repository.Save();
        }

        public void RemoveCity(int cityid)
        {
        //validation
            var item = repository.GetById(cityid);
            if (item == null)
            {
                throw new Exception("No City Found.");
            }
        //Removing
            else
            {
                repository.Remove(item);
                repository.Save();
            }
        }

    }
}

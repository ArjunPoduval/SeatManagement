using MainAssessment.CustomException;
using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;
using Microsoft.AspNetCore.Mvc;

namespace MainAssessment.services
{
    public class CityService : ICity
    {
        private readonly IRepository<City> _cityRepository;

        public CityService(IRepository<City> repository)
        {
            this._cityRepository = repository;
        }

        
        public IEnumerable<City> GetAllCity()
        {

            return _cityRepository.GetAll();
        }
        public void AddCity(CityDTO city)
        {
        //Validation

            var cityCreationCheck = _cityRepository.GetAll().FirstOrDefault(c => c.CityName == city.City || c.CityAbbreviation==city.Abbreviation);
            if (cityCreationCheck != null)
            {
                throw new ObjectAlreadyExistException();
            }
        //creation
            var item = new City()
            {
                CityAbbreviation = city.Abbreviation,
                CityName = city.City
            };
            _cityRepository.Add(item);
            _cityRepository.Save();
        }

        public void RemoveCity(int cityid)
        {
        //validation
            var item = _cityRepository.GetById(cityid);
            if (item == null)
            {
                throw new Exception("No City Found.");
            }
        //Removing
            else
            {
                _cityRepository.Remove(item);
                _cityRepository.Save();
            }
        }

    }
}

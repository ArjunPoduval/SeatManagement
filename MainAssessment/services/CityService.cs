using MainAssessment.DTO;
using MainAssessment.Interface;
using MainAssessment.Tables;
using Microsoft.AspNetCore.Mvc;

namespace MainAssessment.services
{
    public class CityService : ICity
    {
        private readonly IRepository<CityLookup> repository;

        public CityService(IRepository<CityLookup> repository)
        {
            this.repository = repository;
        }

        
        public IEnumerable<CityLookup> GetAllCity()
        {

            return repository.GetAll();
        }
        public void AddCity(CityLookupDTO city)
        {
        //Validation

            var cityCreationCheck = repository.GetAll().FirstOrDefault(c => c.CityName == city.City || c.CityAbbreviation==city.Abbreviation);
            if (cityCreationCheck != null)
            {
                throw new Exception("Similar city Name or Abbreviation already exist.");
            }
        //creation
            var item = new CityLookup()
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

        public void UpdateCity(string cityName, CityLookupDTO updatedCityData)
        {
        //validation

            var citytoupdate = repository.GetAll().FirstOrDefault(c => c.CityName == cityName);

            if (citytoupdate == null)
            {
                throw new Exception("No City Found.");
            }
            var citytoCheck = repository.GetAll().FirstOrDefault(c => c.CityName == updatedCityData.City && c.CityAbbreviation == updatedCityData.Abbreviation);

            if (citytoCheck!=null)
            {
                throw new Exception("similar data already exist.");
            }
        //Updation

            citytoupdate.CityName = updatedCityData.City;
            citytoupdate.CityAbbreviation = updatedCityData.Abbreviation;

            repository.Update(citytoupdate);
            repository.Save();
        }

    }
}

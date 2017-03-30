using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entrumpelung.Models
{
    public static class CitiesRepository
    {
        private static List<City> _cities = new List<City>();

        static CitiesRepository()
        {
          
            _cities.Add(InitCity("Bremen", "0421", "111 11 111"));
            _cities.Add(InitCity("Frankfurt am Mein", "  69", "222 22 222"));
            _cities.Add(InitCity("Hamburg", "  40", "333 33 333"));
            _cities.Add(InitCity("Hannover", "0511", "444 44 444"));
            _cities.Add(InitCity("Minden", "0571", "829 45 878"));
            _cities.Add(InitCity("Bielefeld", "0521", "666 66 666"));
            _cities.Add(InitCity("Osnabrück", "0541", "777 77 777"));
            _cities.Add(InitCity("Magdeburg", "6421", "888 88 888"));
            _cities.Add(InitCity("Kassel", "0561", "999 99 999"));
        }

        private static City InitCity(string cityName, string cityCode, string cityTel1)
        {
            City city = new City();
            city.CityName = cityName;
            city.CityCode = cityCode;
            city.CityTel1 = cityTel1;
            return city;
        }

        public static string CityCode(string cityName)
        {
           return _cities.FirstOrDefault(c => c.CityName.Equals(cityName))?.CityCode;
        }

        public static string CityTel1(string cityName)
        {
            return _cities.FirstOrDefault(c => c.CityName.Equals(cityName))?.CityTel1;
        }

        public static City GetCity(string cityName)
        {
            return _cities.FirstOrDefault(c => c.CityName.Equals(cityName));
        }
    }
}
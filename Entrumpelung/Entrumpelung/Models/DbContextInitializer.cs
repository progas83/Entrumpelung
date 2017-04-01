using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Entrumpelung.Models
{
    public class DbContextInitializer :  DropCreateDatabaseAlways<InfoContext>// DropCreateDatabaseIfModelChanges<InfoContext> //
    {
        protected override void Seed(InfoContext context)
        {
            //context.Cities.Add(InitCity("Bremen", "421", "111111111"));
            //context.Cities.Add(InitCity("Frankfurt am Mein", "69", "2222222"));
            //context.Cities.Add(InitCity("Hamburg", "40", "33 33 33 33"));
            //context.Cities.Add(InitCity("Hannover", "511", "44444444"));
            //context.Cities.Add(InitCity("Minden", "571", "5555555555"));
            //context.Cities.Add(InitCity("Bielefeld", "521", "666666666"));
            //context.Cities.Add(InitCity("Osnabrück", "541", "777777777"));
            //context.Cities.Add(InitCity("Magdeburg", "6421", "888888888"));
            //context.Cities.Add(InitCity("Kassel", "561", "999999999"));
            //context.SaveChanges();

        }

        //private City InitCity(string cityName, string cityCode, string cityTel1)
        //{
        //    City city = new City();
        //    city.CityName = "";
        //    city.CityCode = "";
        //    city.CityTel1 = "";
        //    return city;
        //}
    }
}
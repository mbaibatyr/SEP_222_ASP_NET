using MyReact2.Model;
using System.Collections;
using System.Collections.Generic;

namespace MyReact2.Abstract
{
    public interface ICity
    {
        IEnumerable<City> GetCityAll(string id);
        string AddOrEdit(City request);
    }
}

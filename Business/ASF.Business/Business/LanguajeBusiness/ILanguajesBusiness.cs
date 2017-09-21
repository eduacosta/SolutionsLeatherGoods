using System.Collections.Generic;
using ASF.Entities;

namespace ASF.Business.Business.LanguajeBusiness
{
    public interface ILanguajesBusiness
    {
        IDictionary<LocaleResourceKey, string> GetLenguajesResourceByLanguaje(Language language);
    }
}
using System.Collections.Generic;
using ASF.Entities;

namespace ASF.Business.Business.LanguajeBusiness
{
    public interface ILocaleStringResourceBusiness
    {
        IList<LocaleStringResource> GetLenguajesResourceByLanguaje();
    }
}
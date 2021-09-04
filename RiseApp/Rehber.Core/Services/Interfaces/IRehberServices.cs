using Rehber.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rehber.Core
{
    public interface IRehberServices
    {
        KisiModel AddKisi(KisiModel kisi);
        void DeleteKisi(Guid UUID);
        KisiModel GetKisi(Guid UUID);
        List<KisiModel> KisiListesi();
        KisiModel AddIletisimBilgisi(KisiModel kisi);
        void DeleteIletisimBilgisi(Guid UUID);
        List<IletisimBilgisiModel> KisilerinIletisimBilgileri();
    }
}

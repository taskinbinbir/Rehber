using Rapor.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapor.Core
{
    public interface IRaporServices
    {
        Task<List<RaporModel>> GetRapors();

        Task<List<RaporIcerikModel>> CreateDetayRapor();

        Task<List<IstatistikselRaporModel>> CreateIstatistikselRapor();
    }
}

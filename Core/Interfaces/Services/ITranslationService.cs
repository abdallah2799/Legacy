using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Services
{
    public interface ITranslationService
    {
        Task<IEnumerable<Translation>> GetByEntityAsync(string entityName, int entityId);
        Task AddTranslationAsync(Translation translation);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.Interfaces
{
    public interface ITokenGenerationService
    {
         string GenerateToken(string username, int expireMinutes = 20);
    }
}

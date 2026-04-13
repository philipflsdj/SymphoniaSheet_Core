using SS.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Domain.Contracts.Services
{
    public interface ITokenService
    {
        string GenerateToken(Usuario usuario);
    }
}

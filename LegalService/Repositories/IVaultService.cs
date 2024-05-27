using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IVaultService
    {
        Task<string> GetSecretAsync(string path);
    }
}
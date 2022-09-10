using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Softplan.Common.Authorization.Abstractions.Services;
using Softplan.Common.Core.Entities;

namespace Softplan.MP.DistribuicaoSegundoGrau.WebApi.Test.Authorization
{
    public class DisabledAuthorizationService : IAuthorizationService
    {
        public async Task Check(params string[] ids)
        {
            //Does nothing
        }

        public async Task<bool> HasAny(params string[] ids)
        {
            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<SimpleId<string>>> GetCurrentPermissions(params string[] ids)
        {
            return await Task.FromResult(ids.Select(x => x.ToSimpleId()));
        }
    }
}
using ApiAntiCorrupcao.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAntiCorrupcao.Domain.Interfaces
{
    public interface IGitHubServices
    {
        public object GetTotalInfo(string name);
        public object CreateNewRepository(string login, string senha, string? token = null);
        public object ListBranchesByProjectName(string userName, string projectName);
        public object CreateWebhookForRepository(string urlWebHook, string userName, string projectName, string token);
        public object GetAllWebhooksByRepository(string userName, string projectName, string token);
        public object UpdateWebhooksByRepository(string token, EditHookDTO editHookDTO);
    }
}

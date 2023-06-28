using Octokit.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAntiCorrupcao.Domain.Dtos
{
    public class EditHookDTO
    {
        public EditHookDTO()
        {
            AddEvents = new List<string>();
            RemoveEvents = new List<string>();
        }

        //public IEnumerable<string> Events { get; set; }
        public IEnumerable<string> AddEvents { get; set; }
        public IEnumerable<string> RemoveEvents { get; set; }
        public bool? Active { get; set; }
        public string UrlWebHook { get; set; }
        public string UserName { get; set; }
        public string ProjectName { get; set; }
        public int HookId { get; set; }
    }
}

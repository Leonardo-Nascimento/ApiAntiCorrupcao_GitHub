﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiAntiCorrupcao.Domain.Entities
{
    public class RepositoryGit
    {
        public int Id { get; set; }
        public string Node_id { get; set; }
        public string Name { get; set; }
        public string Full_name { get; set; }
        public bool Private { get; set; }
        public string Html_url { get; set; }
        public string Description { get; set; }
        public bool Fork { get; set; }
        public string Url { get; set; }
        public string Hooks_url { get; set; }
        public string Subscription_url { get; set; }
        public string Commits_url { get; set; }
        public string Git_commits_url { get; set; }
        public string Comments_url { get; set; }
        public string Issue_comment_url { get; set; }
        public string Downloads_url { get; set; }
        public string Issues_url { get; set; }
        public string Pulls_url { get; set; }
        public string Milestones_url { get; set; }
        public string Notifications_url { get; set; }
        public string Labels_url { get; set; }
        public string Releases_url { get; set; }
        public string Deployments_url { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DateTime Pushed_at { get; set; }
        public string Git_url { get; set; }
        public string Ssh_url { get; set; }
        public string Clone_url { get; set; }
        public string Svn_url { get; set; }
        public object Homepage { get; set; }
        public int Size { get; set; }
        public int Stargazers_count { get; set; }
        public int Watchers_count { get; set; }
        public string Language { get; set; }
        public bool Has_issues { get; set; }
        public bool Has_projects { get; set; }
        public bool Has_downloads { get; set; }
        public bool Has_wiki { get; set; }
        public bool Has_pages { get; set; }
        public bool Has_discussions { get; set; }
        public int Forks_count { get; set; }
        public object Mirror_url { get; set; }
        public bool Archived { get; set; }
        public bool Disabled { get; set; }
        public int Open_issues_count { get; set; }
        public object License { get; set; }
        public bool Allow_forking { get; set; }
        public bool Is_template { get; set; }
        public bool Web_commit_signoff_required { get; set; }        
        public string Visibility { get; set; }
        public int Forks { get; set; }
        public int Open_issues { get; set; }
        public int Watchers { get; set; }
        public string Default_branch { get; set; }
        public Owner Owner { get; set; }
    }
}

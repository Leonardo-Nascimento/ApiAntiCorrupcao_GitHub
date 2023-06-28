using ApiAntiCorrupcao.Domain.Dtos;
using ApiAntiCorrupcao.Domain.Entities;
using ApiAntiCorrupcao.Domain.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Octokit;
using System.Collections;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace ApiAntiCorrupcao.Domain.Services
{
    public class GitHubServices : IGitHubServices
    {
        private GitHubClient githubClient = new GitHubClient(new Octokit.ProductHeaderValue("MyAmazingApp"));


        public object CreateNewRepository(string login, string senha, string? token = null)
        {

            if (token == null)
            {
                var basicAuthCredentials = new Credentials("Leonardo-Nascimento", "*ni76ViQw*gb*S", AuthenticationType.Basic);

                githubClient.Credentials = basicAuthCredentials;
            }
            else
            {
                var basicAuthCredentials = new Credentials(token);
                githubClient.Credentials = basicAuthCredentials;
            }

            try
            {
                var repository = new NewRepository("TESTE LEO BMX 2")
                {
                    AutoInit = false,
                    Description = "Repositorio de teste",
                    LicenseTemplate = "mit",
                    Private = false
                };

                var context = githubClient.Repository.Create(repository);
                var respositoryGitHub = context.Result;
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public object CreateWebhookForRepository(string urlWebHook, string userName, string projectName, string token)
        {
            try
            {
                var options = new List<string> { "create", "delete", "branch_protection_rule", "check_run", "check_suite", "code_scanning_alert", "member", "commit_comment", "dependabot_alert", "deploy_key", "deployment_status", "deployment", "discussion_comment", "discussion", "fork", "issue_comment", "issues", "label", "merge_group", "meta", "milestone", "package", "page_build", "project_card", "project_column", "project", "pull_request_review_comment", "pull_request_review_thread", "pull_request_review", "pull_request", "push", "registry_package", "release", "repository", "repository_advisory", "repository_import", "repository_vulnerability_alert", "security_and_analysis", "status", "team_add", "public", "watch", "workflow_job" };

                var config = new Dictionary<string, string>();
                config.Add("url", urlWebHook);
                config.Add("content_type", "json");
                config.Add("insecure_ssl", "0");

                var basicAuthCredentials = new Credentials(token);
                githubClient.Credentials = basicAuthCredentials;

                var hookConfig = new NewRepositoryHook("web", config)
                {
                    Active = true,
                    Events = options,
                };

                var webhook = githubClient.Repository.Hooks.Create(userName, projectName, hookConfig).Result;
                return new { message = "WebHook criado com sucesso" , data = webhook};
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public object GetAllWebhooksByRepository(string userName, string projectName, string token)
        {
            try
            {
                var basicAuthCredentials = new Credentials(token);
                githubClient.Credentials = basicAuthCredentials;

                
                var webhook = githubClient.Repository.Hooks.GetAll(userName, projectName).Result;
                return webhook;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public object GetTotalInfo(string name)
        {
            var user = (Octokit.User)RequestApiGitHub(name);
            var repos = githubClient.Repository.GetAllForUser(user.Login).Result;
            return repos;
        }

        public object ListBranchesByProjectName(string userName, string projectName)
        {
            var listNameRepositorys = new List<string>();
            var listNameBranches = new List<string>();
            string projectTitle = projectName;
            try
            {
                dynamic allRepositorys = GetTotalInfo(userName);

                if (allRepositorys != null)
                {
                    foreach (var item in allRepositorys)
                        listNameRepositorys.Add((string)item.Name);

                    var nameRepository = listNameRepositorys.Where(x => x == projectName.Trim()).FirstOrDefault();

                    var user = (Octokit.User)RequestApiGitHub(userName);
                    var branchesList = githubClient.Repository.Branch.GetAll(userName, nameRepository).Result;

                    foreach (var item in branchesList)
                        listNameBranches.Add((string)item.Name);

                    return listNameBranches;
                }
                else
                    return new { result = false, content = "Erro: Os repositórios deste usuario não foram encontrados" };
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: Os repositórios deste usuario não foram encontrados");
            }
        }

        public object UpdateWebhooksByRepository(string token, EditHookDTO editHookDTO)
        {
            try
            {               
                var config = new Dictionary<string, string>();
                config.Add("url", editHookDTO.UrlWebHook);
                config.Add("content_type", "json");
                config.Add("insecure_ssl", "0");

                var basicAuthCredentials = new Credentials(token);
                githubClient.Credentials = basicAuthCredentials;

                var hookConfig = new EditRepositoryHook(config)
                {
                    Active = true,
                    AddEvents = editHookDTO.AddEvents,
                    RemoveEvents = editHookDTO.RemoveEvents,
                };

                var webhook = githubClient.Repository.Hooks.Edit(editHookDTO.UserName, editHookDTO.ProjectName, editHookDTO.HookId, hookConfig).Result;
                return new { message = "WebHook atualizado com sucesso", data = webhook };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private object RequestApiGitHub(string userName)
        {
            var user = githubClient.User.Get(userName).Result;
            return user;
        }


    }
}

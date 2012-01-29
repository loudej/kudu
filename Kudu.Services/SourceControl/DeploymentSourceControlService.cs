﻿using System;
using System.ComponentModel;
using System.Json;
using System.ServiceModel;
using System.ServiceModel.Web;
using Kudu.Core.SourceControl;
using Kudu.Core.SourceControl.Hg;

namespace Kudu.Services.SourceControl
{
    [ServiceContract]
    public class DeploymentSourceControlService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IHgServer _server;

        public DeploymentSourceControlService(IRepositoryManager repositoryManager,
                                              IHgServer server)
        {
            _repositoryManager = repositoryManager;
            _server = server;
        }

        [Description("Creates a repository of the specified type.")]
        [WebInvoke(UriTemplate = "create")]
        public void Create(JsonObject input)
        {
            var type = (RepositoryType)Enum.Parse(typeof(RepositoryType), (string)input["type"]);
            _repositoryManager.CreateRepository(type);
        }

        [Description("Deletes a repository.")]
        [WebInvoke(UriTemplate = "delete")]
        public void Delete()
        {
            // Stop the server (will no-op if nothing is running)
            _server.Stop();
            _repositoryManager.Delete();
        }

        [Description("Gets the repository type.")]
        [WebGet(UriTemplate = "kind")]
        public RepositoryType GetRepositoryType()
        {
            return _repositoryManager.GetRepositoryType();
        }

        [Description("Sets the message displayed at the end of a git push operation.")]
        [WebInvoke(UriTemplate = "pushmessage")]
        public void SetPushMessage(JsonObject input)
        {
            _repositoryManager.SetPushMessage((string)input["message"]);
        }
    }
}

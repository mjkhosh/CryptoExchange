﻿using CryptoExchange.Core.RequestResponse.Common;

namespace CryptoExchange.Core.RequestResponse.BaseFramework
{
    public abstract class ApplicationServiceResult : IApplicationServiceResult
    {
        protected readonly List<string> _messages = new List<string>();

        public IEnumerable<string> Messages => _messages;

        public ApplicationServiceStatus Status { get; set; }

        public void AddMessage(string error)
        {
            _messages.Add(error);
        }

        public void AddMessages(IEnumerable<string> errors)
        {
            _messages.AddRange(errors);
        }

        public void ClearMessages()
        {
            _messages.Clear();
        }
    }
}

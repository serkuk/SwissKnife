﻿using System.Collections.Concurrent;

namespace KukSoft.ToolKit.Logger
{
    class LogIntoMultiple : ILogStrategy
    {
        private ConcurrentBag<ILogStrategy> _strategies;

        public LogIntoMultiple(ILogStrategy[] strategies)
        {
            _strategies = new ConcurrentBag<ILogStrategy>(strategies);
        }

        public void Publish(LogMessage message)
        {
            foreach (ILogStrategy log in _strategies)
            {
                log.Publish(message);
            }
        }
    }
}
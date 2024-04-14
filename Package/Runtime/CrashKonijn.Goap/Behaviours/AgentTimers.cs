﻿using CrashKonijn.Goap.Core.Interfaces;

namespace CrashKonijn.Goap.Behaviours
{
    public class AgentTimers : IAgentTimers
    {
        public ITimer Action { get; } = new Timer();
        public ITimer Goal { get; } = new Timer();
        public ITimer Resolve { get; } = new Timer();
    }
}
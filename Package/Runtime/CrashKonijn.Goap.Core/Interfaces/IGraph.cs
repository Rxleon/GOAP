﻿using System.Collections.Generic;

namespace CrashKonijn.Goap.Core.Interfaces
{
    public interface IGraph
    {
        List<INode> RootNodes { get; set; }
        List<INode> ChildNodes { get; set; }
        INode[] AllNodes { get; }
    }
}
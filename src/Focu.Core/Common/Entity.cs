﻿namespace Focu.Core.Common;

public abstract class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
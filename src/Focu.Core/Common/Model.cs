﻿namespace Focu.Core.Common;

public abstract class Model
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
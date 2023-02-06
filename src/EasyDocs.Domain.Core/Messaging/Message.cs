﻿namespace EasyDocs.Domain.Core.Messaging;

public abstract class Message
{
    protected Message()
    {
        MessageType = GetType().Name;
    }

    public Guid AggregateId { get; protected set; }
    public string MessageType { get; protected set; }
}
﻿namespace RabbitMqAirlineApp.WebApi.Services
{
    public interface IMessageProducer
    {
        void SendingMessage<T>(T message);
    }
}

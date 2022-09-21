using EventBus.Base.Events;
using System;
using System.Collections.Generic;

namespace EventBus.Base.Abstraction
{
    public interface IEventBusSubscritionManager
    {
        bool IsEmpty { get; } //Subscriton Manager herhangi bir event'imizin olup olmadığına karar verecek.

        event EventHandler<string> OnEventRemoved; // Remove edildiğinde içerde bi event oluşturacağız.

        void AddSubscription<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>; //Subscription ekleme - Kısıtladık.

        void RemoveSubscription<T, TH>() where TH : IIntegrationEventHandler<T> where T : IntegrationEvent;

        bool HasSubscriptionsForEvent<T>() where T : IntegrationEvent;

        bool HasSubscriptionsForEvent(string eventName);

        Type GetEventTypeByName(string eventName); //Event Name gönderildiğinde tipini geri göndereceğiz. İsminden Event'in kendisine ulaşmış oluyoruz.

        void Clear();

        IEnumerable<SubscriptionInfo> GetHandlersForEvent<T>() where T : IntegrationEvent; //Dışarıdan gönderilen event'in bütün subscriptionlarını ve handlerlarını geri döneceğimiz metot için. 

        IEnumerable<SubscriptionInfo> GetHandlersForEvent(string eventName);

        string GetEventKey<T>(); //Integration event için kullanılan Key- Routing Key gibi düşünebilirsin.

    }
}

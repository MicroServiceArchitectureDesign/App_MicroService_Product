// using System.Text;

// namespace AppMicroServiceProduct.Infrastructure.Services;

// public class EventServiceStore : IEventServiceStore
// {
//     private readonly EventStoreClient _client;

//     public EventServiceStore()
//     {
//         //var connectionString = "esdb://eventstore-db?tls=false";
//         var connectionString =
//             "esdb://admin:admin@127.0.0.1:2113?tls=true&tlsVerifyCert=false&keepAliveTimeout=10000&keepAliveInterval=10000";
//         var settings = EventStoreClientSettings.Create(connectionString);
//         //settings.ConnectivitySettings.Insecure = true; //for docker purposes
//         _client = new EventStoreClient(settings);
//     }

//     public async Task Save<TEvent>(string stream, long expectedVersion, IEnumerable<TEvent> events)
//         where TEvent : IDomainEvent
//     {
//         try
//         {
//             IEnumerable<TEvent> domainEvents = events as TEvent[] ?? Array.Empty<TEvent>();
//             if (!domainEvents.Any()) return;
//             var eventsData = domainEvents.Select(p => CreateSample(p));
//             await _client.AppendToStreamAsync(stream, StreamState.Any, eventsData);
//         }
//         catch (Exception ex)
//         {
//             await Console.Out.WriteLineAsync(ex.Message);
//             throw;
//         }
//     }

//     public async Task<IReadOnlyList<IDomainEvent>> GetAsync(string stream,
//         CancellationToken cancellationToken = default)
//     {
//         try
//         {
//             var result = _client.ReadStreamAsync(Direction.Forwards, stream, StreamPosition.Start,
//                 cancellationToken: cancellationToken);
//             var events = await result.ToListAsync(cancellationToken);
//             var domainEvents = events.Select(p => GetDomainEvent(p.Event.Data.ToArray())).ToList();
//             return domainEvents;
//         }
//         catch (Exception ex)
//         {
//             await Console.Out.WriteLineAsync(ex.Message);
//             throw;
//         }
//     }

//     private static IDomainEvent GetDomainEvent(byte[] data)
//     {
//         var jsonString = Encoding.UTF8.GetString(data);
//         var result = JsonConvert.DeserializeObject(jsonString, _serializerSettings);
//         var domainEvent = result as IDomainEvent;
//         return domainEvent ?? throw new NullException("Invalid domain event");
//     }

//     private static EventData CreateSample(IDomainEvent @event)
//     {
//         var data = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(@event, _serializerSettings));
//         var eventPayload = new EventData(Uuid.NewUuid(), @event.GetType().Name, data);
//         return eventPayload;
//     }


//     private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings()
//     {
//         TypeNameHandling = TypeNameHandling.All, NullValueHandling = NullValueHandling.Ignore,
//     };
// }
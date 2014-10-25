using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Mallaca.Usertypes;

namespace RH_Server.Classes
{
    internal class Notifier
    {
        private static Notifier _instance;

        private readonly ConcurrentDictionary<Specialist, List<Client>> _subscribers =
            new ConcurrentDictionary<Specialist, List<Client>>();

        public static Notifier Instance
        {
            get { return _instance ?? (_instance = new Notifier()); }
        }

        public bool ShouldNotify(Client client)
        {
            return GetListeners(client).Any();
        }

        public bool Subscribe(Specialist specialist, Client client)
        {
            var tuple = GetListBySpecialist(specialist);
            if (tuple == null)
            {
                return _subscribers.TryAdd(specialist, new List<Client>() { client });
            }

            var listOfClients = tuple.Item2;
            if (listOfClients != null){
                // Voeg de extra client toe aan de lijst
                listOfClients.Add(client);
                // Voeg de lijst toe aan de dictionary
                return _subscribers.TryAdd(tuple.Item1, listOfClients);
            }

            var tempClient = new List<Client> {client};
            return _subscribers.TryAdd(specialist, tempClient);
        }

        public bool Unsubscribe(Specialist specialist, Client client)
        {
            var listOfClients = GetListBySpecialist(specialist);
            if (listOfClients == null) return false;

            var s = listOfClients.Item1;
            var list = listOfClients.Item2;
            list.RemoveAll(x => x.Username == client.Username);
            return _subscribers.TryAdd(s, list);
        }

        public bool Unsubscribe(Specialist specialist)
        {
            var resultList = (from s in _subscribers
                where s.Key.Username == specialist.Username
                select s.Key).ToList();

            if (!resultList.Any()) return false;

            List<Client> x;
            return _subscribers.TryRemove(resultList.First(), out x);
        }

        private Tuple<Specialist, List<Client>> GetListBySpecialist(Specialist specialist)
        {
            var resultList = (from s in _subscribers
                where s.Key.Username == specialist.Username
                select s.Key).ToList();

            // Zitten er elementen in het resultaat?
            if (!resultList.Any()) return null;

            var key = resultList.First();
            // Bereid de out-parameter voor.
            List<Client> outClients;
            // Probeer de huidige lijst op te halen, anders: return false;
            return !_subscribers.TryGetValue(key, out outClients) ? null : new Tuple<Specialist, List<Client>>(key, outClients);
        }

        public IEnumerable<Specialist> GetListeners(Client client)
        {
            var listeningSpecialists = 
                from keyValuePair in _subscribers
                from cl in keyValuePair.Value
                where cl.Username == client.Username
                select keyValuePair.Key;

            return listeningSpecialists;
        }

        public IEnumerable<Client> GetListeners(Specialist spec)
        {
            return _subscribers.First(x => x.Key.Username == spec.Username).Value;
        }

        private Notifier()
        {
        } 
    }
}

using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace ProductionReady
{
    public interface IUserNameService
    {
        string GetUserName();
    }

    public class FixedUserNameService : IUserNameService, IDisposable
    {
        private readonly string _userName;

        public FixedUserNameService(string userName)
        {
            _userName = userName;
        }

        public string GetUserName()
        {
            return _userName;
        }

        public void Dispose()
        {
            Debug.Log("Service disposed!");
        }
    }

    public class RandomUserNameService : IUserNameService
    {
        public string GetUserName()
        {
            return "Player " + Random.Range(0, 100);
        }
    }
}
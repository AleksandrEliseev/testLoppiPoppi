using UnityEngine;

namespace Repository
{
    public class PlayerRepository : IRepository
    {
        public void SaveStringValue(string key, string value)
        {
            PlayerPrefs.SetString(key, value);
        }
        public string LoadStringValue(string key, string defaultValue = "")
        {
            return PlayerPrefs.GetString(key, defaultValue);
        }
    }
}
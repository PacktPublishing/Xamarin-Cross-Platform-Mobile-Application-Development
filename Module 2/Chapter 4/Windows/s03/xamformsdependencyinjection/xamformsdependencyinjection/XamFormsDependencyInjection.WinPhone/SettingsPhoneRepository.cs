using System.Collections.Generic;

namespace XamFormsDependencyInjection.WinPhone
{
    public class SettingsPhoneRepository : ISettingsRepository
    {
        Dictionary<string, string> _containerDictionary = new Dictionary<string, string>();

        public void Save(string key, string value)
        {
            if (!_containerDictionary.ContainsKey(key))
            {
                _containerDictionary.Add(key, value);
            }
        }

        public string GetValue(string key)
        {
            string value = string.Empty;
            if (_containerDictionary.TryGetValue(key, out value))
            {
                value = string.Format("{0} - WinPhone", value);
            }

            return value;
        }
    }
}

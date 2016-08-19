using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace XamFormsAddGrouping
{
    public class GroupingObservableCollection<K, T> : ObservableCollection<T>
    {
        public K Key { get; private set; }
        public GroupingObservableCollection(K key, IEnumerable<T> items) : base(items)
        {
            Key = key;
        }
    }
}

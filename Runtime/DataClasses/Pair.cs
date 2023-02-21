namespace StuTools
{
    /// <summary>
    /// Represents a serializable data couplet. 
    /// </summary>
    /// <typeparam name="K">The key data type</typeparam>
    /// <typeparam name="V">The value data type</typeparam>
    [System.Serializable]
    public class Pair<K, V>
    {
        public K key;
        public V value;

        public Pair(K key, V value)
        {
            this.key = key;
            this.value = value;
        }
    }
}
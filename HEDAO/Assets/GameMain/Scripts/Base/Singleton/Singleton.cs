namespace HEDAO
{
    public class Singleton<T>
        where T : new()
    {
        private static T m_Instance = default;
        public static T Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new T();
                }
                return m_Instance;
            }
        }
    }
}
namespace HEDAO.Skill
{
    public abstract class Buff : IBuff
    {
        private int m_Id;
        private object m_Owner;

        public int Id => m_Id;
        public object Owner => m_Owner;

        public Buff(int id)
        {
            m_Id = id;
        }

        public virtual void OnAdd(IBuffTarget owner)
        {
            m_Owner = owner;
        }

        public virtual void OnUpdate()
        {

        }

        public virtual void OnRemove()
        {
            m_Id = 0;
            m_Owner = null;
        }
    }
}
namespace Cfg.Battle
{
    public interface IEffectTarget
    {
        void AddBuff(int id)
        {
            
        }

        void RemoveBuff(int id)
        {
            
        }

        void TakeDamage(int damage)
        {
            
        }
    }
    
    public partial class Effect
    {
        private Effect() {}
        
        public virtual void OnTakeEffect(IEffectTarget target)
        {
            
        }
    }
}
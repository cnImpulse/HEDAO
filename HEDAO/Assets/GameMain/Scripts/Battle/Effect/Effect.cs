namespace HEDAO.Battle
{
    public interface IEffectTarget
    {
        public void AddBuff(int id)
        {
            
        }

        public void RemoveBuff(int id)
        {
            
        }
    }
    
    public class Effect
    {
        public virtual void OnTakeEffect(IEffectTarget target)
        {
            
        }
    }
}
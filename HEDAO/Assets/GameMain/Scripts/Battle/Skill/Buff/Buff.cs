using Cfg;
using Cfg.Battle;

namespace HEDAO.Skill
{
    public class Buff
    {
        public int Id { get; private set; }
        public int Life { get; private set; }
        public IEffectTarget Target { get; private set; }
        public BuffCfg Cfg => GameEntry.Cfg.Tables.TbBuffCfg.Get(Id);
        
        public Buff(int id, IEffectTarget target)
        {
            Id = id;
            Target = target;
        }

        public virtual void OnAdd()
        {
            var cfg = GameEntry.Cfg.Tables.TbBuffCfg.Get(Id);
            Life = cfg.Round;
            
            if (Cfg.CondType == EBuffCondType.Add)
            {
                foreach (var effect in Cfg.Effect)
                {
                    effect.OnTakeEffect(null, Target);
                }
            }
        }

        public virtual void OnRoundStart()
        {
            if (Cfg.CondType == EBuffCondType.RoundStart)
            {
                foreach (var effect in Cfg.Effect)
                {
                    effect.OnTakeEffect(null, Target);
                }
            }

            --Life;
            if (Life <= 0)
            {
                Target.RemoveBuff(Id);
            }
        }

        public virtual void OnRemove()
        {
            if (Cfg.CondType == EBuffCondType.Add)
            {
                foreach (var effect in Cfg.Effect)
                {
                    effect.OnResetEffect(null, Target);
                }
            }
            
            Id = 0;
            Target = null;
        }
    }
}
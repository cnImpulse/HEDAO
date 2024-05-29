using Cfg.Battle;

namespace HEDAO.Skill
{
    public class Buff
    {
        public int Id { get; private set; }
        public int Life { get; private set; }
        public IEffectTarget Target { get; private set; }

        public Buff(int id, IEffectTarget target)
        {
            Id = id;
            Target = target;
        }

        public virtual void OnAdd()
        {
            var cfg = GameEntry.Cfg.Tables.TbBuffCfg.Get(Id);
            Life = cfg.Round;
        }

        public virtual void OnRoundStart()
        {
            var cfg = GameEntry.Cfg.Tables.TbBuffCfg.Get(Id);
            foreach (var effect in cfg.Effect)
            {
                effect.OnTakeEffect(null, Target);
            }

            --Life;
            if (Life <= 0)
            {
                Target.RemoveBuff(Id);
            }
        }

        public virtual void OnRemove()
        {
            Id = 0;
            Target = null;
        }
    }
}
namespace HEDAO.Skill
{
    public interface IBuff
    {
        int Id { get; }

        object Owner { get; }

        void OnAdd(IBuffTarget owner);

        void OnUpdate();

        void OnRemove();
    }
}
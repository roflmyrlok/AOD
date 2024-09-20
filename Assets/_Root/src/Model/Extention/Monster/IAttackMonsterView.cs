namespace Model
{
    public interface IAttackMonsterView : ISkillView
    {
        public void ShowBowAttackPerformed(Character target);
    }
}
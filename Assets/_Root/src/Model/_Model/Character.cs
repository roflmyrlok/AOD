using System;
using System.Collections.Generic;

namespace Model
{
    public abstract class Character
    {
        protected abstract ICharacterView CharacterView { get; }
        public string Name;
        public Stats CharacterStats { get; private set; }
        public List<Skill> Skills;

        public event EventHandler ImDead;

        public Character()
        {
            CharacterStats = new Stats();
            CharacterStats.StatsChanged += (stats) =>
            {
                CharacterView.UpdateStats(stats);
            };
        }

        public abstract void InitViewAndStats(ICharacterView view);
        public abstract void InitSkillsAndSkillViews(List<ISkillView> skillViews);

        public void TakeDamage(float damage, Character performer)
        {
            var adjustedDamage = Math.Max(0, damage - CharacterStats.Defence);
            if (CharacterStats.Health > adjustedDamage)
            {
                CharacterStats.SetHealth(CharacterStats.Health - (int)adjustedDamage);
            }
            else
            {
                CharacterStats.SetHealth(0);
                IsAlive();
            }
        }

        public void DealAttackMultiDamage(float multiplier, Character target)
        {
            target.TakeDamage(CharacterStats.Attack * multiplier, this);
        }

        public void IsAlive()
        {
            if (CharacterStats.Health == 0)
            {
                ImDead?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public abstract class Character<TView> : Character where TView : ICharacterView
    {
        protected TView TypedView { get; private set; }

        protected override ICharacterView CharacterView => TypedView;

        protected Character() : base()
        {
            
        }

        public override void InitViewAndStats(ICharacterView view)
        {
            if (view is not TView typed)
            {
                throw new Exception($"trying to assign {view} to {typeof(TView).Name}");
            }
            TypedView = typed;
        }

        public abstract override void InitSkillsAndSkillViews(List<ISkillView> skillViews);
    }
}

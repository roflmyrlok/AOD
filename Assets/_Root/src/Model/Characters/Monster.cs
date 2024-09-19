namespace Model
{
	public class Monster : Character<IMonsterView>
	{
		public Monster() 
		{
			Name = "Monster";
			//ChangeCurrentHealth(20);
			//ChangeMaxHealth(20);
			Attack = 2;
			Defence = 1;
			Speed = 1;

		}
		
	}
}
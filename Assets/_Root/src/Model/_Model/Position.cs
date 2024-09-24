namespace Model
{
	public class Position
	{
		public int Index { get; set; }
		public bool IsPlayerTeam { get; set; }

		public Position(int index, bool isPlayerTeam)
		{
			Index = index;
			IsPlayerTeam = isPlayerTeam;
		}

		public Position OpposingPosition()
		{
			return new Position(this.Index, !this.IsPlayerTeam);
		}

		public static bool operator ==(Position pos1, Position pos2)
		{
			if (ReferenceEquals(pos1, pos2)) return true;
			if (pos1 is null || pos2 is null) return false;
			return pos1.Index == pos2.Index && pos1.IsPlayerTeam == pos2.IsPlayerTeam;
		}

		public static bool operator !=(Position pos1, Position pos2)
		{
			return !(pos1 == pos2);
		}

		public override bool Equals(object obj)
		{
			if (obj is Position other)
			{
				return this == other;
			}

			return false;
		}

		public override int GetHashCode()
		{
			return (Index, IsPlayerTeam).GetHashCode();
		}
	}
}
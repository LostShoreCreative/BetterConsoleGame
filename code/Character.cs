class Player
{
	static Player character;
	int _strenght;
	int _dexterity;
	int _constitution;

	int _damage;
	int _armorClass;
	int _health;
	int _level;

	private Player(int str, int dex, int con)
	{
		_strenght = str;
		_dexterity = dex;
		_constitution = con;
		_level = 1;

		_health = 10 + 2*con*_level;
		_damage = (int)1 + _strenght;
		_armorClass = 1 + dex;
	}

	public static void MakePlayer(int str, int dex, int con)
	{
		character = new Player(str, dex, con);
	}

	public string[] GetInfo()
	{
		return new string[]{"Character Info", $"Level: {_level}", $"Health: {_health}", $"Damage: {_damage}", $"AC: {_armorClass}", "|--------|", $"Strength: {_strenght}", $"Dexterity: {_dexterity}", $"Constitution: {_constitution}"};
	}

	public static Player GetCharacter()
	{
		return character;
	}
}
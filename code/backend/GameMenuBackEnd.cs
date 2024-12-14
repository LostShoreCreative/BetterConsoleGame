class GameMenuBackEnd : BackEnd
{
	readonly string[] DATA = {"World", "Inventory", "Shop", "Level Up", "Save", "Quit"};
	ScreenData[] _screenData;
	int _selectedScreen;
  public GameMenuBackEnd()
	{
		_screenData = new ScreenData[15];
		_selectedScreen = 0;
		MakeScreenData();
	}

  public override void HandleInput(ConsoleKeyInfo cki)
  {
		switch(cki.Key)
		{
			case ConsoleKey.UpArrow:
			HandleUpArrow();
			break;
			case ConsoleKey.DownArrow:
			HandleDownArrow();
			break;
			case ConsoleKey.Enter:
			HandleEnter();
			break;
		}
		MakeScreenData();
  }

  protected override void HandleEnter()
  {
		switch(_selectedScreen)
		{
			case 0:
			break;
			case 1:
			break;
			case 2:
			break;
			case 3:
			break;
			case 4:
			break;
			case 5:
			Program.Stop();
			break;
		}
  }

	private void HandleUpArrow()
	{
		if(_selectedScreen == 0) _selectedScreen = 5;
		else _selectedScreen--;
	}

	private void HandleDownArrow()
	{
		if(_selectedScreen == 5) _selectedScreen = 0;
		else _selectedScreen++;
	}

  protected override void MakeScreenData()
  {
		for(int i = 0; i < DATA.Length; i++)
		{
			string text = DATA[i];
			if(_selectedScreen == i) text = $"*>{text}";
			_screenData[i] = new ScreenData(text.ToCharArray(), i+1, 1);
		}
		string[] characterData = Player.GetCharacter().GetInfo();
		for(int i = 0; i < characterData.Length; i++)
		{
			string text = characterData[i];
			_screenData[i+6] = new ScreenData(text.ToCharArray(), i+1, 20);
		}
		InvokeOnUX(this, _screenData);
  }

}
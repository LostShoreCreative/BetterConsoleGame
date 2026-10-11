class NewCharacterBackEnd : BackEnd
{
  readonly string[] DATA = {"Skill Points: ", "Strength: ", "Dexterity: ", "Constitutition: ", "Finish"};
  private ScreenData[] _screenData;
  int _strenght = 1;
  int _dexterity = 1;
  int _constitution = 1;

  int _selectedSkill = 0;
  int _skillPoints = 9;
  bool _allowMakeScreenData = true;

  public NewCharacterBackEnd()
  {
    _screenData = new ScreenData[5];
    MakeScreenData();
  }
  public override void HandleInput(ConsoleKeyInfo cki)
  {
		switch(cki.Key)
    {
      case ConsoleKey.LeftArrow:
      HandleLeftArrow();
      break;
      case ConsoleKey.RightArrow:
      HandleRightArrow();
      break;
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
    if (_allowMakeScreenData) MakeScreenData();
  }

  private void HandleLeftArrow()
  {
    switch(_selectedSkill)
    {
      case 0:
      _strenght = LowerSkillValue(_strenght);
      break;
      case 1:
      _dexterity = LowerSkillValue(_dexterity);
      break;
      case 2:
      _constitution = LowerSkillValue(_constitution);
      break;
    }
  }

  private int LowerSkillValue(int skill)
  {
    if(skill == 1) return skill;
    _skillPoints++;
    return skill-1;
  }

  private void HandleRightArrow()
  {
    if(_skillPoints == 0) return;
    switch(_selectedSkill)
    {
      case 0:
      _strenght++;
      break;
      case 1:
      _dexterity++;
      break;
      case 2:
      _constitution++;
      break;
      default:
      return;
    }
    _skillPoints--;
  }

  private void HandleUpArrow()
  {
    if(_selectedSkill == 0) _selectedSkill = 3;
    else _selectedSkill--;
  }

  private void HandleDownArrow()
  {
    if(_selectedSkill == 3) _selectedSkill = 0;
    else _selectedSkill++;
  }

  protected override void HandleEnter()
  {
    if(_selectedSkill == 3 && _skillPoints == 0)
    {
      Player.MakePlayer(_strenght, _dexterity, _constitution);
      Program.ChangeBackEnd(new GameMenuBackEnd());
      _allowMakeScreenData = false;
    }
  }

  protected override void MakeScreenData()
  {
    int[] values = {_skillPoints, _strenght, _dexterity, _constitution};

    for(int i = 0; i < _screenData.Length; i++)
    {
      string text = DATA[i];
      if(i != 4) text = $"{text}{values[i]}";
      if(i != 0 && i != 4) text = $"<-{text}->";
      if(i-1 == _selectedSkill) text = $"**{text}";
      _screenData[i] = new ScreenData(text.ToCharArray(), WindowManager.GetHeight()/2-2+i, WindowManager.CenterText(text));
    }
    BackEnd.InvokeOnUX(this, _screenData);
  }
}
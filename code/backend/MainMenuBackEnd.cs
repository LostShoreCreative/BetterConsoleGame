
class MainMenuBackEnd : BackEnd
{
  readonly string[] DATA = {"Continue", "New Game", "Load Game", "Quit"};
  ScreenData[] _screenData;
  int _selectedData;

  public MainMenuBackEnd()
  {
    _selectedData = 0;
    _screenData = new ScreenData[4];
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
    switch(_selectedData)
    {
      case 0:
      break;
      case 1:
      break;
      case 2:
      break;
      case 3:
      Program.Stop();
      break;
    }
  }

  private void HandleUpArrow()
  {
    if(_selectedData == 0) _selectedData = 3;
    else _selectedData--;
  }

  private void HandleDownArrow()
  {
    if(_selectedData == 3) _selectedData = 0;
    else _selectedData++;
  }

  private void MakeScreenData()
  {
    int dataHeight = WindowManager.GetHeight()/2-2;
    for(int index = 0; index < _screenData.Length; index++)
    {
      string data = DATA[index];
      if(index == _selectedData)
      {
        _screenData[index] = new ScreenData($"|>{data}<|".ToCharArray(), dataHeight+index, WindowManager.CenterText(data+"1234"));
      }
      else
      {
        _screenData[index] = new ScreenData(data.ToCharArray(), dataHeight+index, WindowManager.CenterText(data));
      }
    }
    InvokeOnUX(this, _screenData);
  }
}
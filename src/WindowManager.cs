using System.Text;

static class WindowManager
{
  static int _height = Console.WindowHeight-1;
  static int _width = Console.WindowWidth;

  static char[][] _window = new char[_height][];
  static ScreenData[] _dataList;
  static StringBuilder _rowBuilder = new StringBuilder(_width);

  private static void Render()
  {
    Console.Clear();
    foreach(char[] row in _window)
    {
      _rowBuilder.Clear();
      foreach(char pixel in row)
      {
        if(pixel == 0) _rowBuilder.Append(" ");
        else _rowBuilder.Append(pixel);
      }
      Console.WriteLine(_rowBuilder);
    }
  }

  static WindowManager()
  {
    SetScreenSize();
    BuildBorder();
    _dataList = new ScreenData[]{ScreenData.Empty, ScreenData.Empty};
    BackEnd.OnUX += BackEnd_OnUX;
  }

  private static void BuildBorder()
  {
    int arrayHeight = _height-1;
    int arrayWidth = _width-1;
    FillRow('_', 0, 1, arrayWidth);
    FillColumn('|', 0, 1, _height);
    FillColumn('|', arrayWidth, 1, _height);
    FillRow('_', arrayHeight, 1, arrayWidth);
  }

  public static void BuildScreen()
  {
    ClearWindow();
    foreach(ScreenData screenData in _dataList)
    {
      for(int index = 0; index < screenData.data.Length; index++)
      {
        _window[screenData.row][screenData.column + index] = screenData.data[index];
      }
    }
    Render();
  }
  private static void FillRow(char value, int row, int start, int end)
  {
    for(;start < end; start++)
    {
      _window[row][start] = value;
    }
  }

  private static void FillColumn(char value, int column, int start, int end)
  {
    for(;start < end; start++)
    {
      _window[start][column] = value;
    }
  }

  private static void ClearWindow()
  {
    for(int row = 1; row < _height-1; row++)
    {
      FillRow(new char(), row, 1, _width-1);
    }
  }

  private static void SetScreenSize()
  {
    _window = new char[_height][];
    for(int index = 0; index < _window.Length; index++)
    {
      _window[index] = new char[_width];
    }
  }

  public static int GetHeight()
  {
    return _height;
  }

  public static int GetWidth()
  {
    return _width;
  }

  public static int CenterText(string text)
  {
    return _width/2 - text.Length/2;
  }

  private static void BackEnd_OnUX(object sender, ScreenData[] data)
  {
    _dataList = data;
  }
}
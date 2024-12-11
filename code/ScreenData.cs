//Since the variables here are public I feel it doesn't make sense to do _camelCase
struct ScreenData
{
  public static readonly ScreenData Empty = new ScreenData(new char[]{' ', ' '}, 1, 1);
  public readonly int row;
  public readonly int column;
  public readonly char[] data;

  public ScreenData(char[] data, int row, int column)
  {
    this.data = data;
    this.row = row;
    this.column = column;
  }
}
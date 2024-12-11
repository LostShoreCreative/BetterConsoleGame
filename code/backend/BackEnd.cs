using System.Reflection.Metadata;

abstract class BackEnd
{
  public static event EventHandler<ScreenData[]> OnUX; //As it is in essence a function it should be in PascalCase
  protected static void InvokeOnUX(object sender, ScreenData[] data)
  {
    OnUX?.Invoke(sender, data);
  }
  public abstract void HandleInput(ConsoleKeyInfo cki);
  protected abstract void HandleEnter();

  protected abstract void MakeScreenData();
}
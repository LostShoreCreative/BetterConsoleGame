class Program
{
  static bool isRunning = true;
  static BackEnd bk = new MainMenuBackEnd();
  public static void Main(string[] args)
  {
    AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
    {
	    Debug.Log(eventArgs.Exception.ToString(), "Errors.txt");
    };
    Thread inputThread = new Thread(new ThreadStart(HandleInput));
    inputThread.Start();
    while(isRunning)
    {
      WindowManager.BuildScreen();
      Thread.Sleep(30);
    }
  }

  static void HandleInput()
  {
    ConsoleKeyInfo cki;
    while(isRunning)
    {
      cki = Console.ReadKey(true);
      bk.HandleInput(cki);
    }
  }
  public static void Stop()
  {
    isRunning = false;
  }

  public static void ChangeBackEnd(BackEnd backEnd)
  {
    bk = backEnd;
  }
}
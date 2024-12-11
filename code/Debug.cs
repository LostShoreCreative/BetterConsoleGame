class Debug
{
  public static void Log(string data, string fileName)
  {
    File.AppendAllText(fileName, $"[{DateTime.Now}] {data}\n");
  }
}
class Debug
{
  static string _path = "..\\..\\..\\logs\\";

  public static void Log(string data, string fileName)
  {
    File.AppendAllText(_path + fileName, $"[{DateTime.Now}] {data}\n");
  }
}
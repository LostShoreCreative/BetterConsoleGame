class Debug
{
  static string path = "./logs/";

  public static void Log(string data, string fileName)
  {
    File.AppendAllText(path + fileName, $"[{DateTime.Now}] {data}");
  }
}
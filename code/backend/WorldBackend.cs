
class WorldBackEnd : BackEnd
{
    int groundHeight;
    public WorldBackEnd()
    {
        groundHeight = WindowManager.GetHeight()-6;
        
    }

    public override void HandleInput(ConsoleKeyInfo cki)
    {
        throw new NotImplementedException();
    }

    protected override void HandleEnter()
    {
        throw new NotImplementedException();
    }

    protected override void MakeScreenData()
    {
        throw new NotImplementedException();
    }
}
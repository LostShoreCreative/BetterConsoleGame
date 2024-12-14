class WorldEntity
{
    char[][] _entityData;
    private WorldEntity(string[] data)
    {
        _entityData = new char[data.Length][];
        for(int i = 0; i < _entityData.Length; i++)
        {
            _entityData[i] = data[i].ToCharArray();
        }
    }

    public char[] GetColumn(int index)
    {
        char[] column = new char[_entityData.Length];
        for(int i = 0; i < column.Length; i++)
        {
            column[i] = _entityData[i][index];
        }
        return column;
    }
    public static readonly WorldEntity SIMPLE_TREE = new WorldEntity(
        new string[]{
            "    /\\    ",    
            "   /**\\   ",   
            "  /****\\  ",
            " /******\\ ",
            "/********\\",
            "    ||    " 
        }
    );

    public static readonly WorldEntity DUAL_MOUNTAIN = new WorldEntity(
        new string[]{
            "            _                  ",
            "           /+\\                 ",
            "          /+++\\                ",
            "         /+++++\\    /\\         ",
            "        /+++++++\\  /++\\        ",
            "       /+++++++++\\/++++\\       ",
            "      /++++++++++/++++++\\      ",
            "     /++++++++++/++++++++\\     ",
            "    /++++++++++/++++++++++\\    ",
            "   /++++++++++/++++++++++++\\   ",
            "  /++++++++++/++++++++++++++\\  ",
            " /++++++++++/++++++++++++++++\\ ",
            "/++++++++++/++++++++++++++++++\\"
        }
    );
}

struct WorldObject
{
    public readonly int POS_X;
    public readonly int POS_Y;
    public readonly WorldEntity ENTITY;

    public WorldObject(WorldEntity entity, int x, int y)
    {
        POS_X = x;
        POS_Y = y;
        ENTITY = entity;
    }
}

/*
      /\    
     /**\   
    /****\  
   /******\ 
  /********\
      ||    
*/



/*
"            _                  ",
"           /+\\                 ",
"          /+++\\                ",
"         /+++++\\    /\\         ",
"        /+++++++\\  /++\\        ",
"       /+++++++++\\/++++\\       ",
"      /++++++++++/++++++\\      ",
"     /++++++++++/++++++++\\     ",
"    /++++++++++/++++++++++\\    ",
"   /++++++++++/++++++++++++\\   ",
"  /++++++++++/++++++++++++++\\  ",
" /++++++++++/++++++++++++++++\\ ",
"/++++++++++/++++++++++++++++++\\"
*/
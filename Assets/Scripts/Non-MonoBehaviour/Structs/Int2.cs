[System.Serializable]
public struct Int2
{
    public int x;
    public int y;

    public static readonly Int2 up = new Int2(0,1);
    public static readonly Int2 down = new Int2(0,-1); 
    public static readonly Int2 right = new Int2(1,0); 
    public static readonly Int2 left = new Int2(-1,0);
    public static readonly Int2 zero = new Int2(0,0);
    public static readonly Int2 one = new Int2(1,1);


    public Int2(int xv, int yv)
    {
        x = xv;
        y = yv;
    }

    public bool Equals(Int2 p)
    {
        // If parameter is null return false:
        if ((object)p == null)
        {
            return false;
        }
        // Return true if the fields match:
        return (x == p.x) && (y == p.y);
    }

    public static bool operator ==(Int2 first, Int2 second)
    {
        return first.x == second.x && first.y == second.y;
    }

    public static bool operator !=(Int2 first, Int2 second)
    {
        return first.x != second.x || first.y != second.y;
    }

    public static Int2 operator +(Int2 first, Int2 second)
    {
        return new Int2(first.x + second.x, first.y + second.y);
    }

    public static Int2 operator -(Int2 first, Int2 second)
    {
        return new Int2(first.x - second.x, first.y - second.y);
    }

    public static Int2 operator *(Int2 first, Int2 second)
    {
        return new Int2(first.x * second.x, first.y * second.y);
    }

    public static Int2 operator /(Int2 first, Int2 second)
    {
        return new Int2(first.x / second.x, first.y / second.y);
    }

    public override string ToString()
    {
        return "(" + x + "," + y + ")";
    }
}

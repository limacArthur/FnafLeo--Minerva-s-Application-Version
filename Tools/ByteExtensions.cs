using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


public static class ByteExtensions
{
    
    public static byte ChangeByte(this byte b, int position, bool newValue)
    {
        if (position < 0 || position > 7)
        {
            if (newValue)
            {
                return (byte)(b | (1 << position));
            }
            else
            {
                return (byte)(b & ~(1 << position));
            }
        } else
        {
            return b;
        }
    }
}

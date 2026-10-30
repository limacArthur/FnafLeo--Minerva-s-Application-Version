using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FNAFLEOv2.Scripts.Abstractions
{
    public class Room
    {
        public Room[] conections;
        public int id;
        public int distanceFactor;
        public string name;
        public byte positions;

        public Room(int id, string name, int distanceFactor)
        {
            id = this.id;
            name = this.name;
            distanceFactor = this.distanceFactor;
        }
        
        public void changePosition(int index, bool value)
        {
            positions = ByteExtensions.ChangeByte(positions, index, value);
        }
    }

    // 1 - Cachorro
    // 2 - Coelha
    // 3 - Cabra
    // 4 - Boi
    // 5 - Bode
    // 6 - Porco
    // 7 - Harry
    // 8 - Wraith
}

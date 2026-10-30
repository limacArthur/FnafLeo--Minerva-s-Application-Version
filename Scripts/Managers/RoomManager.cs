using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Godot;
using FNAFLEOv2.Scripts.Abstractions;
using System.Diagnostics;

namespace FNAFLEOv2.Scripts.Managers
{
    public partial class RoomManager : Node
    {
        [Export] public int Night;
        [Export] public float abbreviationFactor;

        Stopwatch time = new();

        #region RoomsDeclaration
        public Room Office = new(0, "Office", 1);
        public Room BlindLeft = new(1, "BlindLeft", 2);
        public Room BlindRight = new(2, "BlindRight", 2);
        public Room C1 = new(3, "C1", 3);
        public Room C2 = new(4, "C2", 3);
        public Room PartyHall = new(5, "PartyHall", 4);
        public Room MainStage = new(6, "MainStage", 5);
        public Room BackStage = new(7, "BackStage", 6);
        public Room RadiantBarn = new(8, "RadiantBarn", 6);
        public Room Kitchen = new(9, "Kitchen", 5);
        public Room CC = new(10, "Corridor C", 6);
        public Room DressingRoom = new(11, "DressingRoom", 7);
        public Room RepairRoom = new(12, "RepairRoom", 7);
        public Room Bathrooms = new(13, "Bathrooms", 7);
        public Room ADM = new(14, "Administration", 7);

        #endregion
        public override void _Ready()
        {
            Conect();
            time.Start();
            abbreviationFactor = Night / Mathf.Sqrt(Night);
        }

        void Conect()
        {
            Office.conections = new Room[] { BlindLeft, BlindRight };
            BlindRight.conections = new Room[] { C2 };
            BlindLeft.conections = new Room[] { C1 };
            C1.conections = new Room[] { Office, MainStage };
            C2.conections = new Room[] { Office, MainStage };
            MainStage.conections = new Room[] { C1, C2 , PartyHall, Kitchen, RadiantBarn, BackStage, CC};
            Kitchen.conections = new Room[] { MainStage };
            RadiantBarn.conections = new Room[] { MainStage };
            DressingRoom.conections = new Room[] { BackStage };
            BackStage.conections = new Room[] { DressingRoom, MainStage };
            CC.conections = new Room[] { MainStage, RepairRoom, ADM };
            ADM.conections = new Room[] { CC };
            RepairRoom.conections = new Room[] { CC };
            Bathrooms.conections = new Room[] { CC };
            PartyHall.conections = new Room[] { MainStage };
        }
    }



}

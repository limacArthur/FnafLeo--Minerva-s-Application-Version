using FNAFLEOv2.Scripts.Managers;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FNAFLEOv2.Scripts.Abstractions
{
    public partial class Animatronic : Node
    {
        public Room start;
        public Room currentRoom;
        Random random = new Random();

        public float defaultSpeed;
        public float speed;
        public float speedFactor;
        public float nextTry;
        public float difficulty;
        [Export] public int id;

        public int night;

        public float abbreviationFactor;
        
        public Animatronic(Room start, float defaultSpeed, float difficulty)
        {
            this.start = start;
            this.currentRoom = start;
            this.defaultSpeed = defaultSpeed;
            this.difficulty = difficulty;
        }


        public override void _Ready()
        {
            if (GetNode("../") is RoomManager)
            {
                GD.Print("Room manager working.");
            } else
            {
                throw new Exception("Room manager not found.");
            }

            speed = defaultSpeed;
            speedFactor = 1f;
            night = GetNode<RoomManager>("../RoomManager").Night;
            abbreviationFactor = GetNode<RoomManager>("../RoomManager").abbreviationFactor;
        }

        public void Move()
        {
            
            if (random.Next(0, 100) <= difficulty)
            {
                currentRoom.positions = ByteExtensions.ChangeByte(currentRoom.positions, id, false);

                if (random.Next(0,100) <= 45f)
                {
                    Room preference;
                    int anId = 100;
                    foreach (Room room in currentRoom.conections)
                    {
                        if (anId < room.id)
                        {
                            anId = room.id;
                        }
                    }

                    foreach (Room room in currentRoom.conections)
                    {
                        if (room.id == anId)
                        {
                            preference = room;
                            currentRoom = preference;
                            break;
                        }
                    }
                    
                    currentRoom.positions = ByteExtensions.ChangeByte(currentRoom.positions, id, true);
                } 
                else
                {
                    Room next = currentRoom.conections[random.Next(0, currentRoom.conections.Length)];
                    
                    foreach (Room room in currentRoom.conections)
                    {
                        if (room.id == next.id)
                        {
                            currentRoom = room;
                            break;
                        }
                    }

                    currentRoom.positions = ByteExtensions.ChangeByte(currentRoom.positions, id, true);
                }
                
            }
            
        }

        public void Start()
        {

        }

        
    }


}

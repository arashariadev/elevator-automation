using Elevator_Automation.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_Automation.Logic
{
    public class Elevator
    {
        private bool[] floorReady;
        public int CurrentFloor = 1;
        private int topFloor;
        public ElevatorStatus Status = ElevatorStatus.STOPPED;

        public Elevator(int numberOfFloors = 10)
        {
            floorReady = new bool[numberOfFloors + 1];
            topFloor = numberOfFloors;
        }

        private void Stop(int floor)
        {
            Status = ElevatorStatus.STOPPED;
            CurrentFloor = floor;
            floorReady[floor] = false;
            Console.WriteLine("Stopped at floor {0}", floor);
        }

        private void Descend(int floor)
        {
            for (int i = CurrentFloor; i >= 1; i--)
            {
                if (floorReady[i])
                {
                    Stop(floor);
                }
                else
                {
                    continue;
                }
            }

            Status = ElevatorStatus.STOPPED;
            Console.WriteLine("Waiting..");
        }

        private void Ascend(int floor)
        {
            for (int i = CurrentFloor; i <= topFloor; i++)
            {
                if (floorReady[i])
                {
                    Stop(floor);
                }
                else
                {
                    continue;
                }
            }

            Status = ElevatorStatus.STOPPED;
            Console.WriteLine("Waiting..");
        }

        void StayPut()
        {
            Console.WriteLine("That's our current floor");
        }

        public void FloorPress(int floor)
        {
            if (floor > topFloor)
            {
                Console.WriteLine("We only have {0} floors", topFloor);
                return;
            }

            floorReady[floor] = true;

            switch (Status)
            {
                case ElevatorStatus.DOWN:
                    Descend(floor);
                    break;

                case ElevatorStatus.STOPPED:
                    if (CurrentFloor < floor)
                    {
                        Ascend(floor);
                    }
                    else if (CurrentFloor == floor)
                    {
                        StayPut();
                    }
                    else
                    {
                        Descend(floor);
                    }
                    break;

                case ElevatorStatus.UP:
                    Ascend(floor);
                    break;

                default:
                    break;
            }
        }

        public enum ElevatorStatus
        {
            UP,
            STOPPED,
            DOWN
        }
    }
}

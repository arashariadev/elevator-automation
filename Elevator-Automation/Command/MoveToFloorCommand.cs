using Elevator_Automation.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_Automation.Command
{
    public class MoveToFloorCommand : ICommand
    {
        public int TargetFloor { get; private set; }

        public MoveToFloorCommand(int floor)
        {
            TargetFloor = floor;
        }

        public void Execute(Elevator elevator)
        {
            throw new NotImplementedException();
        }
    }
}

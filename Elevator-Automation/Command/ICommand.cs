using Elevator_Automation.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevator_Automation.Command
{
    public interface ICommand
    {
        void Execute(Elevator elevator);
    }
}



public interface ICommand
{
    void Execute(Elevator elevator);
}



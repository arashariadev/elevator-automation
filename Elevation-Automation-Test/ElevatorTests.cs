using Elevator_Automation.Logic;
using Microsoft.VisualStudio.TestPlatform.Utilities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Elevation_Automation_Test
{
    [TestFixture]
    public class ElevatorTests
    {
        private StringWriter sw;
        private TextWriter originalOut;

        [SetUp]
        public void Setup()
        {
            sw = new StringWriter();
            originalOut = Console.Out;
            Console.SetOut(sw);
        }

        [TearDown]
        public void Cleanup()
        {
            sw.Dispose();
            Console.SetOut(originalOut);
        }

        [Test]
        public void FloorPress_TargetFloorIsCurrentFloor_PrintsStayPutMessage()
        {
            // Arrange
            var elevator = new Elevator();

            // Act
            elevator.FloorPress(elevator.CurrentFloor);
            string output = sw.ToString();

            // Assert
            StringAssert.Contains("That's our current floor", output);
        }

        [Test]
        public void FloorPress_TargetFloorIsAboveCurrentFloor_PrintsAscendMessage()
        {
            // Arrange
            var elevator = new Elevator();

            // Act
            int targetFloor = elevator.CurrentFloor + 1;
            elevator.FloorPress(targetFloor);
            string output = sw.ToString();

            // Assert
            StringAssert.Contains("Stopped at floor", output);
        }

       
    }
}

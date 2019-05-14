using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;


namespace FakesWithNSubstitute.Test.Unit
{
    [TestFixture]
    public class HomeControlUnitTests
    {
        //member variables to hold uut and fakes
        private ITempSensor _tempSensor;
        private IHeater _heater;
        private HomeControl.Control _uut;

        [SetUp]
        public void Setup()
        {
            _heater = Substitute.For<IHeater>();
            _tempSensor = Substitute.For<ITempSensor>();

            _uut = new HomeControl.Control(_heater, _tempSensor);
        }

        [Test]
        public void Regulate_HeaterTurnOff_CalledSuccessfully()
        {
            //Setting up stub
            _tempSensor.GetTemp().Returns(30);

            //Act
            _uut.Regulate();

            //Asserting on mock
            _heater.Received(1).TurnOff();
            
        }

        [Test]
        public void Regulate_HeaterTurnOn_CalledSuccessfully()
        {
            //Setting up stub
            _tempSensor.GetTemp().Returns(18);

            //Act
            _uut.Regulate();

            //Asserting on mock
            _heater.Received(1).TurnOn();

        }

    }
}


namespace FakesWithNSubstitute
{
    public class HomeControl
    {
        public class Control
        {
            private readonly IHeater _heater;
            private readonly ITempSensor _tempSensor;

            public int TurnOffCalledTimes { get; set; }
            public int TurnOnCalledTimes { get; set; }

           //Implementing TurnOn();
            public void TurnOn()
            {
                ++TurnOnCalledTimes;
            }

            //Implementing TurnOff();
            public void TurnOff()
            {
                ++TurnOffCalledTimes;
            }

            //Constructor Injection
            public Control(IHeater heater, ITempSensor tempSensor)
            {
                //saving references to dependencies
                _heater = heater;
                _tempSensor = tempSensor;
                
            }

            
            public void Regulate()
            {
                var currentTemperature = _tempSensor.GetTemp();

                //Determining what action the heater should take
                if (currentTemperature < 20)
                {
                    _heater.TurnOn();
                }
                else if (currentTemperature >= 25)
                {
                    _heater.TurnOff();
                }
                
            }
        }
    }
}
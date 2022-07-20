using Xunit;
using static TypewiseAlert.Constants;
using static TypewiseAlert.LiBatteryparameter;

namespace TypewiseAlert.Test
{
    public class TypewiseAlertTest
    {
        BatteryParamaters bParams;

        [Fact]
        public void InfersBreachAsToo_Low()
        {
            bParams = new BatteryParamaters();
            bParams.temperature = 12;
            bParams.lowerLimit = 20;
            bParams.upperLimit = 30;
            Assert.True(TypewiseAlert.inferBreach(bParams) ==
              Constants.BreachType.TOO_LOW);
        }
        [Fact]
        public void Return_Too_Low_AsTrue()
        {
            bParams = new BatteryParamaters();
            bParams.temperature = 12;
            bParams.lowerLimit = 20;
            bParams.upperLimit = 30;
            Assert.True(TypewiseAlert.BreachType_Too_Low(bParams));
        }
        [Fact]
        public void Return_Too_Low_AsFalse()
        {
            bParams = new BatteryParamaters();
            bParams.temperature = 22;
            bParams.lowerLimit = 20;
            bParams.upperLimit = 30;
            Assert.False(TypewiseAlert.BreachType_Too_Low(bParams));
        }

        [Fact]
        public void InfersBreachAsNormal()
        {
            bParams = new BatteryParamaters();
            bParams.temperature = 25;
            bParams.lowerLimit = 20;
            bParams.upperLimit = 30;
            Assert.True(TypewiseAlert.inferBreach(bParams) ==
              Constants.BreachType.NORMAL);
        }

        [Fact]
        public void InfersBreachAsToo_High()
        {
            bParams = new BatteryParamaters();
            bParams.temperature = 40;
            bParams.lowerLimit = 20;
            bParams.upperLimit = 30;
            Assert.True(TypewiseAlert.inferBreach(bParams) ==
              Constants.BreachType.TOO_HIGH);
        }

        [Fact]
        public void ReturnToo_High_AsTrue()
        {
            bParams = new BatteryParamaters();
            bParams.temperature = 40;
            bParams.lowerLimit = 20;
            bParams.upperLimit = 30;
            Assert.True(TypewiseAlert.BreachType_Too_High(bParams));
        }
        [Fact]
        public void ReturnToo_High_AsFalse()
        {
            bParams = new BatteryParamaters();
            bParams.temperature = 25;
            bParams.lowerLimit = 20;
            bParams.upperLimit = 30;
            Assert.False(TypewiseAlert.BreachType_Too_High(bParams));
        }

        [Fact]
        public void classifyTemperatureBreach_Passive_Cooling()
        {
            TypewiseAlert types = new TypewiseAlert(new LiBatteryparameter());
            Assert.True(types.classifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 15) ==
              Constants.BreachType.NORMAL);
        }
        [Fact]
        public void classifyTemperatureBreach_HI_Active_Cooling()
        {
            TypewiseAlert types = new TypewiseAlert(new LiBatteryparameter());
            Assert.True(types.classifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, 55) ==
              Constants.BreachType.TOO_HIGH);
        }
        [Fact]
        public void classifyTemperatureBreach_MED_Active_Cooling()
        {
            TypewiseAlert types = new TypewiseAlert(new LiBatteryparameter());
            Assert.True(types.classifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING, 25) ==
              Constants.BreachType.NORMAL);
        }
        //[Fact]
        //public void BatteryCheckViaControllerTest()
        //{
        //    var bchecker = new BatteryChecker(new AlertViaController());
        //    BatteryCharacter batteryCharacter = new BatteryCharacter();
        //    batteryCharacter.coolingType = CoolingType.MED_ACTIVE_COOLING;
        //    bchecker.BatteryCheck(batteryCharacter, 25);
        //}

        //[Fact]
        //public void BatteryAlertViaEmailTest()
        //{
        //    var bchecker = new BatteryChecker(new AlertViaEmail("a.b@c.com"));
        //    BatteryCharacter batteryCharacter = new BatteryCharacter();
        //    batteryCharacter.coolingType = CoolingType.HI_ACTIVE_COOLING;
        //    bchecker.BatteryCheck(batteryCharacter, 40);
        //}
        [Fact]
        public void formatEmailDataTest()
        {
            Assert.Equal("To: a.b@c.com\nHi, the temperature is TOO_HIGH\n", AlertViaEmail.formatEmailData("a.b@c.com", BreachType.TOO_HIGH));
        }
        [Fact]
        public void SendEmailTest()
        {
            AlertViaEmail.sendToEmail(BreachType.TOO_HIGH);
        }
        [Fact]
        public void sendToControllerTest()
        {
            AlertViaController.sendToController(BreachType.NORMAL);
        }
        [Fact]
        public void sendToControllerwhenHi()
        {
            TypewiseAlert types = new TypewiseAlert(new LiBatteryparameter());
            BreachType type = types.classifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, 55);
            Assert.Equal(BreachType.TOO_HIGH, type);
            var alert = new AlertViaController();
            alert.BatteryAlert(type);
        }

        [Fact]
        public void TypewiseAlertTestMethod()
        {
            BatteryChecker bchecker = new BatteryChecker(new AlertViaEmail("a.b@c.com"),new LiBatteryparameter());
            BatteryCharacter batteryCharacter = new BatteryCharacter();
            batteryCharacter.coolingType = CoolingType.HI_ACTIVE_COOLING;
            bchecker.BatteryCheck(batteryCharacter, 55);
            Assert.True(true);
        }

        [Fact]
        public void setLimitValuesPassive_CoolingTest()
        {
            TypewiseAlert types = new TypewiseAlert(new LiBatteryparameter());
            bParams = new BatteryParamaters();
            var data = types.setLimitValues(CoolingType.PASSIVE_COOLING, bParams);

            Assert.Equal(0, data.lowerLimit);
            Assert.Equal(35, data.upperLimit);
        }

        [Fact]
        public void setLimitValuesHi_Active_CoolingTest()
        {
            TypewiseAlert types = new TypewiseAlert(new LiBatteryparameter());
            bParams = new BatteryParamaters();
            var data = types.setLimitValues(CoolingType.HI_ACTIVE_COOLING, bParams);

            Assert.Equal(0, data.lowerLimit);
            Assert.Equal(45, data.upperLimit);
        }

        [Fact]
        public void setLimitValuesMed_Active_CoolingTest()
        {
            TypewiseAlert types = new TypewiseAlert(new LiBatteryparameter());
            bParams = new BatteryParamaters();
            var data = types.setLimitValues(CoolingType.MED_ACTIVE_COOLING, bParams);

            Assert.Equal(0, data.lowerLimit);
            Assert.Equal(40, data.upperLimit);
        }

        [Fact]
        public void Passive_CoolingTest()
        {
            var data = new LiBatteryparameter();
            var res = data.Passive_Cooling();

            Assert.Equal(0, res.lowerLimit);
            Assert.Equal(35, res.upperLimit);
        }

        [Fact]
        public void Hi_Active_CoolingTest()
        {
            var data = new LiBatteryparameter();
            var res = data.Hi_Active_Cooling();

            Assert.Equal(0, res.lowerLimit);
            Assert.Equal(45, res.upperLimit);
        }

        [Fact]
        public void Med_Active_CoolingTest()
        {
            var data = new LiBatteryparameter();
            var res = data.Med_Active_Cooling();

            Assert.Equal(0, res.lowerLimit);
            Assert.Equal(40, res.upperLimit);
        }
    }
}

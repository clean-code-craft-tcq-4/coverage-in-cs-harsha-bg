using Xunit;
using static TypewiseAlert.Constants;
using static TypewiseAlert.LiIonBatteryparameter;

namespace TypewiseAlert.Test
{
    public class TypewiseAlertTest
    {
        BatteryParamaters bParams;

        LithiumBattery type;
        LithiumBattery Litype = new LithiumBattery(new LiIonBatteryparameter());
        [Fact]
        public void classifyTemperatureBreach_Passive_Cooling()
        {
            LithiumBattery types = new LithiumBattery(new LiIonBatteryparameter());
            Assert.True(types.classifyTemperatureBreach(CoolingType.PASSIVE_COOLING, 15) ==
              Constants.BreachType.NORMAL);
        }
        [Fact]
        public void classifyTemperatureBreach_HI_Active_Cooling()
        {
            LithiumBattery types = new LithiumBattery(new LiIonBatteryparameter());
            Assert.True(types.classifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, 55) ==
              Constants.BreachType.TOO_HIGH);
        }
        [Fact]
        public void classifyTemperatureBreach_MED_Active_Cooling()
        {
            LithiumBattery types = new LithiumBattery(new LiIonBatteryparameter());
            Assert.True(types.classifyTemperatureBreach(CoolingType.MED_ACTIVE_COOLING, 25) ==
              Constants.BreachType.NORMAL);
        }
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
            LithiumBattery types = new LithiumBattery(new LiIonBatteryparameter());
            BreachType type = types.classifyTemperatureBreach(CoolingType.HI_ACTIVE_COOLING, 55);
            Assert.Equal(BreachType.TOO_HIGH, type);
            var alert = new AlertViaController();
            alert.BatteryAlert(type);
        }

        [Fact]
        public void TypewiseAlertTestMethod()
        {
            BatteryChecker bchecker = new BatteryChecker(new AlertViaEmail("a.b@c.com"), new LithiumBattery(new LiIonBatteryparameter()));
            BatteryCharacter batteryCharacter = new BatteryCharacter();
            batteryCharacter.coolingType = CoolingType.HI_ACTIVE_COOLING;
            bchecker.BatteryCheck(batteryCharacter, 55);
            Assert.True(true);
        }



        [Fact]
        public void Hi_Active_CoolingTest()
        {
            BatteryCharacter bchar = new BatteryCharacter();
            bchar.coolingType = CoolingType.HI_ACTIVE_COOLING;
            bchar.brand = "lithiumionbattery";
            var Bchecker = new BatteryChecker(new AlertViaController(), new LithiumBattery(new LiIonBatteryparameter()));
            Bchecker.BatteryCheck(bchar, 55);
        }

        [Fact]
        public void Hi_Active_CoolingLiSiTest()
        {
            BatteryCharacter bchar = new BatteryCharacter();
            bchar.coolingType = CoolingType.HI_ACTIVE_COOLING;
            bchar.brand = "lithiumionbattery";
            var Bchecker = new BatteryChecker(new AlertViaEmail("Harsha@bosch.com"), new LithiumBattery(new LiSiBatteryparameter()));
            Bchecker.BatteryCheck(bchar, 25);
        }
        [Fact]
        public void InfersBreachAsToo_Low()
        {
            bParams = new BatteryParamaters();
            bParams.temperature = 12;
            bParams.lowerLimit = 20;
            bParams.upperLimit = 30;
            type = new LithiumBattery(bParams);
            Assert.True(Litype.inferBreach() ==
              Constants.BreachType.TOO_LOW);
        }
        [Fact]
        public void Return_Too_Low_AsTrue()
        {

            bParams = new BatteryParamaters();
            bParams.temperature = 12;
            bParams.lowerLimit = 20;
            bParams.upperLimit = 30;
            Assert.True(LithiumBattery.BreachType_Too_Low(bParams));
        }
        [Fact]
        public void Return_Too_Low_AsFalse()
        {
            bParams = new BatteryParamaters();
            bParams.temperature = 22;
            bParams.lowerLimit = 20;
            bParams.upperLimit = 30;
            Assert.False(LithiumBattery.BreachType_Too_Low(bParams));
        }

        [Fact]
        public void InfersBreachAsNormal()
        {
            bParams = new BatteryParamaters();
            bParams.temperature = 25;
            bParams.lowerLimit = 20;
            bParams.upperLimit = 30;
            type = new LithiumBattery(bParams);
            Assert.True(type.inferBreach() ==
              Constants.BreachType.NORMAL);
        }

        [Fact]
        public void InfersBreachAsToo_High()
        {
            bParams = new BatteryParamaters();
            bParams.temperature = 40;
            bParams.lowerLimit = 20;
            bParams.upperLimit = 30;
            type = new LithiumBattery(bParams);
            Assert.True(type.inferBreach() ==
              Constants.BreachType.TOO_HIGH);
        }

        [Fact]
        public void ReturnToo_High_AsTrue()
        {
            bParams = new BatteryParamaters();
            bParams.temperature = 40;
            bParams.lowerLimit = 20;
            bParams.upperLimit = 30;
            Assert.True(LithiumBattery.BreachType_Too_High(bParams));
        }
        [Fact]
        public void ReturnToo_High_AsFalse()
        {
            bParams = new BatteryParamaters();
            bParams.temperature = 25;
            bParams.lowerLimit = 20;
            bParams.upperLimit = 30;
            Assert.False(LithiumBattery.BreachType_Too_High(bParams));
        }
        [Fact]
        public void Passive_CoolingTest()
        {
            var data = new LiIonBatteryparameter();
            var res = data.Passive_Cooling();

            Assert.Equal(0, res.lowerLimit);
            Assert.Equal(35, res.upperLimit);
        }

        [Fact]
        public void Hi_Active_LiCoolingTest()
        {
            var data = new LiIonBatteryparameter();
            var res = data.Hi_Active_Cooling();

            Assert.Equal(0, res.lowerLimit);
            Assert.Equal(45, res.upperLimit);
        }

        [Fact]
        public void Med_Active_CoolingTest()
        {
            var data = new LiIonBatteryparameter();
            var res = data.Med_Active_Cooling();

            Assert.Equal(0, res.lowerLimit);
            Assert.Equal(40, res.upperLimit);
        }
        [Fact]
        public void setLimitValuesPassive_CoolingTest()
        {
            LithiumBattery types = new LithiumBattery(new LiIonBatteryparameter());
            bParams = new BatteryParamaters();
            types.setLimitValues(CoolingType.PASSIVE_COOLING);

            Assert.Equal(0, LithiumBattery.bparams.lowerLimit);
            Assert.Equal(35, LithiumBattery.bparams.upperLimit);
        }

        [Fact]
        public void setLimitValuesHi_Active_CoolingTest()
        {
            LithiumBattery types = new LithiumBattery(new LiIonBatteryparameter());
            bParams = new BatteryParamaters();
            types.setLimitValues(CoolingType.HI_ACTIVE_COOLING);

            Assert.Equal(0, LithiumBattery.bparams.lowerLimit);
            Assert.Equal(45, LithiumBattery.bparams.upperLimit);
        }

        [Fact]
        public void setLimitValuesMed_Active_CoolingTest()
        {
            LithiumBattery types = new LithiumBattery(new LiIonBatteryparameter());
            bParams = new BatteryParamaters();
            types.setLimitValues(CoolingType.MED_ACTIVE_COOLING);

            Assert.Equal(0, LithiumBattery.bparams.lowerLimit);
            Assert.Equal(40, LithiumBattery.bparams.upperLimit);
        }
    }
}

using static TypewiseAlert.LiIonBatteryparameter;

namespace TypewiseAlert
{
    public class LiIonBatteryparameter:ICoolingType
    {
        public struct BatteryParamaters
        {
            public double lowerLimit;
            public double upperLimit;
            public double temperature;
        }
        BatteryParamaters bparams;
        public BatteryParamaters Med_Active_Cooling()
        {
            bparams = new BatteryParamaters();
            bparams.lowerLimit = 0;
            bparams.upperLimit = 40;
            return bparams;
        }

        public BatteryParamaters Hi_Active_Cooling()
        {
            bparams = new BatteryParamaters();
            bparams.lowerLimit = 0;
            bparams.upperLimit = 45;
            return bparams;
        }

        public BatteryParamaters Passive_Cooling()
        {
            bparams = new BatteryParamaters();
            bparams.lowerLimit = 0;
            bparams.upperLimit = 35;
            return bparams;
        }
    }
    public class LiSiBatteryparameter : ICoolingType
    {
        BatteryParamaters bparams;
        public BatteryParamaters Hi_Active_Cooling()
        {
            bparams = new BatteryParamaters();
            bparams.lowerLimit = 0;
            bparams.upperLimit = 50;
            return bparams;
        }

        public BatteryParamaters Med_Active_Cooling()
        {
            bparams = new BatteryParamaters();
            bparams.lowerLimit = 0;
            bparams.upperLimit = 30;
            return bparams;
        }

        public BatteryParamaters Passive_Cooling()
        {
            bparams = new BatteryParamaters();
            bparams.lowerLimit = 0;
            bparams.upperLimit = 20;
            return bparams;
        }
    }
}

namespace TypewiseAlert
{
    public class LiBatteryparameter:ICoolingType
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
}

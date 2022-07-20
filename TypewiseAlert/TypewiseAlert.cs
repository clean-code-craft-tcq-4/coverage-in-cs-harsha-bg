using static TypewiseAlert.Constants;
using static TypewiseAlert.LiBatteryparameter;

namespace TypewiseAlert
{
    public class TypewiseAlert
    {
        public static ICoolingType type;
        public TypewiseAlert(ICoolingType typeobj)
        {
            type = typeobj;
        }

        public static BreachType inferBreach(BatteryParamaters values)
        {
            if (BreachType_Too_Low(values))
                return BreachType.TOO_LOW;
            if (BreachType_Too_High(values))
                return BreachType.TOO_HIGH;
            return BreachType.NORMAL;
        }
        public static bool BreachType_Too_Low(BatteryParamaters values)
        {
            if (values.temperature < values.lowerLimit)
                return true;
            return false;
        }
        public static bool BreachType_Too_High(BatteryParamaters values)
        {
            if (values.temperature > values.upperLimit)
                return true;
            return false;
        }
        public BreachType classifyTemperatureBreach(
            CoolingType coolingType, double temperatureInC)
        {
            BatteryParamaters bparams = new BatteryParamaters();
            bparams.temperature = temperatureInC;
            var data = setLimitValues(coolingType, bparams);
            bparams.lowerLimit = data.lowerLimit;
            bparams.upperLimit = data.upperLimit;
            return inferBreach(bparams);
        }

        public  BatteryParamaters setLimitValues(CoolingType coolingType, BatteryParamaters bparams)
        {
            if (coolingType is CoolingType.PASSIVE_COOLING)
                bparams = type.Passive_Cooling();
            if (coolingType is CoolingType.HI_ACTIVE_COOLING)
                bparams = type.Hi_Active_Cooling();
            if (coolingType is CoolingType.MED_ACTIVE_COOLING)
                bparams = type.Med_Active_Cooling();
            return bparams;
        }
    }
}

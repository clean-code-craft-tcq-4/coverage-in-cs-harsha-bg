using static TypewiseAlert.Constants;
using static TypewiseAlert.LiIonBatteryparameter;

namespace TypewiseAlert
{
    public class LithiumBattery:IBatteryClassify
    {
        public static ICoolingType type;
        public static BatteryParamaters bparams;
        public LithiumBattery(BatteryParamaters bp) {
            bparams.temperature = bp.temperature;
            bparams.lowerLimit = bp.lowerLimit;
            bparams.upperLimit = bp.upperLimit; 
        }
        public LithiumBattery(ICoolingType typeobj)
        {
            type = typeobj;
            bparams = new BatteryParamaters();
        }

        public BreachType inferBreach()
        {
            if (BreachType_Too_Low(bparams))
                return BreachType.TOO_LOW;
            if (BreachType_Too_High(bparams))
                return BreachType.TOO_HIGH;
            return BreachType.NORMAL;
        }
        public static bool BreachType_Too_Low(BatteryParamaters bparams)
        {
            if (bparams.temperature < bparams.lowerLimit)
                return true;
            return false;
        }
        public static bool BreachType_Too_High(BatteryParamaters bparams)
        {
            if (bparams.temperature > bparams.upperLimit)
                return true;
            return false;
        }
        public BreachType classifyTemperatureBreach(
            CoolingType coolingType, double temperatureInC)
        {
            setLimitValues(coolingType);
            bparams.temperature = temperatureInC;
            return inferBreach();
        }

        public void setLimitValues(CoolingType coolingType)
        {
            if (coolingType is CoolingType.PASSIVE_COOLING)
                bparams = type.Passive_Cooling();
            if (coolingType is CoolingType.HI_ACTIVE_COOLING)
                bparams = type.Hi_Active_Cooling();
            if (coolingType is CoolingType.MED_ACTIVE_COOLING)
                bparams = type.Med_Active_Cooling();
        }
    }
}

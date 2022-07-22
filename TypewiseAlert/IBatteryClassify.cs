using static TypewiseAlert.Constants;

namespace TypewiseAlert
{
    public interface IBatteryClassify
    {
        BreachType classifyTemperatureBreach(
            CoolingType coolingType, double temperatureInC);
        void setLimitValues(CoolingType coolingType);
        BreachType inferBreach();
    }
}

using static TypewiseAlert.Constants;

namespace TypewiseAlert
{
    public interface ITypewiseAlert
    {
       public void BatteryAlert(BreachType breachType);
    }
}

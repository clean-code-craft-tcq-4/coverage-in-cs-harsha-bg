using static TypewiseAlert.Constants;

namespace TypewiseAlert
{
    public class AlertViaController: ITypewiseAlert
    {
        const ushort header = 0xfeed;
        public void BatteryAlert(BreachType breachType)
        {
           sendToController(breachType);
        }
        public static void sendToController(BreachType breachType)
        {
            string.Format("{0} : {1}\n", header, breachType).PrintMessage();
        }
    }
}

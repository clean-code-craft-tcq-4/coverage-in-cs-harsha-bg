using static TypewiseAlert.Constants;

namespace TypewiseAlert
{
    public class AlertViaEmail : ITypewiseAlert
    {
        public static string recepient;
        public AlertViaEmail(string email)
        {
            recepient = email;
        }
        public void BatteryAlert(BreachType breachType)
        {
            sendToEmail(breachType);
        }
        public static void sendToEmail(BreachType breachType)
        {
            formatEmailData(recepient, breachType).PrintMessage();
        }
        public static string formatEmailData(string recepient, BreachType type)
        {
            return string.Format("To: {0}\nHi, the temperature is {1}\n", recepient, type);
        }
    }
}

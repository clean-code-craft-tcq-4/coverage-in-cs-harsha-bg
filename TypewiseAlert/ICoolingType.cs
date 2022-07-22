using static TypewiseAlert.LiIonBatteryparameter;

namespace TypewiseAlert
{
    public interface ICoolingType
    {
        public BatteryParamaters Med_Active_Cooling();
        public BatteryParamaters Hi_Active_Cooling();
        public BatteryParamaters Passive_Cooling();

    }
}

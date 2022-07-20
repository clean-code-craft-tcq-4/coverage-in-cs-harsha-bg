using System;
using static TypewiseAlert.Constants;

namespace TypewiseAlert
{
    public class BatteryChecker
    {
        ITypewiseAlert send;
        ICoolingType type;
        public BatteryChecker(ITypewiseAlert alertobj, ICoolingType typeobj)
        {
            send = alertobj;
            type = typeobj;
        }
        public void BatteryCheck(BatteryCharacter batteryChar, double temperatureInC)
        {
            TypewiseAlert types = new TypewiseAlert(type);
            send.BatteryAlert(types.classifyTemperatureBreach(
            batteryChar.coolingType, temperatureInC));
        }
    }
    public struct BatteryCharacter
    {
        public CoolingType coolingType;
        public string brand;
    }
}

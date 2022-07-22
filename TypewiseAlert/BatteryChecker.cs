using System;
using static TypewiseAlert.Constants;

namespace TypewiseAlert
{
    public class BatteryChecker
    {
        ITypewiseAlert send;
        IBatteryClassify type;
        public BatteryChecker(ITypewiseAlert alertobj, IBatteryClassify typeobj)
        {
            send = alertobj;
            type = typeobj;
        }
        public void BatteryCheck(BatteryCharacter batteryChar, double temperatureInC)
        {
            send.BatteryAlert(type.classifyTemperatureBreach(
            batteryChar.coolingType, temperatureInC));
        }
    }
    public struct BatteryCharacter
    {
        public CoolingType coolingType;
        public string brand;
    }
}

using System;

namespace Utils
{
    public struct MethodInvokeNotification : INotification
    {
        public Delegate Delegate { get; }
        public MethodInvokeNotification(Delegate trigger)
        {
            Delegate = trigger;
        }
    }
}
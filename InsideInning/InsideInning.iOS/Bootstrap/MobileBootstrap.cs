// HACK: this is to deal with the linker nuking the assembly
using Acr.XamForms.Mobile.iOS;

namespace InsideInning.iOS.Bootstrap
{
    public class MobileBootstrap 
    {
        public MobileBootstrap() 
        {
            new DeviceInfo();
        }
    }
}
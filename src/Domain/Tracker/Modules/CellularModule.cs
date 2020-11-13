using Core.Domain.Tracker.Events;
using Core.Domain.Tracker.Modules;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Domain.Tracker.Modules
{
    public class CellularModule : DeviceModule
    {
        public string Imei { get; }

        public SimCard? SimCard { get; private set; }

        public CellularModule(string imei)
        {
            Imei = imei;
        }

        public Unit AttachSimCard(SimCard simCard)
        {
            if (SimCard != null)
            {
                PublishSimCardRemoved();
            }

            SimCard = simCard;

            PublishEvent(new SimCardAttached());

            return unit;
        }

        public void RemoveSimCard()
        {
            if (SimCard == null)
                return;

            SimCard = null;
            PublishSimCardRemoved();
        }

        Unit PublishSimCardRemoved()
            => SimCard switch
            {
                PhoneSimCard psc => PublishEvent(new SimCardRemoved(
                    SimCard.SerialNumber, this.Id, psc.PhoneNumber)),
                IotSimCard _ => PublishEvent(new SimCardRemoved(
                    SimCard.SerialNumber, this.Id)),
                _ => unit
            };
    }
}
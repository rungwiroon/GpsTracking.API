using Core.Domain.Trackers.Events;
using Core.Domain.Trackers.Modules;
using LanguageExt;
using static LanguageExt.Prelude;

namespace Core.Domain.Trackers.Modules
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

            AddDomainEvent(new SimCardAttached());

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
                PhoneSimCard psc => AddDomainEvent(new SimCardRemoved(
                    SimCard.SerialNumber, this.Id, psc.PhoneNumber)),
                IotSimCard _ => AddDomainEvent(new SimCardRemoved(
                    SimCard.SerialNumber, this.Id)),
                _ => unit
            };

        public void SetApn()
        {

        }
    }
}
using Core.Domain.SeedWork;
using Core.Domain.Trackers.Events;
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

        public Seq<IDomainEvent> AttachSimCard(SimCard simCard)
        {
            if (SimCard != null)
            {
                PublishSimCardRemoved();
            }

            SimCard = simCard;

            return new() { new SimCardAttached() };
        }

        public void RemoveSimCard()
        {
            if (SimCard == null)
                return;

            SimCard = null;
            PublishSimCardRemoved();
        }

        Seq<IDomainEvent> PublishSimCardRemoved()
            => SimCard switch
            {
                PhoneSimCard psc => new Seq<IDomainEvent>()
                {
                    new SimCardRemoved(
                    SimCard.SerialNumber, this.Id, psc.PhoneNumber)
                },
                IotSimCard _ => new()
                {
                    (new SimCardRemoved(
                    SimCard.SerialNumber, this.Id))
                },
                _ => new SeqEmpty()
            };

        public void SetApn()
        {

        }
    }
}
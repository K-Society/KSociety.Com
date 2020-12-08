namespace KSociety.Com.Driver.Ping.IntegrationEvent.Event
{
    public class PingStatusIntegrationEvent : KSociety.Base.EventBus.Events.IntegrationEvent
    {
        public string Name { get; }
        public string Address { get; }
        public bool Status { get; }

        public PingStatusIntegrationEvent(string name, string routingKey, string address, bool status)
        :base(routingKey)
        {
            Name = name;
            Address = address;
            Status = status;
        }
    }
}

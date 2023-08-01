using FluentValidation;
using KSociety.Base.Domain.Shared.Class;
using KSociety.Base.InfraSub.Shared.Interface;
using KSociety.Com.Domain.Entity.Event;
using System;
using System.Threading.Tasks;

namespace KSociety.Com.Domain.Entity.Common
{
    public class Tag : EntityNotifier //<NotifyTagEvent>
    {
        #region [Propery]

        //public Guid TagId { get; protected set; }
        public Guid Id { get; protected set; }

        public int AutomationTypeId { get; protected set; }
        public AutomationType AutomationType { get; protected set; }

        public string Name { get; protected set; }

        public Guid ConnectionId { get; protected set; }
        public Connection Connection { get; protected set; }

        public bool Enable { get; protected set; }

        public string InputOutput { get; protected set; }
        public InOut InOut { get; protected set; }

        public string AnalogDigitalSignal { get; protected set; }
        public AnalogDigital AnalogDigital { get; protected set; }

        public string MemoryAddress { get; protected set; }

        public bool Invoke { get; protected set; }

        public Guid TagGroupId { get; protected set; }
        public TagGroup TagGroup { get; protected set; }

        //
        public string Value { get; protected set; } = string.Empty;
        public string OldValue { get; protected set; } = string.Empty;

        public DateTime Timestamp { get; private set; } = DateTime.Now;
        //public TagIntegrationEvent TagReadEvent => new TagIntegrationEvent(TagGroup.Name + ".automation.read", TagGroup.Name, Name, Value);
        //public TagIntegrationEvent TagWriteEvent => new TagIntegrationEvent(TagGroup.Name + ".automation.write", TagGroup.Name, Name, Value);

        //public virtual S7.S7Tag S7Tag { get; private set; }

        //public virtual Logix.LogixTag LogixTag { get; private set; }

        //public virtual ICollection<Domain.Entity.S7.Tag> S7Tags { get; set; }
        //public virtual ICollection<Domain.Entity.Logix.Tag> LogixTags { get; set; }

        #endregion

        #region [Constructor]

        //public Tag()
        //{

        //}

        public Tag( /*ILogger<Tag> logger*/)
            //: base(logger)
        {

        }
        //public Tag(INotifierMediatorService<NotifyTagEvent> notifierMediatorService)
        //    : base(notifierMediatorService)
        //{

        //}
        //public Tag(/*ILogger<Tag> logger,*/ /*INotifierMediatorService<NotifyTagEvent> notifierMediatorService*/)
        //    //: base(logger, notifierMediatorService)
        //{

        //}

        public Tag(
                //ILogger<Tag> logger,
                //IMediator mediator,
                int automationTypeId,
                string name,
                Guid connectionId,
                bool enable,
                string inputOutput,
                string analogDigitalSignal,
                string memoryAddress,
                bool invoke,
                Guid tagGroupId
            )
            //:base(logger/*, mediator*/)
        {
            AutomationTypeId = automationTypeId;
            Name = name;
            ConnectionId = connectionId;
            Enable = enable;
            InputOutput = inputOutput;
            AnalogDigitalSignal = analogDigitalSignal;
            MemoryAddress = memoryAddress;
            Invoke = invoke;
            TagGroupId = tagGroupId;

            var commonTagValidator = new Validator.Common.Tag();
            commonTagValidator.ValidateAndThrow(this);
        }

        //public Tag(
        //    //IMediator mediator,
        //    int automationTypeId,
        //    string name,
        //    Guid connectionId,
        //    bool enable,
        //    string inputOutput, 
        //    string analogDigitalSignal,
        //    string address,
        //    bool invoke,
        //    Guid tagGroupId
        //)
        //    //:base()
        //{
        //    AutomationTypeId = automationTypeId;
        //    Name = name;
        //    ConnectionId = connectionId;
        //    Enable = enable;
        //    InputOutput = inputOutput;
        //    AnalogDigitalSignal = analogDigitalSignal;
        //    Address = address;
        //    Invoke = invoke;
        //    TagGroupId = tagGroupId;

        //    var commonTagValidator = new Validator.Common.Tag();
        //    commonTagValidator.ValidateAndThrow(this);
        //}

        public Tag(
            ////IEventBus eventBus,
            ////ILogger<Tag> logger,
            INotifierMediatorService notifierMediatorService,
            ////Guid tagId,
            Guid id,
            int automationTypeId,
            string name,
            Guid connectionId,
            Connection connection,
            bool enable,
            string inputOutput,
            string analogDigitalSignal,
            string memoryAddress,
            bool invoke,
            Guid tagGroupId,
            TagGroup tagGroup
        )
            : base( /*logger,*/ notifierMediatorService)
        {
            //_eventBus = eventBus;
            Id = id;
            AutomationTypeId = automationTypeId;
            Name = name;
            ConnectionId = connectionId;
            Connection = connection;
            Enable = enable;
            InputOutput = inputOutput;
            AnalogDigitalSignal = analogDigitalSignal;
            MemoryAddress = memoryAddress;
            Invoke = invoke;
            TagGroupId = tagGroupId;
            TagGroup = tagGroup;

            var commonTagValidator = new Validator.Common.Tag();
            commonTagValidator.ValidateAndThrow(this);
        }

        //public Tag(
        //    //IEventBus eventBus,
        //    INotifierMediatorService<NotifyTagEvent> notifierMediatorService,
        //    //Guid tagId,
        //    Guid id,
        //    int automationTypeId,
        //    string name,
        //    Guid connectionId,
        //    Connection connection,
        //    bool enable,
        //    string inputOutput, 
        //    string analogDigitalSignal, 
        //    string address,
        //    bool invoke,
        //    Guid tagGroupId,
        //    TagGroup tagGroup
        //)
        //    :base(/*LogManager.GetCurrentClassLogger(),*/ notifierMediatorService)
        //{
        //    //_eventBus = eventBus;
        //    Id = id;
        //    AutomationTypeId = automationTypeId;
        //    Name = name;
        //    ConnectionId = connectionId;
        //    Connection = connection;
        //    Enable = enable;
        //    InputOutput = inputOutput;
        //    AnalogDigitalSignal = analogDigitalSignal;
        //    Address = address;
        //    Invoke = invoke;
        //    TagGroupId = tagGroupId;
        //    TagGroup = tagGroup;

        //    var commonTagValidator = new Validator.Common.Tag();
        //    commonTagValidator.ValidateAndThrow(this);
        //}

        //For DataGrid
        public Tag(
                //IMediator mediator,
                //Guid tagId,
                Guid id,
                int automationTypeId,
                string name,
                Guid connectionId,
                bool enable,
                string inputOutput,
                string analogDigitalSignal,
                string memoryAddress,
                bool invoke,
                Guid tagGroupId
            )
            //:base(/*LogManager.GetCurrentClassLogger()*//*, mediator*/)
        {
            //Console.WriteLine("base ForCSV: " + memoryAddress);
            Id = id;
            AutomationTypeId = automationTypeId;
            Name = name;
            ConnectionId = connectionId;
            Enable = enable;
            InputOutput = inputOutput;
            AnalogDigitalSignal = analogDigitalSignal;
            MemoryAddress = memoryAddress;
            Invoke = invoke;
            TagGroupId = tagGroupId;

            var commonTagValidator = new Validator.Common.Tag();
            commonTagValidator.ValidateAndThrow(this);
        }

        #endregion

        public async ValueTask SetReadValue(string value, DateTime timestamp)
        {
            //Logger?.LogTrace("SetReadValue: " + value);
            Value = value;
            Timestamp = timestamp;
            if (OldValue.Equals(Value))
            {

            }
            else
            {
                OldValue = Value;

                //if (Invoke && (InputOutput.Equals("R") || InputOutput.Equals("RW")))
                //{
                //Logger.Trace("Domain Tag: " + Name + " - " + Value);
                //TagGroup.EventBus?.Publish(TagReadEvent);

                if (NotifierMediatorService != null /*&& Invoke*/)
                {
                    //Logger.LogCritical("Domain Tag Publish! " + Name + " " + Value);
                    await NotifierMediatorService
                        .NotifyAsync(new TagValueChanged( /*Logger,*/ this, Name, Value, Timestamp))
                        .ConfigureAwait(false);
                    //Logger.LogTrace("Domain Tag Publish! " + Name + " " + Value);
                }
                //}
            }
        } //SetReadValue

        public void SetWriteValue(string value)
        {
            Value = value;
            if (InputOutput.Equals("W") || InputOutput.Equals("RW"))
            {
                //TagGroup.EventBus?.Publish(TagWriteEvent);
            }
        } //SetWriteValue

        public virtual string ReadTagFromPlc()
        {
            return Value;
        }

        public virtual async ValueTask<string> ReadTagFromPlcAsync()
        {
            return Value;
        }

        public virtual bool WriteTagToPlc(string value)
        {
            Value = value;
            return true;
        }

        public virtual async ValueTask<bool> WriteTagToPlcAsync(string value)
        {
            Value = value;
            return true;
        }
    }
}
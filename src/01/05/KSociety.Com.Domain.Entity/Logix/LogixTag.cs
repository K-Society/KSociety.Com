namespace KSociety.Com.Domain.Entity.Logix
{
    public class LogixTag : Common.Tag
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid TagId { get; private set; }

        //public Guid StdTagId { get; private set; }
        //public virtual Common.Tag StdTag { get; private set; }

        //[Required]
        //[StringLength(50)]
        //[Index(IsUnique = true)]
        //public string Name { get; private set; }

        //[Required]
        //[StringLength(50)]
        //public string Address { get; private set; }

        //[Required]
        //[StringLength(7)]
        //public string AnalogDigitalSignal { get; private set; }
        //public AnalogDigital AnalogDigital { get; private set; }

        //public Guid? ConnectionId { get; private set; }
        //public Connection Connection { get; private set; }

        //public Guid? GroupId { get; private set; }
        //public Standard.TagGroup Group { get; private set; }

        //[Required]
        //public bool Enable { get; private set; }

        ////[Required]
        //public bool Invoke { get; private set; }

        //public virtual ICollection<Std.Domain.Db.Entity.Common.Tag> StdTags { get; set; }

        //private Tag() { }

        //public LogixTag()
        //:base(LogManager.GetCurrentClassLogger())
        //{

        //}

        public LogixTag(
                //Guid stdTagId
                //IMediator mediator
            )
            //:base(/*LogManager.GetCurrentClassLogger()*//*, mediator*/)
        {
            //StdTagId = stdTagId;
        }
    }
}
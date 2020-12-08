namespace KSociety.Com.Driver.Enip.ControlLogixNet
{
    /// <summary>
    /// Processor Fault State
    /// </summary>
    public enum ProcessorFaultState
    {
        /// <summary>
        /// No Fault
        /// </summary>
        None = 0,
        /// <summary>
        /// Minor Recoverable Fault
        /// </summary>
        MinorRecoverable = 1,
        /// <summary>
        /// Minor Unrecoverable Fault
        /// </summary>
        MinorUnrecoverable = 2,
        /// <summary>
        /// Major Recoverable Fault
        /// </summary>
        MajorRecoverable = 3,
        /// <summary>
        /// Major Unrecoverable Fault
        /// </summary>
        MajorUnrecoverable = 4
    }
}

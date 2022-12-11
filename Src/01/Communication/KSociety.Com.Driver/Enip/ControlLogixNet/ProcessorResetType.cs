namespace KSociety.Com.Driver.Enip.ControlLogixNet
{
    /// <summary>
    /// Used to determine the type of reset to perform
    /// </summary>
    internal enum ProcessorResetType
    {
        /// <summary>
        /// Emulate as closely as possible to a power cycle
        /// </summary>
        PowerCycle = 0,

        /// <summary>
        /// Return to the out-of-the-box configuration, then power cycle
        /// </summary>
        FactoryReset = 1
    }
}
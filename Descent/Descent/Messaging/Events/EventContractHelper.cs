namespace Descent.Messaging.Events
{
    /// <summary>
    /// Helper for contracts in events.
    /// </summary>
    public class EventContractHelper
    {
        public static bool TryParseInt(string str)
        {
            int success;
            return int.TryParse(str, out success);
        }
    }
}

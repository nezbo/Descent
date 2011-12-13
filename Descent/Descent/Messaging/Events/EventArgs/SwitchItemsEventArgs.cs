
namespace Descent.Messaging.Events
{
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The event arguments for switching items.
    /// </summary>
    /// <author>
    /// Simon Westh Henriksen
    /// </author>
    public sealed class SwitchItemsEventArgs : GameEventArgs
    {
        public SwitchItemsEventArgs(int field1, int field2)
        {
            Contract.Requires(field1 >= 0);
            Contract.Requires(field2 >= 0);

            Field1 = field1;
            Field2 = field2;
        }

        public SwitchItemsEventArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 2);
            
            Contract.Requires(Contract.ForAll(stringArgs, s => EventContractHelper.TryParseInt(s) && int.Parse(s) >= 0));

            PopulateWithArgs(stringArgs);
        }

        public int Field1 { get; set; }

        public int Field2 { get; set; }

        public override void PopulateWithArgs(string[] stringArgs)
        {
            Contract.Requires(stringArgs != null);
            Contract.Requires(stringArgs.Length == 2);
            
            Contract.Requires(Contract.ForAll(stringArgs, s => EventContractHelper.TryParseInt(s) && int.Parse(s) >= 0));

            Field1 = int.Parse(stringArgs[0]);
            Field2 = int.Parse(stringArgs[1]);
        }

        public override string ToString()
        {
            return string.Join(",", Field1, Field2);
        }
    }
}

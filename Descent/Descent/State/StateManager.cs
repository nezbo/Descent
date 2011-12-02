using Descent.Messaging.Events;
using Descent.Model.Player;

namespace Descent.State
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics.Contracts;

    /// <summary>
    /// The handler of all states. Knows about the current state and what to do next.
    /// </summary>
    /// <author>Martin Marcher</author>
    public class StateManager
    {
        private readonly StateMachine stateMachine;
        private EventManager eventManager = Player.Instance.EventManager;

        public StateManager()
        {
            stateMachine = new StateMachine(new State[] { State.Initiation, State.NewRound });
        }

        public State CurrentState
        {
            get { return stateMachine.CurrentState; }
        }

        public State[] PreviousStates(int count)
        {
            Contract.Requires(count > 0);
            Contract.Ensures(Contract.Result<State[]>().Length <= count);
            return stateMachine.PreviousStates(count);
        }
    }
}

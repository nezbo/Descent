// -----------------------------------------------------------------------
// <copyright file="StateManager.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

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
        private StateMachine stateMachine;

        public State CurrentState { get { return stateMachine.CurrentState; } }

        public StateManager()
        {
            stateMachine = new StateMachine(new State[] {State.HeroPartyTurn, State.HeroPartyInitiation});
        }

        public State[] PreviousStates(int count)
        {
            Contract.Requires(count > 0);
            Contract.Ensures(Contract.Result<State[]>().Length <= count);
            return stateMachine.PreviousStates(count);
        }
    }
}

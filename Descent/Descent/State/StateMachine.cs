namespace Descent.State
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// The handler of all states. Knows about the current state and what to do next.
    /// </summary>
    /// <author>Martin Marcher</author>
    public class StateMachine
    {
        private List<State> _states = new List<State>();
        private int currentIndex;

        public State CurrentState { get { return _states[currentIndex]; } }
        public State NextState { get { return _states[currentIndex + 1]; } }

        [ContractInvariantMethod]
        private void Invariant()
        {
            // Ensures that are always a current and next state
            Contract.Invariant(currentIndex < _states.Count - 1);
        }

        public StateMachine(State[] startStates)
        {
            Contract.Requires(startStates != null && startStates.Length > 1);
            currentIndex = 0;
            _states.AddRange(startStates);
        }

        public void ChangeToNextState()
        {
            Contract.Ensures(currentIndex < _states.Count);
            currentIndex++;
        }

        public void PlaceStates(State[] states)
        {
            Contract.Requires(states != null && states.Length > 0);
            Contract.Ensures(NextState == states[0]);
            for (int counter = 0; counter < states.Length; counter++)
            {
                _states.Insert(currentIndex + counter + 1, states[counter]);
            }
        }

        public State[] PreviousStates(int count)
        {
            Contract.Requires(count > 0);
            Contract.Ensures(Contract.Result<State[]>().Length <= count);
            count = Math.Min(count, currentIndex);
            var states = _states.GetRange(currentIndex - count, currentIndex);
            states.Reverse();
            return states.ToArray();
        }

        public override string ToString()
        {
            string ret = "";
            foreach (var state in _states)
            {
                ret += state +", ";
            }
            return ret;
        }

        public static void Main(string[] args)
        {
            var machine = new StateMachine( new State[] {State.HeroPartyTurn, State.HeroPartyInitiation});
            System.Diagnostics.Debug.WriteLine(machine.CurrentState);
            machine.PlaceStates(new State[] {State.DrawSkillCards, State.BuyEquipment, State.TradeCard});
            machine.ChangeToNextState();
            System.Diagnostics.Debug.WriteLine(machine);
            machine.ChangeToNextState();
            machine.ChangeToNextState();
            System.Diagnostics.Debug.WriteLine(machine.CurrentState);
            foreach (var state in machine.PreviousStates(5))
            {
                System.Diagnostics.Debug.WriteLine(state);
            }
        }
    }
}

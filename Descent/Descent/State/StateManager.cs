using Descent.Messaging.Events;
using Descent.Model.Player;
using Descent.GUI;

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
        private readonly GUI.GUI gui;
        private readonly Model.Model model;
        private EventManager eventManager = Player.Instance.EventManager;

        // fields for different game logic variables
        private int currentHeroId;

        public StateManager(GUI.GUI gui, Model.Model model)
        {
            this.gui = gui;
            this.model = model;
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

        // Helper methods for the game
        private bool IsAPlayerTurn()
        {
            return stateMachine.IsOneBeforeOther(State.HeroTurn, State.OverlordTurn);
        }

        private Role DetermineRole()
        {
            if (Player.Instance.IsOverlord) return Role.Overlord;
            if (IsAPlayerTurn())
            {
                return Player.Instance.Hero.Id == currentHeroId ? Role.ActiveHero : Role.InactiveHero; 
            }

        }

        /// <summary>
        /// Should be called every time the state changes so the GUI can be updated to
        /// display stuff for the new state.
        /// </summary>
        /// <author>
        /// Emil Juul Jacobsen
        /// </author>
        private void StateChanged() // should maybe be delegated to the statemachine?
        {
            State newState = stateMachine.CurrentState;

            GUIElement newGUIE = GUIElementFactory.CreateStateElement(gui.GraphicsDevice, newState, DetermineRole()); // get new GUIElement

            switch (newState) // Fill in events and drawables
            {
                case State.DrawHeroCard:
                    {
                        newGUIE.AddClickAction("hero", n => n.QueueEvent(EventType.AssignHero,/*WTF Simon??? WHAT DO I DO*/ null));
                    }
            }

            gui.ChangeStateGUI(newGUIE); // change the GUI's state element.
        }
    }
}

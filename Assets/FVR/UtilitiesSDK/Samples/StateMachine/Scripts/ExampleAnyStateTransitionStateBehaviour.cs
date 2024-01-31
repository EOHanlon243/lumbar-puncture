/*
 * Copyright © 2023 FundamentalVR Ltd. hello@fundamentalsurgery.com. All rights reserved.
 * 
 * Use of this software is subject to compliance with the licence terms and conditions.
 */

using Fvr.SDK.Utilities;

using UnityEngine;

namespace Fvr.SDK.Samples
{
    /// <summary>
    /// An example <see cref="StateBehaviour"/> that triggers an any state transition.
    /// </summary>
    public class ExampleAnyStateTransitionStateBehaviour : StateBehaviour
    {
	    #region Private Variables & Properties
	    [SerializeField]
	    private string m_BoolStateParameterName = "GoToAnyState";
	    [SerializeField]
	    private string m_AnyStateBoolParameterName;
	    #endregion Private Variables & Properties

	    #region Public Methods
	    protected override void EnterBehaviour()
	    {
		    //Set the any state parameter ready for the transition.
		    State.RootStateMachine.AnyState.PrepareStateTransition(m_AnyStateBoolParameterName);

		    //Get the parameter from the state this is attached to and set it to true.
		    FvrLog.LogMessage($"Setting {m_BoolStateParameterName} to true on state {name}");
		    State.GetParameter(m_BoolStateParameterName).SetCurrentBooleanValue(true);
	    }
	    #endregion Public Methods
    }
}
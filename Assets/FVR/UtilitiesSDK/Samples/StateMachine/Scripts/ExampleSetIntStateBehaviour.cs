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
	/// Example class that sets a integer <see cref="StateParameter"/>.
	/// </summary>
	public class ExampleSetIntStateBehaviour : StateBehaviour
	{
		#region Private Variables & Properties
		[SerializeField]
		private string m_IntStateParameterName = "TestInt";
		
		[SerializeField]
		private int m_NewValue;
		#endregion Private Variables & Properties

		#region Public Methods
		protected override void EnterBehaviour()
		{
			//Get the parameter from the state this is attached to and set it to the provided value.
			FvrLog.LogMessage($"Setting {m_IntStateParameterName} to {m_NewValue} on state {name}");
			State.GetParameter(m_IntStateParameterName).SetCurrentIntegerValue(m_NewValue);
		}
		#endregion Public Methods
	}
}
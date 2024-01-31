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
	/// Example class that sets a boolean <see cref="StateParameter"/> to true.
	/// </summary>
	public class ExampleSetBoolStateBehaviour : StateBehaviour
	{
		#region Private Variables & Properties
		[SerializeField]
		private string m_BoolStateParameterName = "TestBool";
		#endregion Private Variables & Properties

		#region Public Methods
		protected override void EnterBehaviour()
		{
			//Get the parameter from the state this is attached to and set it to true.
			FvrLog.LogMessage($"Setting {m_BoolStateParameterName} to true on state {name}");
			State.GetParameter(m_BoolStateParameterName).SetCurrentBooleanValue(true);
		}
		#endregion Public Methods
	}
}
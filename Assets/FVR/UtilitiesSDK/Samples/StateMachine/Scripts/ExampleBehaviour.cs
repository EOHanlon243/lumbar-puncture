/*
 * Copyright © 2023 FundamentalVR Ltd. hello@fundamentalsurgery.com. All rights reserved.
 * 
 * Use of this software is subject to compliance with the licence terms and conditions.
 */

using Fvr.SDK.Utilities;

using System.Linq;

namespace Fvr.SDK.Samples
{
	/// <summary>
	/// Example of state behaviour that displays a log message when entering and exiting state, along with its index in
	/// the game object StateBehaviour hierarchy.
	/// </summary>
	public class ExampleBehaviour : StateBehaviour
	{
		#region Private Variables & Properties

		private int Index => State.Behaviours.ToList().IndexOf(this);

		#endregion Private Variables & Properties

		#region Public Methods

		protected override void EnterBehaviour()
		{
			FvrLog.LogMessage("<color=#2AC5BF>Entering behaviour " + name + " number " + Index + "</color>", this);
		}

		protected override void ExitBehaviour()
		{
			FvrLog.LogMessage("<color=#FFBE4A>Exiting behaviour " + name + " number " + Index + "</color>", this);
		}

		#endregion Public Methods
	}
}
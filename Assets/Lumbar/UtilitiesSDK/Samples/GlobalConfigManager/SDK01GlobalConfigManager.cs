/*
 * Copyright © 2023 FundamentalVR Ltd. hello@fundamentalsurgery.com. All rights reserved.
 * 
 * Use of this software is subject to compliance with the licence terms and conditions.
 */

﻿using Fvr.SDK.Utilities;

using System.Linq;

using UnityEngine;

namespace Fvr.SDK.Samples
{
	/// <summary>
	/// Class to show an example of how to create a derived <see cref="FvrGlobalConfigManager"/>.
	/// </summary>
	[CreateAssetMenu(fileName = "GlobalConfigManager", menuName = "FVR/Samples/SDK01GlobalConfigManager", order = 1)]
	public class SDK01GlobalConfigManager : FvrGlobalConfigManager
	{
		#region Private Variables & Properties
		private const string EXAMPLE_ID = "EXAMPLE";
		private const string EXAMPLE_TOOLTIP = "This is and example object to show how custom objects can be created.";
		#endregion Private Variables & Properties

		#region Private Methods
		protected override void HandleUpdateDataObjectsList()
		{
			if (!IsUnityEditor)
			{
				FvrLog.LogError("Updating data object list can only be done in the editor.");
				return;
			}
			
			//Make sure this is called fist as it handles creating the data objects list if it is null.
			base.HandleUpdateDataObjectsList();
			
			if (DataObjects.FirstOrDefault(item => item.ID == EXAMPLE_ID) == null)
			{
				DataObjects.Add(new GlobalConfigExampleObject(EXAMPLE_ID, EXAMPLE_TOOLTIP));
			}
		}
		#endregion Private Methods
	}
}
/*
 * Copyright © 2023 FundamentalVR Ltd. hello@fundamentalsurgery.com. All rights reserved.
 * 
 * Use of this software is subject to compliance with the licence terms and conditions.
 */

﻿using Fvr.SDK.Utilities;

using System;

using UnityEngine;

namespace Fvr.SDK.Samples
{
	/// <summary>
	/// Class to show an example of how to create a derived <see cref="IFvrGlobalConfigDataObject"/>.
	/// </summary>
	[Serializable]
	public class GlobalConfigExampleObject : IFvrGlobalConfigDataObject
	{
		#region Public Types
		public enum ExampleType
		{
			One,
			Two,
			Three
		}
		#endregion Public Types

		#region Public Variables & Properties
		public string ID => m_ID;
		public bool IsEnabled => m_IsEnabled;
		public string Tooltip => m_Tooltip;
		
		public ExampleType Example => m_Example;
		#endregion Public Variables & Properties
		
		#region Private Variables & Properties
		[SerializeField]
		private string m_ID;
		[SerializeField]
		private string m_Tooltip;
		[SerializeField]
		private bool m_IsEnabled;
		
		[SerializeField]
		private ExampleType m_Example;
		#endregion Private Variables & Properties
		
		#region Public Methods
		/// <summary>
		/// EDITOR ONLY: Sets up new data object with given ID and m_IsEnabled set to true.
		/// <para>Should only be called from derived class override of GlobalConfigManager.UpdateDataObjectsList</para>
		/// </summary>
		/// <param name="id">ID of the new data object.</param>
		/// <param name="tooltip">Tooltip to display when hovered over the option in the editor.</param>
		public GlobalConfigExampleObject(string id, string tooltip)
		{
			if (!FvrGlobalConfigManager.IsUnityEditor)
			{
				FvrLog.LogError("Creating a new data object can only be done in the editor.");
				return;
			}
			
			m_ID = id;
			m_Tooltip = tooltip;
			//This should always be enabled.
			m_IsEnabled = true;
		}
		#endregion Public Methods
	}
}
/*
 * Copyright © 2023 FundamentalVR Ltd. hello@fundamentalsurgery.com. All rights reserved.
 * 
 * Use of this software is subject to compliance with the licence terms and conditions.
 */

﻿using UnityEditor;

using UnityEngine;

namespace Fvr.SDK.Samples.Editor
{
	/// <summary>
	/// Property Drawer to display <see cref="GlobalConfigExampleObject"/> in the editor.
	/// </summary>
	[CustomPropertyDrawer(typeof(GlobalConfigExampleObject), true)]
	public class GlobalConfigExampleObjectPropertyDrawer : PropertyDrawer
	{
		#region Private Variables & Properties
		private const string ID_PROPERTY = "m_ID";
		private const string TOOLTIP_PROPERTY = "m_Tooltip";
		private const string EXAMPLE_TYPE_PROPERTY = "m_Example";

		private const float PROPERTY_X_OFFSET = 200.0f;
		#endregion Private Variables & Properties

		#region Public Methods
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			HandleOnGUI(position, property, label);
		}
		#endregion Public Methods

		#region Private Methods
		private void HandleOnGUI(Rect position, SerializedProperty property, GUIContent label)
		{
			//Get the properties from the class.
			string id = property.FindPropertyRelative(ID_PROPERTY).stringValue;
			string tooltip = property.FindPropertyRelative(TOOLTIP_PROPERTY).stringValue;
			SerializedProperty exampleType = property.FindPropertyRelative(EXAMPLE_TYPE_PROPERTY);

			//Display the label with a tooltip
			EditorGUI.LabelField(position, new GUIContent(id, tooltip));
			//Offset the property field to give space for the label.
			position.x += PROPERTY_X_OFFSET;
			//Decrease the width by the offset so it still fits on screen.
			position.width -= PROPERTY_X_OFFSET;
			//Display property without a label as it has been manually created above.
			EditorGUI.PropertyField(position, exampleType, GUIContent.none);
		}
		#endregion Private Methods
	}
}
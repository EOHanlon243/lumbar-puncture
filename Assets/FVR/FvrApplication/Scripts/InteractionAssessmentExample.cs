/*
 * Copyright © 2023 FundamentalVR Ltd. hello@fundamentalsurgery.com. All rights reserved.
 * 
 * Use of this software is subject to compliance with the licence terms and conditions.
 */

using Fvr.SDK.Common;
using Fvr.SDK.Utilities;

using System;

using UnityEngine;

namespace Fvr.SDK.Example
{
	/// <summary>
	/// An example to show triggering adverse events, and setting surgical score for interaction assessment.
	/// </summary>
	public class InteractionAssessmentExample : MonoBehaviour
	{
		#region Private Variables & Properties
		[SerializeField, Tooltip("The list of adverse event IDs to trigger for this step.")]
		private string[] m_AdverseEventIDs = Array.Empty<string>();
		[SerializeField, Tooltip("The surgical objective score to give this step.")]
		private float m_SurgicalObjectiveScore;
		
		private IFvrModuleScoreManager m_ModuleScoreManager;
		#endregion Private Variables & Properties

		#region Unity Methods
		private void Start()
		{
			m_ModuleScoreManager = ServiceResolver.Resolve<IFvrModuleScoreManager>();
		}
		#endregion Unity Methods

		#region Public Methods
		/// <summary>
		/// Calls the adverse events for a step and then completes the step.
		/// Hooked up to the enter behaviour event of the desired step <see cref="StateBehaviour"/> of the module state machine.
		/// </summary>
		public void TriggerStepScoring()
		{
			//Go through each of the given adverse event IDs and trigger an adverse event for them.
			//In a real interaction these will be triggered by incorrect actions the user has done.
			foreach (string adverseEventID in m_AdverseEventIDs)
			{
				TriggerAdverseEvent(adverseEventID);
			}
			
			//This is now the end of the step so set the surgical objective score.
			//This is done at the end as it represents how well the user did at completing the objective of the step.
			SetSurgicalObjective();
		}
		#endregion Public Methods

		#region Private Methods
		private void TriggerAdverseEvent(string adverseEventID)
		{
			FvrLog.LogMessage($"Triggering an adverse event with the ID {adverseEventID}.");
			m_ModuleScoreManager.AddAdverseEvent(adverseEventID);
		}
		
		private void SetSurgicalObjective()
		{
			FvrLog.LogMessage($"Setting the surgical objective score with a value of {m_SurgicalObjectiveScore}.");
			//As there is no actual interaction we will use a predefined value. But for actual scoring this should be based on how the user did.
			m_ModuleScoreManager.SetSurgicalObjective(m_SurgicalObjectiveScore);
		}
		#endregion Private Methods
	}
}
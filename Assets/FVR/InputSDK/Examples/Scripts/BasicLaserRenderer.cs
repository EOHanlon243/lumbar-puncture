/*
 * Copyright © 2023 FundamentalVR Ltd. hello@fundamentalsurgery.com. All rights reserved.
 * 
 * Use of this software is subject to compliance with the licence terms and conditions.
 */

using Fvr.SDK.Common;
using UnityEngine;
using Fvr.SDK.Utilities;

namespace Fvr.SDK.Input.Examples
{
    /// <summary>
    /// Follows a transform and sets a LineRenderer's positions based on its forward vector.
    /// </summary>
    public class BasicLaserRenderer : MonoBehaviour
    {
        #region Public Variables & Properties

        [SerializeField]
        private float m_WidthMultiplier = 1f;

        [SerializeField, Tooltip("Default laser length.")]
        private float m_LaserLength = 10f;

        private LineRenderer m_LineRenderer = null;
        private Vector3[] m_Positions = null;

        private IUIRaycaster m_Raycaster = null;

        #endregion Public Variables & Properties

        #region Unity Methods

        private void Awake()
        {
            m_LineRenderer = GetComponent<LineRenderer>();
            FvrLog.AssertCondition(m_LineRenderer != null, $"LineRenderer component not found in {name}");
            m_Positions = new Vector3[2];
            m_LineRenderer.widthMultiplier = m_WidthMultiplier;

            m_Raycaster = GetComponent<IUIRaycaster>();
        }

        private void Update()
        {
            if (m_LineRenderer == null)
            {
                return;
            }

            if (m_Raycaster != null)
            {
                if (m_Raycaster.CurrentHit.HasValue)
                {
                    m_Positions[1] = m_Raycaster.CurrentHit.Value.point;
                }
                else
                {
                    m_Positions[1] = transform.position + transform.forward * m_LaserLength;
                }
            }

            m_Positions[0] = transform.position;
            m_LineRenderer.SetPositions(m_Positions);
        }

        #endregion Unity Methods
    }
}
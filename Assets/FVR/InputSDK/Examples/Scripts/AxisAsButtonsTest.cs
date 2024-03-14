// 
// Copyright © 2023 FundamentalVR Ltd. hello@fundamentalsurgery.com. All rights reserved.
// 
// Use of this software is subject to compliance with the licence terms and conditions.
// 

using System;
using Fvr.SDK.Utilities;
using UnityEngine;

namespace Fvr.SDK.Input.Examples
{
    [DependsOnCursorComponent(typeof(InputActionsEventHandler))]
    public class AxisAsButtonsTest : CursorComponent
    {

        private InputActionsEventHandler m_InputActionsEventHandler;
        
        public override void OnCursorAttached()
        {
            m_InputActionsEventHandler = GetComponent<InputActionsEventHandler>();
            FvrLog.AssertCondition(m_InputActionsEventHandler != null, $"Could not find {nameof(DeviceUsageEventHandler)}");
            

            m_InputActionsEventHandler.AddListener(
                InputActions.UseObject, 
                new Action(() => Debug.Log($"{InputActions.UseObject} was pressed")), 
                ButtonEventTriggersOn.Hold);
        }
        
        public override void OnCursorReleased()
        {
            throw new System.NotImplementedException();
        }
    }
}

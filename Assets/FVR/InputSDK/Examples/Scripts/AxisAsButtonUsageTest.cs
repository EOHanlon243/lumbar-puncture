// 
// Copyright © 2023 FundamentalVR Ltd. hello@fundamentalsurgery.com. All rights reserved.
// 
// Use of this software is subject to compliance with the licence terms and conditions.
// 

using System;
using Fvr.SDK.Common;
using Fvr.SDK.Utilities;
using UnityEngine;

namespace Fvr.SDK.Input.Examples
{
    [DependsOnCursorComponent(typeof(DeviceUsageEventHandler))]
    public class AxisAsButtonUsageTest : CursorComponent
    {

        private DeviceUsageEventHandler m_DeviceUsageEventEventHandler;
        
        public override void OnCursorAttached()
        {
            m_DeviceUsageEventEventHandler = GetComponent<DeviceUsageEventHandler>();
            FvrLog.AssertCondition(m_DeviceUsageEventEventHandler != null, $"Could not find {nameof(DeviceUsageEventHandler)}");
            

            m_DeviceUsageEventEventHandler.AddListener(
                DeviceUsages.Primary2DAxisUp, 
                new Action(() => Debug.Log($"{DeviceUsages.Primary2DAxisUp} was pressed")), 
                ButtonEventTriggersOn.Hold);
            
        }
        
        public override void OnCursorReleased()
        {
            throw new System.NotImplementedException();
        }
    }
}

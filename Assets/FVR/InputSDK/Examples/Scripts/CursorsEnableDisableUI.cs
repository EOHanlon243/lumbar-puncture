/*
 * Copyright © 2023 FundamentalVR Ltd. hello@fundamentalsurgery.com. All rights reserved.
 * 
 * Use of this software is subject to compliance with the licence terms and conditions.
 */

﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fvr.SDK.Common;
using Fvr.SDK.Utilities;

namespace Fvr.SDK.Input.Examples
{
    /// <summary>
    /// Utility class to test the enable/disable functionalities in ICursorProvider and IOCursorManager
    /// </summary>
    public class CursorsEnableDisableUI : MonoBehaviour
    {
        #region Private Fields

        [SerializeField]
        private Button m_LeftOnlyButton = null;

        [SerializeField]
        private Button m_RightOnlyButton = null;

        [SerializeField]
        private Button m_AllTogetherButton = null;

        private IDeviceDataProvider m_DeviceProvider = null;

        #endregion Private Fields

        #region Unity Methods

        private void Start()
        {
            FvrLog.AssertCondition(m_LeftOnlyButton != null, "Left cursors enabler button isn't set.");
            FvrLog.AssertCondition(m_RightOnlyButton != null, "Right cursors enabler button isn't set.");

            m_DeviceProvider = ServiceResolver.Resolve<IDeviceDataProvider>();
            m_LeftOnlyButton.onClick.AddListener(() =>
            {
                IEnumerable<DeviceStream> enableDevices =
                    m_DeviceProvider.GetAllMatchingDeviceStreams(DeviceUsages.LeftHanded, mustSatisfyAll: true);
                IEnumerable<DeviceStream> disableDevices =
                    m_DeviceProvider.GetAllMatchingDeviceStreams(DeviceUsages.RightHanded, mustSatisfyAll: true);
                SetCursorsActive(enableDevices, true);
                SetCursorsActive(disableDevices, false);
            });
            m_RightOnlyButton.onClick.AddListener(() =>
            {
                IEnumerable<DeviceStream> enableDevices =
                    m_DeviceProvider.GetAllMatchingDeviceStreams(DeviceUsages.RightHanded, mustSatisfyAll: true);
                IEnumerable<DeviceStream> disableDevices =
                    m_DeviceProvider.GetAllMatchingDeviceStreams(DeviceUsages.LeftHanded, mustSatisfyAll: true);
                SetCursorsActive(enableDevices, true);
                SetCursorsActive(disableDevices, false);
            });
            m_AllTogetherButton.onClick.AddListener(() =>
            {
                IEnumerable<DeviceStream> enableDevices =
                    m_DeviceProvider.GetAllMatchingDeviceStreams(DeviceUsages.LeftHanded | DeviceUsages.RightHanded,
                        mustSatisfyAll: false);
                SetCursorsActive(enableDevices, true);
            });
        }

        #endregion Unity methods

        #region Private Methods

        private void SetCursorsActive(IEnumerable<DeviceStream> devices, bool active)
        {
            foreach (DeviceStream device in devices)
            {
                device.gameObject.SetActive(active);
            }
        }

        #endregion
    }
}
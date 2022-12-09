using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CinemachineObject
{
    [field: SerializeField] public bool Enabled { get; set; }
    [field: SerializeField] public int Priority { get; set; } = 0;
   // [field: SerializeField] public string CameraName { get; set; }
    [field: SerializeField] public CinemachineVirtualCameraBase VirtualCamera { get; set; }
}

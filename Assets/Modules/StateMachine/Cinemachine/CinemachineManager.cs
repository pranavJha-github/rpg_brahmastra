using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

[ExecuteInEditMode]
public class CinemachineManager : MonoBehaviour
{
    public bool UpdateHere = false;
    [field: SerializeField] public Transform VirtualCamerasParent { get; private set; }
    [field: SerializeField] public CinemachineVirtualCameraBase DefaultCamera { get; private set; }
    [field: SerializeField] public List <CinemachineObject> VirtualCameras { get; private set; }

    public enum priority { Inactive=0, Default = 10, Active = 100}
    void OnEnable()
    {
        VirtualCameras.Clear();
        foreach (Transform child in VirtualCamerasParent)
        {
            child.gameObject.TryGetComponent<CinemachineVirtualCameraBase>(out CinemachineVirtualCameraBase temporaryCamera);
            if (temporaryCamera)
            {
                CinemachineObject cinemachineObject = new CinemachineObject
                {
                    Enabled = temporaryCamera.enabled,
                    Priority = temporaryCamera.Priority,
                    //CameraName = temporaryCamera.name,
                    VirtualCamera = temporaryCamera
                };

                VirtualCameras.Add(cinemachineObject);

            }
            
        }
    }

        // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (UpdateHere) {
            foreach (var cinemachineObject in VirtualCameras)
            {
                cinemachineObject.Enabled = cinemachineObject.VirtualCamera.enabled;
                cinemachineObject.Priority = cinemachineObject.VirtualCamera.Priority;
            }

        }
    }

    private void OnValidate()
    {
        foreach (var cinemachineObject in VirtualCameras)
        {
            cinemachineObject.VirtualCamera.enabled = cinemachineObject.Enabled;
            cinemachineObject.VirtualCamera.Priority = cinemachineObject.Priority;
        }
    }

    public void SetActiveCamera(string cameraName)
    {
        foreach (var cinemachineObject in VirtualCameras)
        {
            if (cameraName == cinemachineObject.VirtualCamera.Name)
            {
                cinemachineObject.VirtualCamera.enabled = true;
                cinemachineObject.VirtualCamera.Priority = (int)priority.Active;
            }
            else
            {
                //cinemachineObject.VirtualCamera.enabled = false;
                if (DefaultCamera == cinemachineObject.VirtualCamera)
                {
                    cinemachineObject.VirtualCamera.Priority = (int)priority.Default;
                }
                else
                {
                    cinemachineObject.VirtualCamera.Priority = (int)priority.Inactive;
                }
            }
        }
    }
}

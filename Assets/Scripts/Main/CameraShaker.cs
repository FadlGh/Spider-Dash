using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    [SerializeField] private float shakeMagnitude;
    [SerializeField] private float shakeTime;

    public void ShakeIt()
    {
        InvokeRepeating("StartCameraShaking", 0f, 0.005f);
        Invoke("StopCameraShaking", shakeTime);
    }

    private void StartCameraShaking()
    {
        float camerashakingOffsetX = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        float camerashakingOffsetY = Random.value * shakeMagnitude * 2 - shakeMagnitude;
        Vector3 cameraIntermadiatePosition = transform.position;
        cameraIntermadiatePosition.x += camerashakingOffsetX;
        cameraIntermadiatePosition.y += camerashakingOffsetY;
        transform.position = cameraIntermadiatePosition;
    }

    private void StopCameraShaking()
    {
        CancelInvoke("StartCameraShaking");
    }
}

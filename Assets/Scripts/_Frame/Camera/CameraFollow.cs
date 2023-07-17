using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] GameObject follower;

    [SerializeField] float moveSpeed = 40;

    [SerializeField] float verticalRotateSpeed = 40;

    [SerializeField] float horizontalRotateSpeed = 40; 

    [SerializeField] Interval pitchAngleLimit;

    [SerializeField] Interval depthLimit;

    private Transform upDownTransfrom;

    private Transform frontBackTransfrom;

    private void Awake()
    {
        upDownTransfrom = transform.GetChild(0);
        frontBackTransfrom = upDownTransfrom.GetChild(0);
    }

    private void OnEnable()
    {
        //InputController.Inst.GamePlayInput.OnMouseWheelScroll += MoveCameraDeep;
        //InputController.Inst.GamePlayInput.OnMouseMove += RotateCamera;
        //InputController.Inst.SwitchInput(InputController.Inst.GamePlayInput);
    }

    private void OnDisable()
    {
        //InputController.Inst.GamePlayInput.OnMouseWheelScroll -= MoveCameraDeep;
        //InputController.Inst.GamePlayInput.OnMouseMove -= RotateCamera;
    }

    private void LateUpdate()
    {
        transform.position = follower.transform.position;
    }

    

    private void RotateCamera(Vector2 distance)
    {
        RotateHorizontal(distance.x);
        RotateVertical(-distance.y);
    }

    private void RotateHorizontal(float y)
    {
        Vector3 newEulerAngle = transform.localEulerAngles;
        newEulerAngle.y += y * Time.deltaTime * horizontalRotateSpeed;
        transform.localEulerAngles = newEulerAngle;
    }

    private void RotateVertical(float x)
    {
        //Debug.Log(x);
        Vector3 newEulerAngle = upDownTransfrom.localEulerAngles;
        newEulerAngle.x = pitchAngleLimit.Clamp(GetAngel(newEulerAngle.x + x * Time.deltaTime * verticalRotateSpeed));
        upDownTransfrom.localEulerAngles = newEulerAngle;
    }

    private void MoveCameraDeep(float scrollSpeed)
    {
        Vector3 direction = scrollSpeed > 0 ? Vector3.forward : Vector3.back;
        Vector3 newPosition = frontBackTransfrom.localPosition + moveSpeed * Time.deltaTime * direction;
        newPosition.z = depthLimit.Clamp(newPosition.z);
        frontBackTransfrom.localPosition = newPosition;
    }

    private float GetAngel(float value)
    {
        return value > 180 ? value - 360 : value;
    }
}

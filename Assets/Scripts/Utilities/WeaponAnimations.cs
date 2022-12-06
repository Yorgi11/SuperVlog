using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimations : MonoBehaviour
{
    [SerializeField] Transform Model;
    [SerializeField] Transform SwayTarget;

    private float t;

    private Vector3 currentRotation;
    private Vector3 currentPosition;
    private Vector3 targetRotation;
    private Vector3 targetPosition;

    private Vector3 currentImpulse;

    private Quaternion quat1;

    private Gun gun;
    private void Start()
    {
        gun = GetComponent<Gun>();
        SwayTarget.localPosition = new Vector3(0f, 0f, 2f);
    }
    public void Recoil(float recoilx, float recoily, float recoilz)
    {
        currentImpulse = new(-recoilx,recoily,recoilz);
        targetRotation += currentImpulse;
        currentRotation = Vector3.Slerp(currentRotation, targetRotation, gun.GetSnappiness() * Time.deltaTime);
        currentPosition = Vector3.Slerp(currentPosition, targetPosition, gun.GetSnappiness() * Time.deltaTime);
        Model.localRotation = Quaternion.Euler(currentRotation) * quat1;
        Model.localPosition = currentPosition;
    }
    public void ADS(Vector3 newPos, Vector3 newRot)
    {
        targetRotation = Vector3.Lerp(targetRotation, newRot, gun.GetAdsSpeed() * Time.deltaTime);
        targetPosition = Vector3.Lerp(targetPosition, newPos, gun.GetAdsSpeed() * Time.deltaTime);
    }
    public void IdleSway(float idlex, float idley, float idleSwaySpeed)
    {
        t += idleSwaySpeed * Time.deltaTime * 0.1f;
        transform.forward = (SwayTarget.transform.position - transform.position).normalized;
        SwayTarget.transform.localPosition = new(-Mathf.Sin(14 * Mathf.PI * t) * idlex, Mathf.Cos(21 * Mathf.PI * t)* idley, 1f);
    }
    public void LookSway(float smooth, float swayMultiplier)
    {
        quat1 = Quaternion.Slerp(quat1, (Quaternion.AngleAxis(-Input.GetAxisRaw("Mouse Y") * swayMultiplier, Vector3.right) * Quaternion.AngleAxis(Input.GetAxisRaw("Mouse X") * swayMultiplier, Vector3.up)), smooth * Time.deltaTime);
    }
    public Vector3 GetCurrentRotation()
    {
        return currentImpulse;
    }
}

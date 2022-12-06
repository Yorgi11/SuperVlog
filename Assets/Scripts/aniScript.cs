using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aniScript : MonoBehaviour
{
    [SerializeField] private float animationSpeed;
    [SerializeField] private float adsSpeed;

    [SerializeField] private float recX;
    [SerializeField] private float recY;
    [SerializeField] private float recZ;

    [SerializeField] private float idlx;
    [SerializeField] private float idly;
    [SerializeField] private float idlz;

    // pos
    [SerializeField] private Vector3 hipPos;
    [SerializeField] private Vector3 aimPos;
    // rot
    [SerializeField] private Vector3 hipRot;
    [SerializeField] private Vector3 aimRot;

    [SerializeField] private GameObject model;
    [SerializeField] private GameObject swayTarget;// empty game object not a child of the model slightly infront of the gun barrel when in the aiming position

    private float t = 0;

    // pos
    private Vector3 targetPos;
    private Vector3 currentPos;
    // rot
    private Vector3 targetRot;
    private Vector3 currentRot;
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1)) ADS(aimPos, aimRot);
        else ADS(hipPos, hipRot);

        if (Input.GetKey(KeyCode.Mouse0)) Recoil(recX, recY, recZ);
        else Recoil(0, 0, 0);

        IdleSway(idlx, idly, idlz);
    }

    public void Recoil(float recoilx, float recoily, float recoilz)
    {
        targetRot += new Vector3(-recoilx, recoily, recoilz);
        currentPos = Vector3.Slerp(currentPos, targetPos, animationSpeed * Time.deltaTime);
        currentRot = Vector3.Slerp(currentRot, targetRot, animationSpeed * Time.deltaTime);
        model.transform.localPosition = currentPos;
        model.transform.localRotation = Quaternion.Euler(currentRot);
    }

    public void ADS(Vector3 newPos, Vector3 newRot)
    {
        targetPos = Vector3.Lerp(targetPos, newPos, adsSpeed * Time.deltaTime);
        targetRot = Vector3.Lerp(targetRot, newRot, adsSpeed * Time.deltaTime);
    }

    public void IdleSway(float idlex, float idley, float idleSpeed)
    {
        t += idleSpeed * Time.deltaTime * 0.1f;
        model.transform.forward = (swayTarget.transform.position - model.transform.position).normalized;
        swayTarget.transform.localPosition = new(-Mathf.Sin(14 * Mathf.PI * t) * idlex, Mathf.Cos(21 * Mathf.PI * t) * idley, 1f);
    }
}

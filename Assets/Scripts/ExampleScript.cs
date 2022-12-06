using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    float result;
    float startVal = 0f;
    float endVal = 100f;

    Vector3 vecResult;
    Vector3 startvec = Vector3.zero;
    Vector3 endVec = Vector3.one * 10f;

    Quaternion quatResult;
    Quaternion startQuat = Quaternion.identity;
    Quaternion endQuat = Quaternion.Euler(Vector3.right);
    void Update()
    {
        // Lerp
        // fixed percentage
        result = Mathf.Lerp(startVal, endVal, 0.5f);
        vecResult = Vector3.Lerp(startvec, endVec, 0.5f);
        quatResult = Quaternion.Lerp(startQuat, endQuat, 0.5f);

        // time based percentage
        result = Mathf.Lerp(startVal, endVal, 1f * Time.deltaTime);
        vecResult = Vector3.Lerp(startvec, endVec, 1f * Time.deltaTime);
        quatResult = Quaternion.Lerp(startQuat, endQuat, 1f * Time.deltaTime);

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        // Slerp
        // fixed percentage
        vecResult = Vector3.Slerp(startvec, endVec, 0.5f);
        quatResult = Quaternion.Slerp(startQuat, endQuat, 0.5f);

        // time based percentage
        vecResult = Vector3.Slerp(startvec, endVec, 1f * Time.deltaTime);
        quatResult = Quaternion.Slerp(startQuat, endQuat, 1f * Time.deltaTime);
    }
}

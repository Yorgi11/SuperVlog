using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Gun[] guns;

    private Gun currentGun;
    void Start()
    {
        currentGun = guns[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Gun GetCurrentGun()
    {
        return currentGun;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    [SerializeField]
    private GameObject player = null;


    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 vector3 = new Vector3();
        vector3.x = player.transform.position.x;
        vector3.y = player.transform.position.y;
        vector3.z = -10;

        transform.position = vector3;
    }
}

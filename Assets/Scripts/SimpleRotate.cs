using UnityEngine;
using System.Collections;

public class SimpleRotate : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(Vector3.forward * Random.RandomRange(10, 100) * Time.deltaTime, Space.World);

    }
}


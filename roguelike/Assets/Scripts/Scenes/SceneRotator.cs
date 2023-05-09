using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneRotator : MonoBehaviour
{
    public float rotationSpeed = 10f;

    void Update()
    {
        float rotation = rotationSpeed * Time.deltaTime;
        transform.Rotate(0, 0, rotation);
    }
}

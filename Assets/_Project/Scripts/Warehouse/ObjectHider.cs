using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHider : MonoBehaviour
{
    void Start()
    {
        if (TryGetComponent<MeshRenderer>(out MeshRenderer renderer))
        {
            renderer.enabled = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectZombie : MonoBehaviour
{
    public void ChangeMaterial(Material material)
    {
        GetComponent<MeshRenderer>().material = material;
    }
}

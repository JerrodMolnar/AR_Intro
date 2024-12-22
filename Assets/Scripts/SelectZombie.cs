using UnityEngine;

public class SelectZombie : MonoBehaviour
{
    public void ChangeMaterial(Material material)
    {
        GetComponent<MeshRenderer>().material = material;
    }
}

using UnityEngine;

public class BarrierScript : MonoBehaviour
{
    void Start()
    {
        // Automatically find and disable the mesh renderer to make the 3D object invisible
        MeshRenderer mesh = GetComponent<MeshRenderer>();

        if (mesh != null)
        {
            mesh.enabled = false;
        }
    }
}

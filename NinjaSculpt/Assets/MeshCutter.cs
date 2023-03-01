using UnityEngine;

public class CutMesh : MonoBehaviour
{
    public GameObject cuttingPlane;
    public Material cutMaterial;

    private bool isCutting = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isCutting = true;
        }
    }

    void FixedUpdate()
    {
        if (isCutting)
        {
            // Get the mesh to cut
            Mesh meshToCut = GetComponent<MeshFilter>().mesh;

            // Create the cutting plane
            Plane plane = new Plane(cuttingPlane.transform.up, cuttingPlane.transform.position);

            // Split the mesh
            Mesh[] meshes = meshToCut.Split(plane);

            // Create two new game objects to represent the two halves of the mesh
            GameObject leftHalf = new GameObject("Left Half");
            leftHalf.transform.position = transform.position;
            leftHalf.transform.rotation = transform.rotation;
            leftHalf.AddComponent<MeshFilter>().mesh = meshes[0];
            leftHalf.AddComponent<MeshRenderer>().material = cutMaterial;

            GameObject rightHalf = new GameObject("Right Half");
            rightHalf.transform.position = transform.position;
            rightHalf.transform.rotation = transform.rotation;
            rightHalf.AddComponent<MeshFilter>().mesh = meshes[1];
            rightHalf.AddComponent<MeshRenderer>().material = cutMaterial;

            // Destroy the original game object
            Destroy(gameObject);

            isCutting = false;
        }
    }
}

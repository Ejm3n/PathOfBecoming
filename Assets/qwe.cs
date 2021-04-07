using UnityEngine;

public class qwe : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;

    void Update()
    {
        Debug.DrawRay(transform.position, Vector3.forward * 10f, Color.red, 100000);
        if (Physics.Raycast(transform.position, Vector3.forward * 10f, 1000f, layerMask))
        {
            Debug.Log(transform.gameObject.layer);
            Debug.Log("tyt");
        }
        else
        {
            Debug.Log(transform.gameObject.layer);
            Debug.Log("ne tyt");
        }

    }
}

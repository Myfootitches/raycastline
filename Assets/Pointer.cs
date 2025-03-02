using UnityEngine;

public class Pointer : MonoBehaviour
{
    public LineRenderer linea;

    void Start()
    {
        linea = GetComponent<LineRenderer>();

    }

    void Update()
    {

        RaycastHit hit;

        Vector3 origin = transform.position + transform.forward;
        Vector3 direction = transform.forward;

        Vector3 p1 = transform.position + transform.forward;
        Vector3 p2 = transform.position + transform.forward * 3f;

        Vector3[] positions = new Vector3[2];

        positions[0] = p1;
        positions[1] = p2;

        if (Physics.Raycast(origin, direction, out hit, 25f))
        {
            positions[1] = hit.point;

            Debug.DrawRay(origin, direction * hit.distance, Color.green);

            linea.startColor = Color.cyan;
            linea.endColor = Color.red;
        }
        else
        {
            positions[1] = origin + direction * 15f;

            Debug.DrawRay(origin, direction * 15f, Color.red);

            linea.startColor = Color.white;
            linea.endColor = Color.yellow;
        }
        linea.SetPositions(positions);
    }
}
using UnityEngine;

public class GetMousePosition : MonoBehaviour
{
    public Vector3 MousePositionVector;
    public void GetMousePositionVector()
    {
        RaycastHit raycastHit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out raycastHit))
            MousePositionVector = raycastHit.point;
    }
}

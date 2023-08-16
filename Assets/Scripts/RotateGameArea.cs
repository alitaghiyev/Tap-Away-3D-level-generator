using UnityEngine;

public class RotateGameArea : MonoBehaviour
{
    public static bool rotateBool;
    [SerializeField] private float rotatespeed;
    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            rotateBool = false;
        }
        if(Input.GetMouseButton(0))
        {
            RotateArea();
        }
        if(Input.GetMouseButtonUp(0))
        {
            rotateBool = false;
        }
        
    }
    private void RotateArea()
    {
        float rotx = Input.GetAxis("Mouse X") * rotatespeed * Mathf.Deg2Rad * Time.deltaTime;
        float roty = Input.GetAxis("Mouse Y") * rotatespeed * Mathf.Deg2Rad * Time.deltaTime;
        if (Mathf.Abs(roty) >= 0.06f || Mathf.Abs(rotx) >= 0.06f)
        {
            rotateBool = true;
            transform.Rotate(Vector3.up, -rotx, Space.World);
            transform.Rotate(Vector3.right, roty, Space.World);
        }
    }
}

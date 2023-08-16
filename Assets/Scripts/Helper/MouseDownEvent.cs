using UnityEngine;
using UnityEngine.Events;
 
public class MouseDownEvent : MonoBehaviour
{
    [SerializeField] private UnityEvent<GameObject> OnMouseDownEventTriggered;
    [SerializeField] private GameObject mycube;
    private void OnMouseUp()
    {
        if(RotateGameArea.rotateBool == false)
            OnMouseDownEventTriggered?.Invoke(mycube);
    }
}

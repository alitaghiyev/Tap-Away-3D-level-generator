using UnityEngine;
public class CubeDirectionControl : MonoBehaviour
{
    [HideInInspector] public int cubeId;
    [HideInInspector] public bool lockCubeBool;
    [HideInInspector] public bool alreadyControled;

    //public bool ControlLineObjects()//false is locked
    //{
    //    RaycastHit[] hits;
    //    hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);
    //    for (int i = 0; i < hits.Length; i++)
    //    {
    //        RaycastHit hit = hits[i];
    //        if (hit.transform.gameObject.name == RayObjectname)
    //        {
    //            return false;
    //        }
    //    }
    //    return true;
    //}

    public bool ControlLoopLock(int FirstCubeId, bool isFirst) // false is locked 
    {
        lockCubeBool = true;
        if (isFirst == false && FirstCubeId == cubeId)//id geri döndüyse 
        {
            lockCubeBool = false;
        }
        RaycastHit[] hits;
        if (alreadyControled == false)
        {
            alreadyControled = true;
            hits = Physics.RaycastAll(transform.position, transform.forward, 100.0F);
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit = hits[i];
                if (hit.transform.TryGetComponent(out CubeDirectionControl hitobs) && hit.transform.gameObject != gameObject)
                {
                    lockCubeBool = hitobs.ControlLoopLock(FirstCubeId, false);
                    if (lockCubeBool == false)
                    {
                        break;
                    }
                    if (lockCubeBool == true)
                        continue;
                }
                else
                {
                    lockCubeBool = true;
                }
            }
        }
        return lockCubeBool;
    }

    public void ClearAllVariable()
    {
        lockCubeBool = false;
        alreadyControled = false;
    }
}

using System.Collections;
using UnityEngine;

public class AutoSolution : MonoBehaviour
{
    public GameObject GameArea;
    IEnumerator autoClickCoroutine;
    bool stopBool;
    public void Autoclick()
    {
        stopBool = true;
        autoClickCoroutine = StartAutoClick();
        StartCoroutine(autoClickCoroutine);
    }
    public void StopAutoClick()
    {
        stopBool = false;
        StopCoroutine(autoClickCoroutine);
    }
    public IEnumerator StartAutoClick()
    {
        foreach (Transform i in GameArea.transform)
        {
            yield return new WaitForSeconds(0f);
            i.GetComponent<CubeManager>().MoveCube();
            if (stopBool == false)
                break;
        }
        if (GameArea.transform.childCount > 0 && stopBool == true)
        {
            StartCoroutine(StartAutoClick());
        }
    }
}

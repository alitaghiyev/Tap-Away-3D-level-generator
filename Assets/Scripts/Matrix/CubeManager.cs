using UnityEngine;
using DG.Tweening;
using System.Collections;

public class CubeManager : MonoBehaviour
{
    [SerializeField] private CubeDataSO cubeData;
    Material mat => GetComponent<Renderer>().material;

    private void Update()
    {
        DrawRaycast();
    }

    public void MoveCube()
    {
        Vector3 raycastStartPoint = transform.position;
        Vector3 raycastDirection = transform.forward;

        Ray ray = new Ray(raycastStartPoint, raycastDirection);

        if (Physics.Raycast(ray, out RaycastHit hit, cubeData.raycastDistance))
        {
            WrongClick();
        }
        else
        {
            CorrectClick();
        }
    }
    void CorrectClick()
    {
        EventManager.instance.CorrectClick?.Invoke();
        GetComponent<Collider>().enabled = false;
        gameObject.transform.parent = null;
        gameObject.transform.DOMove(transform.position + transform.forward * cubeData.moveOffsets, cubeData.moveTime).OnComplete(() =>
        gameObject.transform.DOScale(new Vector3(0, 0, 0), 1).OnComplete(() =>
        Destroy(gameObject)));
    }
    void WrongClick()
    {
        EventManager.instance.WrongClick?.Invoke();
        StopCoroutine(resetCoroutine);
        transform.DOShakePosition(cubeData.shakeDuration,cubeData.shakeStrength);
        mat.color = cubeData.WrongColor;
        StartCoroutine(resetCoroutine);
    }

    IEnumerator resetCoroutine => ResetDelay();
    IEnumerator ResetDelay()
    {
        yield return cubeData.WrongColorDuration;
        mat.color = cubeData.DefaultColor;
    }


    private void DrawRaycast()
    {
        Vector3 raycastStartPoint = transform.position;
        Vector3 raycastDirection = transform.forward;
        Ray ray = new Ray(raycastStartPoint, raycastDirection);
        if (Physics.Raycast(ray, out RaycastHit hit, cubeData.raycastDistance))
        {
            Debug.DrawRay(raycastStartPoint, raycastDirection * hit.distance, Color.red);
        }
        else
        {
            Debug.DrawRay(raycastStartPoint, raycastDirection * cubeData.raycastDistance, Color.green);
        }
    }
}

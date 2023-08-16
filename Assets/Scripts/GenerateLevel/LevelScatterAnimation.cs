using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System.Linq;

public class LevelScatterAnimation : MonoBehaviour
{
    [SerializeField] private bool Animated = false;
    [SerializeField] private float radius = 50;
    [SerializeField] private float duration; // Gather animation duration
    [SerializeField] private Transform GameAreaPivot;

    Dictionary<Transform, Vector3> DefaultPositions = new();
    public void SaveDefaultValue()
    {
        if (!Animated) return;
        foreach (Transform cube in GameAreaPivot.transform)
        {
            DefaultPositions.Add(cube,cube.localPosition);
        }
        StartScatter();
    }

    public void StartScatter() => StartCoroutine(ScatterCubes());
    private IEnumerator ScatterCubes()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < DefaultPositions.Count; i++)
        {
            var item = DefaultPositions.ElementAt(i);
            Vector3 pos = GetCirclePosition(item.Value);
            item.Key.localPosition = pos;
        }
        StartGather();
    }

    private Vector3 GetCirclePosition(Vector3 originalPos)
    {
        float angle = Random.Range(0f, 360f) * Mathf.Deg2Rad;
        float x = Mathf.Sin(angle) * radius + originalPos.x;
        float y = Mathf.Cos(angle) * radius + originalPos.y;
        float z = originalPos.z;
        return new Vector3(x, y, z);
    }

    public void StartGather() => StartCoroutine(GatherCubes());
    private IEnumerator GatherCubes()
    {
        yield return new WaitForSeconds(1f);
        for (int i = 0; i < DefaultPositions.Count; i++)
        {
            var item = DefaultPositions.ElementAt(i);
            item.Key.DOLocalMove(item.Value, duration);
        }

    }
}

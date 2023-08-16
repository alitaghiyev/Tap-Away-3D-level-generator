using UnityEngine;

[CreateAssetMenu(fileName = "CubeData", menuName = "NewCubeData", order = 0)]
public class CubeDataSO : ScriptableObject
{
    [Header("Cube Movement")]
    public float moveTime;
    public float moveOffsets;

    [Header("Raycast Settings")]
    public float raycastDistance;
    public float shakeStrength;
    public float shakeDuration;

    [Header("Click Settings")]
    public Color DefaultColor = Color.white;
    public Color WrongColor = Color.red;
    public WaitForSeconds WrongColorDuration = new WaitForSeconds(.5f);
}

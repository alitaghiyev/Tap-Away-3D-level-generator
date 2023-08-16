using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelGenerate : MonoBehaviour
{
    public static int TotalCubeCount;
    public int length;
    public int weight;
    public int height;
    [SerializeField] private bool RandomValue;
    [SerializeField] private float MatrixSpace;
    [SerializeField] private GameObject CubePrefab;
    [SerializeField] private Transform GameAreaPivot;


    GameObject NewCubeObject;
    int currentDirectionIndex;


    Vector3[] possibleDirections = new Vector3[6]
    {
        new Vector3(0,90,0),
        new Vector3(0,-90,0),
        new Vector3(-90,0,0),
        new Vector3(90,0,0),
        new Vector3(0,0,0),
        new Vector3(0,180,0)
    };

    WaitForSeconds ControlCoolDown = new WaitForSeconds(0.02f);//min 0.02

    private void Awake()
    {
        CalculateRandomMatrixValue();
        TotalCubeCount = length * height * weight;
    }

    void Start()
    {
        CalcuLatePivotPoint();
        StartCoroutine(GenerateLevel());
    }
    private void CalculateRandomMatrixValue()
    {
        if (!RandomValue) return;
        length = Random.Range(2, 8);
        weight = Random.Range(2, 8);
        height = Random.Range(2, 8);
    }
    private void CalcuLatePivotPoint()
    {
        float pivot_x = (length - 1) * MatrixSpace / 2;
        float pivot_y = (height - 1) * MatrixSpace / 2;
        float pivot_z = (weight - 1) * MatrixSpace / 2;
        GameAreaPivot.transform.position = new Vector3(-pivot_x, -pivot_y, -pivot_z);
    }
    private IEnumerator GenerateLevel()
    {
        yield return new WaitForSeconds(1f);
        int id = 0;
        for (int h = 0; h < height; h++)//Y
        {
            for (int w = 0; w < weight; w++)//Z
            {
                for (int l = 0; l < length; l++) //X
                {
                    ClearCubeVariable();
                    currentDirectionIndex = Random.Range(0, possibleDirections.Length);
                    Vector3 spawnPosition = new Vector3(l * MatrixSpace, h * MatrixSpace, w * MatrixSpace);
                    Vector3 spawnRotation = possibleDirections[currentDirectionIndex];
                    NewCubeObject = Instantiate(CubePrefab, GameAreaPivot.transform);
                    NewCubeObject.transform.localPosition = spawnPosition;
                    NewCubeObject.transform.localEulerAngles = spawnRotation;
                    id++;
                    CubeDirectionControl directionControl = NewCubeObject.GetComponent<CubeDirectionControl>();
                    directionControl.cubeId = id;
                    yield return ControlCoolDown;
                    bool lockBool = directionControl.ControlLoopLock(id, true);
                    if (lockBool == false)
                    {
                        Destroy(NewCubeObject);
                        l--;
                        id--;
                    }
                }
            }
        }
        EventManager.instance.CompleteLevelGeneration?.Invoke();
    }

    void ClearCubeVariable()
    {
        foreach (Transform cube in GameAreaPivot.transform)
        {
            cube.GetComponent<CubeDirectionControl>().ClearAllVariable();
        }
    }

    public void GenerateNewLevel()//generate button
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

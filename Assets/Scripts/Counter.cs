using UnityEngine;
using TMPro;
public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text WrongClickText;
    [SerializeField] private TMP_Text CorrectClickText;
    [SerializeField] private TMP_Text CubeCountText;
    [SerializeField] private TMP_Text TotalClickedCountText;



    private void Start()
    {
        CubeCountText.SetText(LevelGenerate.TotalCubeCount.ToString());
    }

    private int totalClickedCube = 0;
    public int TotalClickedCube
    {
        get
        {
            return totalClickedCube;
        }
        set
        {
            totalClickedCube++;
            TotalClickedCountText.SetText(totalClickedCube.ToString());
        }
    }

    private int wrongClick = 0;
    public int WrongClick
    {
        get
        {
            return wrongClick;
        }
        set
        {
            wrongClick++;
            WrongClickText.SetText(wrongClick.ToString());
        }
    }

    private int correctClick = 0;
    public int CorrectClick
    {
        get
        {
            return correctClick;
        }
        set
        {
            correctClick++;
            CorrectClickText.SetText(correctClick.ToString());
        }
    }
}

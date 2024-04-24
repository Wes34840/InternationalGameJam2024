using UnityEngine;
using UnityEngine.UI;

public class EndPointScript : MonoBehaviour
{
    private float _progress;
    [SerializeField] private Slider _slider;
    private void Start()
    {
    }
    private void Update()
    {
        if (_progress > 0)
        {
            _slider.transform.GetChild(1).GetComponentInChildren<Image>().color = new Color(1, 0, 0, 1);
        }

        if (_progress == _slider.maxValue)
        {
            LaserScript.gameIsActive = false;
            Debug.Log("WinGame");
        }
    }

    public void AddToProgress(float increase)
    {
        _progress += increase;
        _slider.value = _progress;
    }

}

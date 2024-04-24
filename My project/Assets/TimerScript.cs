using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    private Slider _slider;
    void Start()
    {
        _slider = GetComponent<Slider>();
    }

    void Update()
    {
        if (LaserScript.gameIsActive)
        {
            _slider.value += Time.deltaTime;
        }
        if (_slider.value == 25)
        {
            Debug.Log("Lost");
            LaserScript.gameIsActive = false;
        }
    }
}

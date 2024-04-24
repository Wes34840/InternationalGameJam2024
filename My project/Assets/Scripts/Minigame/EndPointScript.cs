using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndPointScript : MonoBehaviour
{
    public string scene;
    private float _progress;
    [SerializeField] private Slider _slider;
    private void Update()
    {
        if (_progress > 0)
        {
            _slider.transform.GetChild(1).GetComponentInChildren<Image>().color = new Color(1, 0, 0, 1);
        }

        if (_progress == _slider.maxValue)
        {
            LaserScript.gameIsActive = false;

            LoadNewLevel();
        }
    }

    public void AddToProgress(float increase)
    {
        _progress += increase;
        _slider.value = _progress;
    }

    public void LoadNewLevel()
    {
        SceneManager.LoadScene(scene);
    }

}

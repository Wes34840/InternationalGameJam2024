using UnityEngine;
using UnityEngine.UI;

public class PlayerSanity : MonoBehaviour
{
    public float maxSanity;
    public static float sanity;
    [SerializeField] private float _decayRate;
    [SerializeField] private Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        sanity = maxSanity;
        _slider.maxValue = sanity;
        _slider.value = sanity;
    }

    // Update is called once per frame
    void Update()
    {
        Mathf.Clamp(sanity, 0, maxSanity);
        sanity -= Time.deltaTime * _decayRate;
        _slider.value = sanity;
        if (sanity <= 0)
        {
            Debug.Log("Dead");
        }
    }
}

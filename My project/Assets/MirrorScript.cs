using UnityEngine;
using UnityEngine.EventSystems;

public class MirrorScript : MonoBehaviour, IPointerDownHandler
{
    private static MirrorScript _currentSelectedMirror;
    [SerializeField] private float _rotateSpeed;
    void Start()
    {

    }

    void Update()
    {

        float horizontalInput = GetPlayerInput() * Time.deltaTime;

        // if the player is not pressing any buttons, it automatically rotates to it's nearest 45 degree angle
        if (horizontalInput == 0 || _currentSelectedMirror != this) transform.parent.eulerAngles = RotateAxisToNearestSide(transform.parent.eulerAngles);

        if (_currentSelectedMirror != this) return;
        Vector3 target = new Vector3(0, horizontalInput * _rotateSpeed, 0);
        transform.parent.eulerAngles += target;

    }

    private float GetPlayerInput()
    {
        return Input.GetAxisRaw("Horizontal");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (_currentSelectedMirror != null)
        {
            _currentSelectedMirror.GetComponentInParent<Renderer>().material.color = new Color(1, 1, 1, 0.6f);
        }
        _currentSelectedMirror = this;
        _currentSelectedMirror.GetComponentInParent<Renderer>().material.color = new Color(0.5f, 0.5f, 0.5f, 0.6f);
    }
    Vector3 RotateAxisToNearestSide(Vector3 eulerAngles)
    {
        Vector3 roundedEulerAngles = RoundToNearest45Degree(eulerAngles);
        return Vector3.Slerp(eulerAngles, roundedEulerAngles, Time.deltaTime * 2f);
    }

    Vector3 RoundToNearest45Degree(Vector3 eulerAngles)
    {
        eulerAngles[1] = Mathf.Round(eulerAngles[1] / 45f) * 45f;
        return eulerAngles;
    }
}

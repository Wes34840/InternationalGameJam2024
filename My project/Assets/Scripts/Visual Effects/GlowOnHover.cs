using TMPro;
using UnityEngine;

public class GlowOnHover : MonoBehaviour
{
    private GameObject _interactableObject;
    public GameObject interactText;
    public CanvasGroup canvasGroup;

    private void Start()
    {

    }
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;



        if (Physics.Raycast(ray, out hit, 30, LayerMask.GetMask("InteractableObject")))
        {
            TMP_Text text = interactText.GetComponent<TMP_Text>();

            canvasGroup.alpha = 1;
            _interactableObject = hit.collider.gameObject;
            _interactableObject.GetComponent<Renderer>().materials[1].SetFloat("_Scale", 1.02f);
            text.text = (hit.collider.name);
            if (Input.GetKeyDown(KeyCode.E))
            {
                hit.collider.GetComponent<InteractableObject>().InteractWithObject();
            }
        }
        else
        {
            canvasGroup.alpha = 0;
            if (_interactableObject == null)
            {
                return;
            }
            _interactableObject.GetComponent<Renderer>().materials[1].SetFloat("_Scale", 1f);
        }



    }
}

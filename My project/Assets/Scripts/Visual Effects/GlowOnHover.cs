using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowOnHover : MonoBehaviour
{
    private GameObject _interactableObject;

    private void Start()
    {
    }
    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;



        if (Physics.Raycast(ray, out hit, 30, LayerMask.GetMask("InteractableObject")))
        {
            Debug.Log("looking at box");
            _interactableObject = hit.collider.gameObject;
            _interactableObject.GetComponent<Renderer>().materials[1].SetFloat("_Scale", 1.02f);
        }
        else
        {
            if(_interactableObject == null)
            {
                return;
            }
            _interactableObject.GetComponent<Renderer>().materials[1].SetFloat("_Scale", 1f);
        }



    }

    private void OnCollisionEnter(Collision collision)
    {

    }
}

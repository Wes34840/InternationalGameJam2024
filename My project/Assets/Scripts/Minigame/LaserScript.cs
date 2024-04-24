using System.Collections.Generic;
using UnityEngine;

public class LaserScript : MonoBehaviour
{

    private Vector3 _pos, _dir;
    private GameObject _laserObject;
    [SerializeField] private LineRenderer _laserRenderer;
    private List<Vector3> _laserIndices = new List<Vector3>();
    public static bool gameIsActive = true;

    void Start()
    {
        _pos = transform.position;
        _dir = transform.forward;
        _laserRenderer = GetComponent<LineRenderer>();
        _laserRenderer.SetPosition(0, transform.position);
    }


    private void Update()
    {
        if (gameIsActive)
        {
            CastRay(_pos, _dir, _laserRenderer);
            return;
        }
        Debug.Log("lost");
    }

    private void CastRay(Vector3 pos, Vector3 dir, LineRenderer laser)
    {
        _laserIndices.Add(pos);

        Ray ray = new Ray(pos, dir);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 30, 1))
        {
            CheckHit(hit, dir, laser);
        }
        else
        {
            _laserIndices.Add(ray.GetPoint(30));
            UpdateLaser();
        }

        _laserIndices.Clear();

    }

    private void CheckHit(RaycastHit hitInfo, Vector3 oldDir, LineRenderer laserRenderer)
    {
        if (hitInfo.collider.CompareTag("Mirror"))
        {
            Vector3 pos = hitInfo.point;
            Vector3 newDir = Vector3.Reflect(oldDir, hitInfo.normal);
            CastRay(pos, newDir, laserRenderer);
        }
        else
        {
            if (hitInfo.collider.CompareTag("EndPoint"))
            {
                _laserIndices.Add(hitInfo.point);
                hitInfo.collider.GetComponent<EndPointScript>().AddToProgress(Time.deltaTime);
            }
            UpdateLaser();
        }
    }
    private void UpdateLaser()
    {
        int count = 0;
        _laserRenderer.positionCount = _laserIndices.Count;

        foreach (Vector3 index in _laserIndices)
        {
            _laserRenderer.SetPosition(count, index);
            count++;
        }
    }


}

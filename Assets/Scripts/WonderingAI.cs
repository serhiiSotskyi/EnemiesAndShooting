using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonderingAI : MonoBehaviour
{
    [SerializeField] private GameObject fireBallPrefab;
    private GameObject _fireBall;
    public float speed = 20f;
    public float obstangleRange = 5f;

    private bool _alive;

    private void Start()
    {
        _alive = true;
    }

    void Update()
    {
        if(_alive)
           transform.Translate(0, 0, speed * Time.deltaTime);

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        if(Physics.SphereCast(ray, 0.75f, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;
            if (hitObject.GetComponent<PlayerCharacter>())
            {
                if(_fireBall == null)
                {
                    _fireBall = Instantiate(fireBallPrefab) as GameObject;
                    _fireBall.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                    _fireBall.transform.rotation = transform.rotation;
                }
            }
            else if(hit.distance < obstangleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }
    }

    public void SetAlive(bool alive)
    {
        _alive = alive;
    }
}

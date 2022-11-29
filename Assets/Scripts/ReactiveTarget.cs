using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    
   public void ReactToHit()
    {
        WonderingAI behavour = GetComponent<WonderingAI>();
        if(behavour != null)
        {
            behavour.SetAlive(false);
        }
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);
        yield return new WaitForSeconds(1.5f);

        Destroy(this.gameObject);
    }
}

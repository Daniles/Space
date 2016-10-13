using UnityEngine;
using System.Collections;

public class DefenseHelper : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D colliderEnter)
    {
        if (colliderEnter.gameObject.GetComponent<BallController>())
        {
            Destroy(colliderEnter.gameObject);
            Destroy(gameObject);
        }
    }

}

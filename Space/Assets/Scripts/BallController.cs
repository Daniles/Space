using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    public float flySpeed = 5;
    public float angle = 0;
    public float damage = 0;

    public bool player = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    transform.position = Vector3.MoveTowards(transform.position, new Vector3( // Движение под определенным углом
            transform.position.x + Mathf.Sin(angle), 
            transform.position.y + Mathf.Cos(angle), 
            transform.position.z), Time.deltaTime * flySpeed);
    }
}

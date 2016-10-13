using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerContoller : MonoBehaviour {

    public float speed = 1f;
    public GameObject subtractHelperPrefab;
    private GameObject subtractHelper;
    public GameObject HealthText;
    public float Health = 100f;

    public GameObject GameResult;
    void Start ()
    {
        subtractHelper = Instantiate(subtractHelperPrefab, Camera.main.WorldToScreenPoint(transform.position), Quaternion.identity) as GameObject;
        subtractHelper.transform.SetParent(GameObject.Find("Canvas").transform, true);
        subtractHelper.GetComponent<Text>().color = new Color(subtractHelper.GetComponent<Text>().color.r, subtractHelper.GetComponent<Text>().color.g, subtractHelper.GetComponent<Text>().color.b, 0);
        HealthText.GetComponent<Text>().text = Health.ToString();
    }
	
    void FixedUpdate()
    {
        Move(Input.GetAxis("Horizontal"));
        subtractHelper.transform.position = Camera.main.WorldToScreenPoint(transform.position);
        if (subtractHelper.GetComponent<Text>().color.a > 0) // изменение прозрачности текста с отнятым хп
        {
            subtractHelper.GetComponent<Text>().color = new Color(subtractHelper.GetComponent<Text>().color.r, subtractHelper.GetComponent<Text>().color.g, subtractHelper.GetComponent<Text>().color.b, subtractHelper.GetComponent<Text>().color.a - 0.01f);
        }
    }

    private void Move(float direction)
    {
        transform.position = new Vector3(transform.position.x + direction*speed, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D colliderEnter)
    {
        if (colliderEnter.gameObject.GetComponent<BallController>() && !colliderEnter.gameObject.GetComponent<BallController>().player)
        {
            Destroy(colliderEnter.gameObject);
            Health -= colliderEnter.gameObject.GetComponent<BallController>().damage;

            HealthText.GetComponent<Text>().text = Health <= 0 ? "0" : Health.ToString();
            if (Health <= 0)
            {
                GameResult.GetComponent<Text>().text = "YOU LOSE";
                GameResult.SetActive(true);
                Time.timeScale = 0;
                Destroy(subtractHelper);
                Destroy(gameObject);
            }
            subtractHelper.GetComponent<Text>().text = "-" + colliderEnter.gameObject.GetComponent<BallController>().damage.ToString();
            subtractHelper.GetComponent<Text>().color = new Color(subtractHelper.GetComponent<Text>().color.r, subtractHelper.GetComponent<Text>().color.g, subtractHelper.GetComponent<Text>().color.b, 1);
        }
    }
}

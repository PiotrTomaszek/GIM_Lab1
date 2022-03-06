using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    public Rigidbody rigidBody;
    public Text userScore;
    public Text winGameMessage;

    private int _count;
    private const string USER_SCORE_TEXT = "Twój wynik: ";

    // Start is called before the first frame update
    void Start()
    {
        _count = 0;
        userScore.text = $"{USER_SCORE_TEXT}0";
        winGameMessage.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rigidBody.AddForce(movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "CapsulePickUp")
        {
            other.gameObject.SetActive(false);
            _count++;

            userScore.text = $"{USER_SCORE_TEXT}{_count.ToString()}";
        }
        else if (other.gameObject.tag == "CylinderPickUp")
        {
            other.gameObject.SetActive(false);
            _count += 4;

            userScore.text = $"{USER_SCORE_TEXT}{_count.ToString()}";
        }

        if (_count > 8)
        {
            winGameMessage.text = "Wygrałeś";
        }
    }
}
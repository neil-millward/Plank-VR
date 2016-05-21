using UnityEngine;
using System.Collections;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    //as public, speed propertie shows up in unity
    public float speed;
    //Used to display the count of items collected in game
    public Text countText;
    //WinText used to display "You Win!" on UI when player wins
    public Text winText;
    //Adding a Rigidbody component to an object will put its motion under the control of Unity's physics engine
    private Rigidbody rb;
    //used to keep track of score
    private int count;

    //Creating a game sound obj in unity, attaching a sound file to it then playing on collision
    new AudioSource audio;


    void Start()
    {
        //initiallised at beginning of game
        count = 0;
        rb = GetComponent<Rigidbody>();


       // audio = GameObject.Find("CoinSoundObj").GetComponent<AudioSource>();
        // pickUpSound = new AudioClip(Resources.Load("Music/Super Mario Bros. - Coin Sound Effect.wav"));
      //  setCountText();
      //  winText.text = " ";//set to blank as don't want diplayed until player picks up all 10 items
    }

    void FixedUpdate()
    {
        //used to read input, "Horizontal" and "Vertical" are mapped to wasd and 360 controller woaaaaaaaaah
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    //used to set the pickup items to dissapear on collision
    void OnTriggerEnter(Collider other)
    {
        //if the game object is the pickup one then dissapear
        if (other.gameObject.CompareTag("Pick Up"))
        {
            other.gameObject.SetActive(false);
            count++;
            //setCountText();

            if (audio == null)
            {
                print("audio not found");
            }
            else
            {
                audio.Play();
            }

            // print(count.ToString());
        }


    }

    /**
    void setCountText()
    {
        countText.text = "Count: " + count.ToString();


        if (count >= 10)
        {
            winText.text = "You Win!";
        }
    }
    */
}

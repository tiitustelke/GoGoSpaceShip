using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public InputField userName;
    

    public Text UserInput;

   
    void Start()
    {
        

        userName = GameObject.Find("UserInput").GetComponent<InputField>();
        userName.text = "moro";
        Debug.Log("Game Over....");
        
    }

    void Update()
    {
        FindObjectOfType<AudioManager>().Play("GameOver");
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log(userName.text);
        }
    }
}

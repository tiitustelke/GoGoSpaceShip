using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public InputField userName = GameObject.Find("UserInput").GetComponent<InputField>();
    

    public Text UserInput;

   
    void Start()
    {
        userName.text = "moro";
        Debug.Log("Game Over....");
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log(userName.text);
        }
    }
}

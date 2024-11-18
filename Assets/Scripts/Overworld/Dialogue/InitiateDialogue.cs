using UnityEngine;

public class InitiateDialogue : MonoBehaviour
{
    public string button = "space";
    private GameObject dialogue;
    private bool inRange = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dialogue = this.transform.Find("DialogueHandler").gameObject;
        dialogue.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyDown(button))
            {
                if (!dialogue.activeSelf)
                {
                    // Debug.Log("Dialogue initiated");
                    dialogue.SetActive(true);
                }
                else if (dialogue.activeSelf)
                {
                    dialogue.GetComponent<DialogueHandler>().DoTalk();
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            // Debug.Log("Player is in range");
            inRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            // Debug.Log("Player is out of range");
            inRange = false;
            dialogue.SetActive(false);
        }
    }
}
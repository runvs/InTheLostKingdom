using UnityEngine;
using System.Collections;
using System.Reflection;

public class StoryManager : MonoBehaviour 
{

    private float _deadTimer;

    public AudioClip BipSound;

    public bool Act1Finished = false;
    public bool A1S1Finished = false;

    public bool A1S2Finished = false;
    public bool A1S2_TalkRad = false;
    public bool A1S2_TalkSca = false;
    public bool A1S2_KilledE = false;
    public bool A1S2_TookRing = false;

    public bool A1S3Finished = false;

    public bool Act2Finished = false;

    public bool Act3Finished = false;


    public void FA1S2_TalkRad()
    {
        ShowText("Radath: I will smack them hard!");
    }

    public void FA1S2_TalkSca()
    {
        ShowText("Scaethys: Lets do this!");
    }
    public void FA1S2_KilledE()
    {
        ShowText("Scaethys: Great! Whats in the Chest??");
    }

    public void FA1S2_TookRing()
    {

    }




    [HideInInspector]
    public bool TextMessagePresent;
    GUIText MessageText;

	// Use this for initialization
	void Start () 
    {
        DontDestroyOnLoad(gameObject);
        TextMessagePresent = false;
        MessageText = this.gameObject.GetComponent<GUIText>();
        if(MessageText == null)
        {
            Debug.Log("Cannot find GuiText for Messages");
        }
        MessageText.enabled = false;
        _deadTimer = -1.0f;
	}

    public void ChangeValue(string str)
    {
        //Debug.Log("Change Property " + str + " from " + GetType().GetField(str).GetValue(this) + " to True");
        this.GetType().GetField(str).SetValue(this, true);
        //Debug.Log("Calling Function " + "F" + str);
        this.GetType().GetMethod("F"+str).Invoke(this, null);
    }

    public bool GetValue(string str)
    {
        return (bool)(this.GetType().GetField(str).GetValue(this));
    }


	
	// Update is called once per frame
	void Update () 
    {
        TextMessagePresent = MessageText.enabled;
        if (_deadTimer > 0)
        {
            _deadTimer -= Time.deltaTime;
        }
        else
        {
            if (Input.GetButton("Fire1"))
            {
                if (TextMessagePresent)
                {
                    MessageText.enabled = false;
                    audio.PlayOneShot(BipSound);
                }
            }
        }
	}

    public void ShowText (string text)
    {
        MessageText.text = text;
        MessageText.enabled = true;
        _deadTimer = 1.0f;
        audio.PlayOneShot(BipSound);
    }

    public void HideText()
    {
        MessageText.enabled = false;
    }
}

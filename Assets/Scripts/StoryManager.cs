using UnityEngine;
using System.Collections;
using System.Reflection;

public class StoryManager : MonoBehaviour 
{

    private float _deadTimer;

    public AudioClip BipSound;

    public bool Act1Finished = false;

    public bool A1S1Finished = false;
    public bool A1S1Talk1 = false;
    public bool A1S1Talk2 = false;
    public bool A1S1Talk3 = false;
    public bool A1S1Talk4 = false;
    public bool A1S1Talk5 = false;
    public bool A1S1Talk6 = false;
    public bool A1S1Talk7 = false;
    public bool A1S1Talk8 = false;
    public bool A1S1Talk9 = false;
    public bool A1S1Talk10 = false;
    public bool A1S1Talk11 = false;
    public bool A1S1Talk12 = false;
    public bool A1S1Talk13 = false;
    public bool A1S1Talk14 = false;

    public bool A1S2Finished = false;
    public bool A1S2_TalkRad = false;
    public bool A1S2_TalkSca = false;
    public bool A1S2_KilledE = false;
    public bool A1S2_TookRing = false;

    public bool A1S3Finished = false;

    public bool Act2Finished = false;


    public bool Act3Finished = false;

    #region A1Sc1 ScriptSequence
    public void FA1S1Talk1()
    {
        ShowText("Scaethys: ... in the Lost Kingdom i would be some kind of Robin Hood.");
    }
    public void FA1S1Talk2()
    {
        ShowText("Radath: ... So stealing from the strong and giving the weak?");
    }
    public void FA1S1Talk3()
    {
        ShowText("Scaethys: So glad we got the note about the shipment.");
    }
    public void FA1S1Talk4()
    {
        ShowText("Scaethys: Tomorrow we will start with doing great deeds .");
    }
    public void FA1S1Talk5()
    {
        ShowText("Radath: So everyone knows what to do?.");
    }
    public void FA1S1Talk6()
    {
        ShowText("Radath: We will just beat the hell out of them!");
    }
    public void FA1S1Talk7()
    {
        ShowText("Scaethys: And then get the precoius treasures they carry.");
    }
    public void FA1S1Talk8()
    {
        ShowText("Radath: So First take care of the guards.");
    }
    public void FA1S1Talk9()
    {
        ShowText("Scaethys: And then loot the chest.");
    }
    public void FA1S1Talk10()
    {
        ShowText("Radath: ... So You mean stealing from the strong and giving the weak?");
    }
    public void FA1S1Talk11()
    {
        ShowText("Scaethys: Lost Kingdom, here we come!");
    }
    public void FA1S1Talk12()
    {
        
    }
    public void FA1S1Talk13()
    {
       
    }
    public void FA1S1Talk14()
    {
        ChangeValue("A1S1Finished");
    }
    #endregion A1Sc1 ScriptSequence
    public void FA1S1Finished()
    {
        Debug.Log("Teleporting!!");
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(7, 0);
        Application.LoadLevel("A1Sc2_Road");
    }

 

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
        ShowText("Scaethys: Great! Loot the Chest!");
    }

    public void FA1S2_TookRing()
    {
        ShowText("Scaethys: Wow, that amulett is precious.");
    }

    public void FA1S2Finished()
    {
        
        Debug.Log("Teleporting!!");
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-1, -12);
        Application.LoadLevel("A3Sc2_TempleShowdown");
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
                    GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<PlayerAttackingScript>()._inputTimer += 0.5f;
                }
            }
        }
	}

    public void ShowText (string text)
    {
        MessageText.text = text;
        MessageText.enabled = true;
        _deadTimer = 0.750f;
        audio.PlayOneShot(BipSound);
    }

    public void HideText()
    {
        MessageText.enabled = false;
    }
}

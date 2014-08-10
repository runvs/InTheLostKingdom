﻿using UnityEngine;

public class StoryManager : MonoBehaviour
{

    private float _deadTimer;

    public AudioClip BipSound;
    public AudioClip MagicEffectSound;

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

    public bool A2S1Finished = false;
    public bool A2S1Talk1 = false;
    public bool A2S1Talk2 = false;
    public bool A2S1Talk3 = false;
    public bool A2S1Talk4 = false;
    public bool A2S1Talk5 = false;
    public bool A2S1Talk6 = false;
    public bool A2S1Talk7 = false;
    public bool A2S1Talk8 = false;
    public bool A2S1Talk9 = false;
    public bool A2S1Talk10 = false;
    public bool A2S1Talk11 = false;
    public bool A2S1Talk12 = false;

    public bool A2S2Fininished = false;
    public bool A2S2_RadTalk = false;
    public bool A2S2_FoundHut = false;
    public bool A2S2_Talk1 = false;
    public bool A2S2_Talk2 = false;
    public bool A2S2_Talk3 = false;
    public bool A2S2_Talk4 = false;
    public bool A2S2_Talk5 = false;
    public bool A2S2_Talk6 = false;
    public bool A2S2_Talk7 = false;
    public bool A2S2_Talk8 = false;


    public bool Act3Finished = false;

    public bool A3S2Finished = false;
    public bool A3S2_EnterMap = false;
    public bool A3S2_EnterTem = false;
    public bool A3S2_TemTalk1 = false;
    public bool A3S2_KilledSc = false;
    public bool A3S2_FinTalk1 = false;
    public bool A3S2_FinTalk2 = false;
    public bool A3S2_FinTalk3 = false;
    public bool A3S2_FinTalk4 = false;

    #region A1Sc1 ScriptSequence
    public void FA1S1Talk1()
    {
        ShowText("Scaethys: ... in the Lost Kingdom i \nwould be some kind of Robin Hood.");
    }
    public void FA1S1Talk2()
    {
        ShowText("Radath: ... So stealing from \nthe strong and giving the weak?");
    }
    public void FA1S1Talk3()
    {
        ShowText("Scaethys: So glad we got the note about \nthe shipment.");
    }
    public void FA1S1Talk4()
    {
        ShowText("Scaethys: Tomorrow we will start with \ndoing great deeds .");
    }
    public void FA1S1Talk5()
    {
        ShowText("Radath: So everyone knows what to do?");
    }
    public void FA1S1Talk6()
    {
        ShowText("Radath: We will just beat the hell \nout of them!");
    }
    public void FA1S1Talk7()
    {
        ShowText("Scaethys: And then get the precoius \ntreasures they carry.");
    }
    public void FA1S1Talk8()
    {
        ShowText("Radath: So First take care\n of the guards.");
    }
    public void FA1S1Talk9()
    {
        ShowText("Scaethys: And then loot the chest.");
    }
    public void FA1S1Talk10()
    {
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


    #region A1Sc2 Scripts
    public void FA1S2_TalkRad()
    {
        ShowText("Radath: To hit an enemy, \njust press ctrl!");
    }

    public void FA1S2_TalkSca()
    {
        ShowText("Scaethys: You should try to \nevade their hits!");
    }
    public void FA1S2_KilledE()
    {
        ShowText("Scaethys: Great! Loot the Chest!");
    }

    public void FA1S2_TookRing()
    {
        ShowText("Scaethys: Wow, that amulett \nis precious. I will take it.");
    }
    #endregion A1Sc2 Scripts
    public void FA1S2Finished()
    {

        Debug.Log("Teleporting!!");
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(6, 2);
        Application.LoadLevel("A2Sc1_ThievesCamp");
    }

    #region A2S1 ScriptSequence
    public void FA2S1Talk1()
    {
        ShowText("Scaethys: Finally we managed\nto get at least one job done!");
    }
    public void FA2S1Talk2()
    {
        ShowText("Scaethys: An with the prey\nwe can now live like kings!");
    }
    public void FA2S1Talk3()
    {
        ShowText("Radath (whispers): \nFor two days? No longer!");
    }
    public void FA2S1Talk4()
    {
        ShowText("Scaethys: You, don't grumble.\nWith my plan i got us real food!");
    }
    public void FA2S1Talk5()
    {
        ShowText("Radath: Yeah Scaethys, you are right!");
    }
    public void FA2S1Talk6()
    {
        ShowText("Scaethys: Tomorrow I will \nkeep ... erm sell this amulett...");
    }
    public void FA2S1Talk7()
    {
        ShowText("Scaethys: And you two will do the next job.");
    }
    public void FA2S1Talk8()
    {
        ShowText("Scaethys: I know an old clairvoyant\n in the forest.");
    }
    public void FA2S1Talk9()
    {
        ShowText("Radath (whispers): No good deeds to expect from you.");
    }
    public void FA2S1Talk10()
    {
        ShowText("Scaethys: Shut up and eat!");
    }
    public void FA2S1Talk11()
    {

    }
    public void FA2S1Talk12()
    {

    }
    #endregion A2S1 ScriptSequence
    public void FA2S1Finished()
    {
        Debug.Log("Teleporting!!");
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-2, -3);
        Application.LoadLevel("A2Sc2_ForestHut");
    }

    #region A2S2 Scripts

    public void FA2S2_RadTalk()
    {
        ShowText("Radath: Ok, lets do this!\nThough Scaethys behavevd strange.");
    }

    public void FA2S2_FoundHut()
    {
        GameObject.FindGameObjectWithTag("finalboss").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.FindGameObjectWithTag("finalboss").transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        audio.PlayOneShot(MagicEffectSound);
    }

    public void FA2S2_Talk1()
    {
        ShowText("Radath: I cannot move! Help me!");
    }
    public void FA2S2_Talk2()
    {
        ShowText("Clairvoyant: Whahahahaha! So i \nexpected you.");

    }
    public void FA2S2_Talk3()
    {
        ShowText("Clairvoyant: You are responsible \nfor your actions.");
    }
    public void FA2S2_Talk4()
    {
        ShowText("Clairvoyant: The Amulet you took was \nment sacrifice for the maleficent God Elion.");
    }
    public void FA2S2_Talk5()
    {
        ShowText("Clairvoyant: You must complete \nthe sacrifice to end our misery.");
    }
    public void FA2S2_Talk6()
    {
        ShowText("Radath: By the lost kingdom,\nwhat have we done?");
    }
    public void FA2S2_Talk7()
    {
        ShowText("Clairvoyant: Do a heck of a job! \nEveryone counts on you!");
    }
    public void FA2S2_Talk8()
    {
        //ChangeValue("A2S2Fininished");
    }

    public void FA2S2Fininished()
    {
        Debug.Log("Teleporting!!");
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-1, -12);
        Application.LoadLevel("A3Sc2_TempleShowdown");
    }

    #endregion A2S2 Scripts

    public void FA3S2_EnterMap()
    {
        ShowText("Radath: Finally We \ntracked down Scaethys.");
    }

    public void FA3S2_EnterTem()
    {
        ShowText("Scaethys: I have expected you.");
    }
    public void FA3S2_TemTalk1()
    {
        ShowText("Scaethys: You will not hand over the amulet.");
    }

    public void FA3S2_KilledSc()
    {

    }

    public void FA3S2_FinTalk1()
    {

    }
    public void FA3S2_FinTalk2()
    {

    }
    public void FA3S2_FinTalk3()
    {

    }
    public void FA3S2_FinTalk4()
    {
        ChangeValue("A3S2Finished");
    }

    public void FA3S2Finished()
    {
        ChangeValue("Act3Finished");
    }

    public void FAct3Finished()
    {
        // Finish Game, switch to credits or menu
    }


    [HideInInspector]
    public bool TextMessagePresent;
    GUIText MessageText;
    GUITexture MessageBackground;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        TextMessagePresent = false;
        MessageText = this.gameObject.GetComponent<GUIText>();
        if (MessageText == null)
        {
            Debug.Log("Cannot find GuiText for Messages");
        }
        MessageText.enabled = false;

        MessageBackground = this.gameObject.transform.GetChild(0).GetComponent<GUITexture>();
        if (MessageBackground == null)
        {
            Debug.Log("Cannot find GUITexture for Messages");
        }
        MessageBackground.enabled = false;

        _deadTimer = -1.0f;
    }

    public void ChangeValue(string str)
    {
        //Debug.Log("Change Property " + str + " from " + GetType().GetField(str).GetValue(this) + " to True");
        this.GetType().GetField(str).SetValue(this, true);
        //Debug.Log("Calling Function " + "F" + str);
        this.GetType().GetMethod("F" + str).Invoke(this, null);
    }

    public bool GetValue(string str)
    {
        return (bool)(this.GetType().GetField(str).GetValue(this));
    }



    // Update is called once per frame
    void Update()
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
                    HideText();
                    audio.PlayOneShot(BipSound);
                    GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).GetComponent<PlayerAttackingScript>()._inputTimer += 0.5f;
                }
            }
        }
    }

    public void ShowText(string text)
    {

        MessageBackground.enabled = true;

        MessageText.text = text;
        MessageText.enabled = true;
        _deadTimer = 0.650f;
        audio.PlayOneShot(BipSound);
    }

    public void HideText()
    {
        MessageText.enabled = false;
        MessageBackground.enabled = false;
    }
}

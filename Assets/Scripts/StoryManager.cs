using System.Collections.Generic;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    [HideInInspector]
    public bool TextMessagePresent;
    GUIText MessageText;
    GUITexture MessageBackground;

    private float _deadTimer;
    private float _teleportTimer;
    private SimpleAnimator _animator;

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
    public bool A3S2_TalkRad = false;
    public bool A3S2_EnterMap = false;
    public bool A3S2_EnterTem = false;
    public bool A3S2_TemTalk1 = false;
    public bool A3S2_TemTalk2 = false;
    public bool A3S2_Chest1 = false;
    public bool A3S2_Chest2 = false;
    public bool A3S2_KilledSc = false;
    public bool A3S2_FinTalk1 = false;
    public bool A3S2_FinTalk2 = false;
    public bool A3S2_FinTalk3 = false;
    public bool A3S2_FinTalk4 = false;

    #region A1Sc1 ScriptSequence
    public void FA1S1Talk1()
    {
        DisablePlayerMovement();
        ShowText("Scaethys: ... in the Lost Kingdom i \nwould be some kind of Robin Hood.");
        MoveNPC("npc1");
    }
    public void FA1S1Talk2()
    {
        ShowText("Radath: ... So stealing from \nthe strong and giving the weak?");
        MoveNPC("npc2");
    }
    public void FA1S1Talk3()
    {
        ShowText("Scaethys: So glad we got the note about \nthe shipment.");
        MoveNPC("npc1");
    }
    public void FA1S1Talk4()
    {
        ShowText("Scaethys: Tomorrow we will start with \ndoing great deeds .");
        MoveNPC("npc1");
    }
    public void FA1S1Talk5()
    {
        ShowText("Radath: So everyone knows what to do?");
        MoveNPC("npc2");
    }
    public void FA1S1Talk6()
    {
        ShowText("Radath: We will just beat the hell \nout of them!");
        MoveNPC("npc2");
    }
    public void FA1S1Talk7()
    {
        ShowText("Scaethys: And then get the precoius \ntreasures they carry.");
        MoveNPC("npc1");
    }
    public void FA1S1Talk8()
    {
        ShowText("Radath: So First take care\n of the guards.");
        MoveNPC("npc2");
    }
    public void FA1S1Talk9()
    {
        ShowText("Scaethys: And then loot the chest.");
        MoveNPC("npc1");
    }
    public void FA1S1Talk10()
    {
    }
    public void FA1S1Talk11()
    {
        ShowText("Scaethys: Lost Kingdom, here we come!");
        MoveNPC("npc1");
    }
    public void FA1S1Talk12()
    {

    }
    public void FA1S1Talk13()
    {

    }
    public void FA1S1Talk14()
    {
        EnablePlayerMovement();
        ChangeValue("A1S1Finished");
    }
    #endregion A1Sc1 ScriptSequence
    public void FA1S1Finished()
    {
        Debug.Log("Teleporting!!");
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(13, 1);
        Application.LoadLevel("A1Sc2_Road");
    }


    #region A1Sc2 Scripts
    public void FA1S2_TalkRad()
    {

        ShowText("Radath: To hit an enemy, \njust press ctrl!");
        MoveNPC("npc2");
    }

    public void FA1S2_TalkSca()
    {
        ShowText("Scaethys: You should try to \nevade their hits!");
        MoveNPC("npc1");
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
        DisablePlayerMovement();
        ShowText("Scaethys: Finally we managed\nto get at least one job done!");
        MoveNPC("npc1");
    }
    public void FA2S1Talk2()
    {
        ShowText("Scaethys: An with the prey\nwe can now live like kings!");
        MoveNPC("npc1");
    }
    public void FA2S1Talk3()
    {
        ShowText("Radath whispers: \nFor two days? No longer!");
        MoveNPC("npc2");
    }
    public void FA2S1Talk4()
    {
        ShowText("Scaethys: You, don't grumble.\nWith my plan i got us real food!");
        MoveNPC("npc1");
    }
    public void FA2S1Talk5()
    {
        ShowText("Radath: Yeah Scaethys, you are right!");
        MoveNPC("npc2");
    }
    public void FA2S1Talk6()
    {
        ShowText("Scaethys: Tomorrow I will \nkeep ... erm sell this amulett...");
        MoveNPC("npc1");
    }
    public void FA2S1Talk7()
    {
        ShowText("Scaethys: And you two will \nperform the next job.");
        MoveNPC("npc1");
    }
    public void FA2S1Talk8()
    {
        ShowText("Scaethys: I know an old clairvoyant\n in the forest.");
        MoveNPC("npc1");
    }
    public void FA2S1Talk9()
    {
        ShowText("Radath whispers: No good deeds to \nexpect from you.");
        MoveNPC("npc2");
    }
    public void FA2S1Talk10()
    {
        EnablePlayerMovement();
        ShowText("Scaethys: Shut up and eat!");
        MoveNPC("npc1");
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>().Health = GameProperties.PlayerMaxHealth;
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
        MoveNPC("npc2");
    }

    public void FA2S2_FoundHut()
    {
        GameObject.FindGameObjectWithTag("finalboss").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.FindGameObjectWithTag("finalboss").transform.GetChild(0).GetComponent<ParticleSystem>().Play();
        GameObject.FindGameObjectWithTag("ScreenEffects").GetComponent<ScreenEffects>().ShakeScreen(0.5f, .50f);
        audio.PlayOneShot(MagicEffectSound);
    }

    public void FA2S2_Talk1()
    {
        DisablePlayerMovement();
        ShowText("Radath: I cannot move! Help me!");
    }
    public void FA2S2_Talk2()
    {
        ShowText("Clairvoyant: Whahahahaha! So i \nexpected you.");
        MoveNPC("finalboss");

    }
    public void FA2S2_Talk3()
    {
        ShowText("Clairvoyant: You are responsible \nfor your actions.");
        MoveNPC("finalboss");
    }
    public void FA2S2_Talk4()
    {
        ShowText("Clairvoyant: The Amulet you took was a \nsacrifice for the maleficent God Elion.");
        MoveNPC("finalboss");
    }
    public void FA2S2_Talk5()
    {
        ShowText("Clairvoyant: You must complete \nthe sacrifice to end our misery.");
        MoveNPC("finalboss");
    }
    public void FA2S2_Talk6()
    {
        ShowText("Radath: By the lost kingdom,\nwhat have we done?");
    }
    public void FA2S2_Talk7()
    {
        ShowText("Clairvoyant: Do a heck of a job! \nEveryone counts on you!");
        MoveNPC("finalboss");
    }
    public void FA2S2_Talk8()
    {
        //ChangeValue("A2S2Fininished");
    }

    public void FA2S2Fininished()
    {
        EnablePlayerMovement();
        Debug.Log("Teleporting!!");
        GameObject.FindGameObjectWithTag("Player").transform.position = new Vector3(-1, -12);
        Application.LoadLevel("A3Sc2_TempleShowdown");
    }

    #endregion A2S2 Scripts


    #region A3S2 Temple Scripts

    public void FA3S2_EnterMap()
    {
        ShowText("Radath: We \ntracked down Scaethys.");
        MoveNPC("npc2");
    }

    public void FA3S2_TalkRad()
    {
        ShowText("Radath: For the Lost Kingdom!");
        MoveNPC("npc2");
    }

    public void FA3S2_EnterTem()
    {
        // destroy all normal enemies
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Enemies");
        foreach (var e in objs)
        {
            if (e.name.Equals("enemy"))
            {
                Destroy(e);
            }
            // give scaethys more health
            else if (e.name.Equals("scaethys"))
            {
                e.GetComponent<HealthController>().Health = 10;
            }
        }
        /// voice evil laughter
        ShowText("Scaethys: I have expected you.");
    }
    public void FA3S2_TemTalk1()
    {
        ShowText("Scaethys: I will not hand over the amulet.");
    }
    public void FA3S2_TemTalk2()
    {
        ShowText("Radath whispers: Check the chests\n for health.");
    }

    public void FA3S2_Chest1()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>().Health = GameProperties.PlayerMaxHealth;
        ShowText("You open the chest and find \na health potion.");
    }
    public void FA3S2_Chest2()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>().Health = GameProperties.PlayerMaxHealth;
        ShowText("You open the chest and find \na health potion.");
    }

    public void FA3S2_KilledSc()
    {
        ShowText("Scaethys: You have defeated me.");
    }

    public void FA3S2_FinTalk1()
    {
        ShowText("You take the Amulett and place \nit on the altar.");
    }
    public void FA3S2_FinTalk2()
    {
        ShowText("The Temple starts to glow from the \ninside and you feel a great relief");
    }
    public void FA3S2_FinTalk3()
    {
        ShowText("You have completed you Quest \nfor the lost kingdom!");
    }
    public void FA3S2_FinTalk4()
    {
        ChangeValue("A3S2Finished");
    }
    #endregion A3S2 Temple Scripts

    public void FA3S2Finished()
    {
        ChangeValue("Act3Finished");
    }

    public void FAct3Finished()
    {
        // Finish Game, switch to credits or menu
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>().ResetGame();
    }

    void Start()
    {
        _playerCanMove = true;
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

        go_jump = new System.Collections.Generic.Dictionary<GameObject, float>();

        _animator = this.gameObject.GetComponentInChildren<SimpleAnimator>();
        _teleportTimer = _animator.Sprites.Length * (_animator.TimePerFrame / 1000);
    }

    public void ChangeValue(string str)
    {
        this.GetType().GetField(str).SetValue(this, true);
        this.GetType().GetMethod("F" + str).Invoke(this, null);
    }

    public bool GetValue(string str)
    {
        return (bool)(this.GetType().GetField(str).GetValue(this));
    }

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

        Dictionary<GameObject, float> newDict = new Dictionary<GameObject, float>(); ;
        foreach (var o in go_jump)
        {
            if (o.Value >= -GameProperties.JumpTime)
            {
                o.Key.transform.position += OffsetFromTime(o.Value);
                newDict.Add(o.Key, o.Value - Time.deltaTime);
            }
        }
        go_jump = newDict;
    }

    private Vector3 OffsetFromTime(float p)
    {
        return new Vector3(0, p / 8.0f, 0);
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

    private bool _playerCanMove;

    public void DisablePlayerMovement()
    {
        _playerCanMove = false;
    }

    public void EnablePlayerMovement()
    {
        _playerCanMove = true;
    }

    public bool PlayerCanMove()
    {
        if (TextMessagePresent)
        {
            return false;
        }
        return _playerCanMove;
    }

    Dictionary<GameObject, float> go_jump;

    public void MoveNPC(string npcTag)
    {
        var o = GameObject.FindGameObjectWithTag(npcTag);
        if (o)
        {
            go_jump.Add(o, GameProperties.JumpTime);
        }
    }

}

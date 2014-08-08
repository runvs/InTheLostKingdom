using UnityEngine;
using System.Collections;

public class ScreenEffects : MonoBehaviour 
{

    float RemainingShakeTime = 0.0f;
    float TotalShakeTime = 0.0f;
    float ShakeAmount;
    float ShakeStrenght;

    float ScaleObjectsRemainingTime = 0.0f;
    float ScaleObjectsTotalTime = 0.0f;
    float ScaleObjectsFactor = 1.0f;

    Texture2D _glowSpriteTexture;
    Sprite _glowSprite;

    public ParticleSystem explosion;
    public ParticleSystem brakeSystem;


    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (RemainingShakeTime > 0.0f)
        {
            GameObject myCam = GameObject.FindGameObjectWithTag("MainCamera");
            ShakeAmount = RemainingShakeTime / TotalShakeTime * ShakeStrenght * 0.5f;
            myCam.GetComponent<CameraFollowScript>().Offset = Random.insideUnitSphere * ShakeAmount;
            RemainingShakeTime -= Time.deltaTime;
        }
        else if (RemainingShakeTime < 0.0f)
        {
            GameObject myCam = GameObject.FindGameObjectWithTag("MainCamera");
            RemainingShakeTime = 0.0f;
            myCam.GetComponent<CameraFollowScript>().Offset = new Vector3(0, 0, -10);
        }
        



        if (ScaleObjectsRemainingTime > 0.0f)
        {
            ScaleObjectsRemainingTime -= Time.deltaTime;

            float currentScaleFactor = 1.0f + (ScaleObjectsFactor - 1.0f) * ScaleObjectsRemainingTime / ScaleObjectsTotalTime;
            Vector3 scaleVector = new Vector3(currentScaleFactor, currentScaleFactor, currentScaleFactor);

            //GameObject.FindGameObjectWithTag("Player").transform.localScale = scaleVector;
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Enemies"))
            {
                g.transform.localScale = scaleVector;
            }

        }
        else
        {
            ScaleObjectsRemainingTime = 0.0f;
            Vector3 scaleVector = new Vector3(1.0f, 1.0f, 1.0f);
            //GameObject.FindGameObjectWithTag("Player").transform.localScale = scaleVector;
            foreach (GameObject g in GameObject.FindGameObjectsWithTag("Enemies"))
            {
                g.transform.localScale = scaleVector;
            }
        }

    }

    public void ShakeScreen(float time, float strength)
    {
        Debug.Log("Shake it baby!");
        RemainingShakeTime = time;
        TotalShakeTime = time;
        ShakeStrenght = strength;
    }

    public void Explode(Vector3 position)
    {
        Instantiate(explosion, position, Quaternion.Euler(new Vector3(0, 0, 0)));
    }

    public void BrakeEffect(Vector3 position, Quaternion rotation)
    {
        Instantiate(brakeSystem, position, rotation);
    }

    public void ScaleObjects(float scaleFactor, float scaleTime)
    {
        ScaleObjectsFactor = scaleFactor;
        ScaleObjectsRemainingTime = ScaleObjectsTotalTime = scaleTime;
    }
}

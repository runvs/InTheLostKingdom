using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    float _fadeTimeTotal = 1.0f;
    float _fadeTime;
    bool _fading = false;

    float _introMoveTime;
    float _introMoveTimeTotal = 3.0f;

    float _introFadeTime;
    float _introFadeTimeTotal = 1.5f;

    public GameObject PlayerTemplate;

    // Use this for initialization
    void Start()
    {

        _fadeTime = _fadeTimeTotal;
        _introMoveTime = _introMoveTimeTotal;
        _introFadeTime = _introFadeTimeTotal;
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GUIText>().text = "In the lost Kingdom\n\nA Game by Julian Dinges @Thunraz \nAnd Simon Weis @Laguna_999 \n\nPress Space to start!";
        GameObject.FindGameObjectWithTag("GameController").GetComponent<GUIText>().color = new Color(1.0f, 1.0f, 1.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float camHalfHeight = Camera.main.orthographicSize;
        GameObject logo = GameObject.FindGameObjectWithTag("Hud");

        
        if (_introMoveTime >= 0 || _introFadeTime >= 0)
        {
            if (_introMoveTime >= 0)
            {
                _introMoveTime -= Time.deltaTime;

                float yval =  2.5f * (camHalfHeight * (1.0f - (float)(PennerDoubleEquation.GetValue(PennerDoubleEquation.EquationType.Linear, _introMoveTimeTotal - _introMoveTime, 0.0f, 1.0f, _introMoveTimeTotal))));
                logo.transform.position = new Vector3(0, yval, 0);
            }
            else
            {
                if (_introFadeTime >= 0)
                {
                    _introFadeTime -= Time.deltaTime;
                    logo.transform.position = new Vector3(0, 0, 0);
                    float alphaval = (1.0f - (float)(PennerDoubleEquation.GetValue(PennerDoubleEquation.EquationType.Linear, _introFadeTimeTotal - _introFadeTime, 0.0f, 1.0f, _introFadeTimeTotal)));
                    logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, alphaval);
                }

            }
        }
        else
        {
            if (_introFadeTime >= -_introFadeTimeTotal)
            {
                logo.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0);

                _introFadeTime -= Time.deltaTime;
                float alphaval = ((float)(PennerDoubleEquation.GetValue(PennerDoubleEquation.EquationType.Linear, -_introFadeTime, 0.0f, 1.0f, _introFadeTimeTotal)));
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GUIText>().color = new Color(0.682f, 0.768f, 0.25f, alphaval);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _fading = true;
            }

            if (_fading)
            {
                _fadeTime -= Time.deltaTime;

                Color b = new Color(0.682f, 0.768f, 0.25f, 1.0f);
                Color a = new Color(0.1255f, 0.2745f, 0.1922f, 1.0f);

                Color col = Color.Lerp(a, b, _fadeTime / _fadeTimeTotal);
                if (_fadeTime <= 0)
                {
                    col = new Color(1.0f, 1.0f, 1.0f, 0);
                    GameObject.FindGameObjectWithTag("GameController").GetComponent<GUIText>().color = col;
                    Application.LoadLevel("TestMap");
                    Instantiate(PlayerTemplate, new Vector3(-3, 1, 0), new Quaternion());
                    

                }
                GameObject.FindGameObjectWithTag("GameController").GetComponent<GUIText>().color = col;

            }
        }
    }
}

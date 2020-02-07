using System.Linq;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour
{
    public GameObject body;
    public GameObject plank;
    public Transform start;
    public Button START;
    public Toggle[] bodyChanger;
    public Slider angle_changer;
    public Text timer;
    public Text angle_value;
    private float time = 0.0f;

    private void Awake ()
    {
        Global.getInstance.inMove = false;
        Global.getInstance.onStartPosition = true;

        body.transform.position = start.position;

        timer.text = "00.00";
        angle_value.text = angle_changer.value.ToString() + '°';

        plank.transform.eulerAngles = new Vector3(0, 0, angle_changer.value);
        Global.getInstance.angle = Mathf.Deg2Rad * angle_changer.value;
    }

    void FixedUpdate ()
    {
        if(Global.getInstance.inMove)
        {
            time += Time.deltaTime;
            TimeShowing(time);                     
        }
	}

    public void Restart()
    {
        //возврат тела на стартовую позицию
        body.transform.position = start.position;
        Global.getInstance.onStartPosition = true;
        Global.getInstance.inMove = false;
        angle_changer.interactable = true;
        START.interactable = true;

        //сброс таймера
        time = 0.0f;
        timer.text = "00.00";

        for (int i = 0; i < bodyChanger.Length; ++i)
            bodyChanger[i].interactable = true;
    }

    public void Push()
    {
        if (plank.transform.eulerAngles.z < 25 && (body.tag == "BrickMetal" || body.tag == "BrickWooden"))
        {
            //Global.getInstance.inMove = false;
            //Global.getInstance.onStartPosition = true;
            //angle_changer.interactable = true;
            //START.interactable = true;
            //RESET.interactable = true;
            //STOP.interactable = true;
            //for (int i = 0; i < bodyChanger.Length; ++i)
            //    bodyChanger[i].interactable = true;
        }
        else
        {
            Global.getInstance.inMove = true;
            Global.getInstance.onStartPosition = false;
            angle_changer.interactable = false;
            START.interactable = false;
            for (int i = 0; i < bodyChanger.Length; ++i)
                bodyChanger[i].interactable = false;
        }
    }

    public void OnValueChanged()
    {
        angle_value.text = angle_changer.value.ToString() + '°';
        plank.transform.eulerAngles = new Vector3(0, 0, angle_changer.value);
        Global.getInstance.angle = Mathf.Deg2Rad * angle_changer.value;
    }

    private float getWholePart(float time)
    {
        float whole = Mathf.Floor(time);
        return whole;
    }

    private int getDecimalPart(float time)
    {
        int Decimal = (int)(100 * (time - Mathf.Floor(time)));

        return Decimal;
    }

    private void TimeShowing(float time)
    {
        if (time < 10.0f && getDecimalPart(time) < 10)
            timer.text = "0" + (getWholePart(time)).ToString() + ".0" + (getDecimalPart(time)).ToString();
        else if (time < 10.0f && getDecimalPart(time) >= 10)
            timer.text = "0" + (getWholePart(time)).ToString() + "." + (getDecimalPart(time)).ToString();
        else if (time >= 10.0f && getDecimalPart(time) < 10)
            timer.text = (getWholePart(time)).ToString() + ".0" + (getDecimalPart(time)).ToString();
        else
            timer.text = (getWholePart(time)).ToString() + "." + (getDecimalPart(time)).ToString();
    }

    public void inaccuracyAdding()
    {
        if(Global.getInstance.addInaccuracy)
        {            
            float inaccuracy = Random.Range(Global.getInstance.inaccuracyMin, Global.getInstance.inaccuracyMax);
            time += inaccuracy;
            TimeShowing(time);
        }
    }

   
}

using UnityEngine;

public class Body : MonoBehaviour
{
    public float g; //укорение свободного падения (м/с2)
    public float l; //длина поверхности, по которой скатывается тело
    public float R; //внешний радиус цилиндра
    public float _r; //внутренний радиус цилиндра
    public float k; //коэффициент инерции
    public float d; //коэффициент трения
    public float angle; //угол отколнения плоскости
    private Vector3 brick_angle; //угол наклона бруска
    private float t; //время 

    public Transform start; //стартовая позиция 
    public GameObject hole; //полость цилиндра

    private void Awake()
    {
        updatePatameters();
    }

    private void FixedUpdate()
    {
        if (Global.getInstance.inMove)
        {          
            if (gameObject.tag != "BrickMetal" && gameObject.tag != "BrickWooden")
            {
                //скатывание цилиндра
                t = Mathf.Sqrt(Mathf.Abs((2.0f * R * l * (1.0f + k)) / (g * (R * Mathf.Sin(angle) - (d / 2.0f) * Mathf.Cos(angle)))));

                if(gameObject.tag == "Cylinder")
                    t = t * timeInterpolation(angle, 4611.41f, -14613.6f, 19081.1f, -13266.7f, 5292.26f, -1210.5f, 147.475f, -6.3818f);
                else if(gameObject.tag == "EmptyCylinder")
                    t = t * timeInterpolation(angle, -7695.26f, 25731.3f, -35588.3f, 26294.0f, -11163.6f, 2711.54f, -346.941f, 18.9821f);

                gameObject.transform.Translate(Vector3.right * (2.0f * l / t) * Mathf.Cos(angle));
                gameObject.transform.Translate(Vector3.forward * (2.0f * l / t) * Mathf.Sin(angle));
            }
            else if (gameObject.tag == "BrickMetal" || gameObject.tag == "BrickWooden")
            {
                //скатывание бруска
                t = Mathf.Sqrt(2.0f * l / (g * Mathf.Cos(angle) * (Mathf.Tan(angle) - d)));

                if (gameObject.tag == "BrickMetal")
                    t = t * timeInterpolation(angle, 0, 0, 0, -29.1583f, 82.6209f, -88.1556f, 42.087f, -6.38679f);
                else if (gameObject.tag == "BrickWooden")
                    t = t * timeInterpolation(angle, 0, 0, 0, -321.418f, 801.527f, -740.085f, 300.301f, -44.0628f);
                gameObject.transform.Translate(Vector3.right * (2.0f * l / t) * Mathf.Cos(angle - (90.0f - brick_angle.x) * Mathf.Deg2Rad));
                gameObject.transform.Translate(Vector3.forward * (2.0f * l / t) * Mathf.Sin(angle - (90.0f - brick_angle.x) * Mathf.Deg2Rad));
            }

        }
        else if(Global.getInstance.onStartPosition)
        {
            //удержание цилиндра в стартовой позиции при изменении угла наклона плоскости
            gameObject.transform.position = start.position;
            angle = Global.getInstance.angle;

            //изменение угла наклона бруска бруска вместе с углом наклона плоскости
            if(gameObject.tag == "BrickMetal" || gameObject.tag == "BrickWooden")
            {
                brick_angle = new Vector3(90.0f - angle * Mathf.Rad2Deg, gameObject.transform.eulerAngles.y, gameObject.transform.eulerAngles.z);
                gameObject.transform.eulerAngles = brick_angle;
            }
        }
    }

    public void updatePatameters() //обновление параметров скатываемого тела
    {
        g = Global.getInstance.gravity;
        l = Global.getInstance.plank_length;

        if (gameObject.tag == "Cylinder")
        {
            R = Global.getInstance.common_cylinder_radius;
            _r = 0.0f;
            d = Global.getInstance.common_cylinder_friction_koefficient;
        }
        else if (gameObject.tag == "EmptyCylinder")
        {
            R = Global.getInstance.empty_cylinder_radius;
            _r = Global.getInstance.cylinder_inner_radius;
            d = Global.getInstance.empty_cylinder_friction_koefficient;

            hole.transform.localScale = new Vector3(_r / R, hole.transform.localScale.y, _r / R);
        }
        else if (gameObject.tag == "BrickMetal" || gameObject.tag == "BrickWooden")
        {
            _r = 0.0f;
            d = Global.getInstance.brick_friction_koefficient;
        }
        k = (1 + Mathf.Pow(_r / R, 2)) / 2.0f;
    }

    private float timeInterpolation(float angle, float a, float b, float c, float d, float e, float f, float g, float h)
    {
        float x = angle;
        float multiplier;

        /*функция выведена при помощи формулы интерполяции лагранжа
        каждому значению угла в радианах сопоставляется значение отношения времени
        реального эксперимента и времени рассчитанного по формуле*/
        multiplier = a * Mathf.Pow(x, 7) + b * Mathf.Pow(x, 6) + c * Mathf.Pow(x, 5) + d * Mathf.Pow(x, 4) + e * Mathf.Pow(x, 3) + f * Mathf.Pow(x, 2) + g * Mathf.Pow(x, 1) + h;
        return multiplier;
    }

}

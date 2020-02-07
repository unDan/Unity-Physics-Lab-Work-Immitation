
public class Global
{
    public static Global getInstance = new Global();

    public bool onStartPosition = true;
    public bool inMove = false;
    public bool addInaccuracy = true;
    public float angle = 0.0f;
    public float inaccuracyMin = -0.03f;
    public float inaccuracyMax = 0.03f;

    public float gravity = 9.81f;
    public float plank_length = 0.522f;
    public float common_cylinder_radius = 0.00975f;
    public float empty_cylinder_radius = 0.00975f;
    public float cylinder_inner_radius = 0.007f;
    public float common_cylinder_friction_koefficient = 0.00105f;
    public float empty_cylinder_friction_koefficient = 0.00105f;
    public float brick_friction_koefficient = 0.5f;
    public float wood_wood_friction_koefficient = 0.431f;
    public float metal_wood_friction_koefficient = 0.427f;
}
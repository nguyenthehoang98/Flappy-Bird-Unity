public partial class PlayerJump
{
    private enum State
    {
        Up,
        Down,
    }

    private static float Height(float gravity, float time, float initialSpeed)
    {
        //at ?t=211
        return .5f * gravity * time * time + initialSpeed * time;
    }
    
    public static float GravityForPeaking(float height, float timeToPeak)
    {
        return -2 * height / (timeToPeak * timeToPeak);
    }
}

public partial class PlayerJump
{
    private float force = 20.0f;
    private float gravity = -9.8f;
    private float timeToPeak = 0.75f;
    private float elapsed;
    private State state = State.Down;
    private bool stop = true;

    public void Stop()
    {
        stop = true;
    }

    public void Start()
    {
        stop = false;
    }

    public void Jump()
    {
        elapsed = timeToPeak;
        state = State.Up;
    }
    
    public void Update(float dt)
    {
        if (stop)
            return;

        float value = state == State.Up ? -dt : dt;
        elapsed += value;
        if (state == State.Up && elapsed < 0)
            state = State.Down;
    }

    public float GetDirection(float dt)
    {
        if (stop)
            return 0;
        
        if (state == State.Down)
            return Height(gravity, elapsed, 0) * dt;
        return Height(force, elapsed, 0) * dt;
    }
}
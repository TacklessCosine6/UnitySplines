using UnityEngine;

public class SplineWalker : MonoBehaviour
{

    public BezierSpline spline;

    public float duration;

    private float progress;

    public bool lookForward;

    //starting offset so that the walker if this far offset 0-100% of the path 
    [Range(0, 1)]
    public float startingOffset;

    public SplineWalkerMode mode;

    private bool goingForward = true;

    private void Start()
    {
        //always start at spline 'origin'
        transform.localPosition = spline.points[0];
        progress = startingOffset;
    }

    private void Update()
    {
        if (goingForward)
        {
            progress += Time.deltaTime / duration;
            if (progress > 1f)
            {
                if (mode == SplineWalkerMode.Once)
                {
                    progress = 1f;
                }
                else if (mode == SplineWalkerMode.Loop)
                {
                    progress -= 1f;
                }
                else {
                    //set to (2 - progress) to prevent stutter and so it bounces back through (pong mode)
                    progress = 2f - progress;
                    goingForward = false;
                }
            }
        }
        else {
            progress -= Time.deltaTime / duration;
            if (progress < 0f)
            {
                progress = -progress;
                goingForward = true;
            }
        }
        //most important part
        //reference spline get point function that will extract a location along its route based on overall % completed
        Vector3 position = spline.GetPoint(progress);
        //update walkers location to match the location of the calculated next position
        transform.localPosition = position;
        
        if (lookForward)
        {
            transform.LookAt(position + spline.GetDirection(progress));
        }
    }

    public float getProgress()
    {
        return progress;
    }
}

public enum SplineWalkerMode
{
    Once,
    Loop,
    PingPong
}

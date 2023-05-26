using UnityEngine;

public class Rotate : MonoBehaviour
{
    private bool rotatingClockwise = false;

	public void RotateFigure ()
	{
        rotatingClockwise = !rotatingClockwise;
        AudioManager.Instance.PlayTurnBlockSound();

        if (rotatingClockwise && (transform.eulerAngles.z > 270 || transform.eulerAngles.z <= 0))
	    {
            transform.Rotate(0, 0, -1);
	    }
	    else if (!rotatingClockwise && transform.eulerAngles.z > 0)
	    {
            transform.Rotate(0, 0, 1);
        
        }

   //     if (Input.GetKeyDown(KeyCode.E))
	  //  {
	  //      rotatingClockwise = !rotatingClockwise;
			//AudioManager.Instance.PlayTurnBlockSound(); // звук переключения блока 
	  //  }
	}
}

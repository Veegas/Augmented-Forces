using UnityEngine;
using System.Collections;
using System.IO;

public class UserInterfaceButtons : MonoBehaviour
{
	public float scalingSpeed = 0.03f;
	public float rotationSpeed = 70.0f;
	public float translationSpeed = 5.0f;
	public GameObject Model;
	bool repeatScaleUp = false;
	bool repeatScaleDown = false;
	bool repeatRotateLeft = false;
	bool repeatRotateRight = false;
	bool repeatPositionUp = false;
	bool repeatPositionDown = false;
	bool repeatPositionLeft = false;
	bool repeatPositionRight = false;

	private GameObject RightLine;
	private GameObject LeftLine;
	void Start () {
		Model = GameObject.FindWithTag ("Model");
		RightLine = Model.transform.FindChild ("Right Line").gameObject;
		LeftLine = Model.transform.FindChild ("Left Line").gameObject;

	}
		
	void Update ()
	{
		if (repeatScaleUp) {
			ScaleUpButton ();
		}

		if (repeatScaleDown) {
			ScaleDownButton ();
		}

		if (repeatRotateRight) {
			RotationRightButton();
		}

		if (repeatRotateLeft) {
			RotationLeftButton();
		}

		if (repeatPositionUp) {
			PositionUpButton();
		}

		if (repeatPositionDown) {
			PositionDownButton();
		}

		if (repeatPositionLeft) {
			PositionLeftButton();
		}

		if (repeatPositionRight) {
			PositionRightButton();
		}
		Vector3 CubeCenter = Model.transform.position;
		Vector3 cubeRight = new Vector3 (CubeCenter.x + 25, CubeCenter.y, CubeCenter.z);
		Vector3 cubeRightEnd = new Vector3 (CubeCenter.x + 100, CubeCenter.y, CubeCenter.z);
		Vector3 cubeLeft = new Vector3 (CubeCenter.x - 25, CubeCenter.y, CubeCenter.z);
		Vector3 cubeLeftEnd = new Vector3 (CubeCenter.x - 100, CubeCenter.y, CubeCenter.z);
		Vector3[] rightLinePts = new Vector3[2];
		rightLinePts[0] = cubeRight;
		rightLinePts[1] = cubeRightEnd;

		Vector3[] LeftLinePts = new Vector3[2];
		LeftLinePts[0] = cubeLeft;
		LeftLinePts[1] = cubeLeftEnd;
		RightLine.GetComponent<LineRenderer>().SetPositions(rightLinePts);
		LeftLine.GetComponent<LineRenderer>().SetPositions(LeftLinePts);

	}

	public void CloseAppButton ()
	{
		Application.Quit ();
	}

	public void RotationRightButton ()
	{
		// transform.Rotate (0, -rotationSpeed * Time.deltaTime, 0);
		Model.transform.Rotate (0, -rotationSpeed * Time.deltaTime, 0);
	}

	public void RotationLeftButton ()
	{
		// transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
		Model.transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
	}

	public void RotationRightButtonRepeat ()
	{
		// transform.Rotate (0, -rotationSpeed * Time.deltaTime, 0);
		repeatRotateRight=true;
	}
	
	public void RotationLeftButtonRepeat ()
	{
		// transform.Rotate (0, rotationSpeed * Time.deltaTime, 0);
		repeatRotateLeft=true;
	}

	public void ScaleUpButton ()
	{
		// transform.localScale += new Vector3(scalingSpeed, scalingSpeed, scalingSpeed);
		GameObject.FindWithTag ("Model").GetComponent<Rigidbody> ().mass += 0.1f;
		GameObject.FindWithTag ("Model").transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
		Debug.Log (GameObject.FindWithTag ("Model").GetComponent<Rigidbody> ().mass);
		}

	public void ScaleUpButtonRepeat ()
	{
		repeatScaleUp = true;
		Debug.Log ("Up");
	}
	public void ScaleDownButtonRepeat ()
	{
		repeatScaleDown = true;
		Debug.Log ("Down");
	}
	public void PositionDownButtonRepeat ()
	{
		repeatPositionDown = true;
	}
	public void PositionUpButtonRepeat ()
	{
		repeatPositionUp = true;
	}
	public void PositionLeftButtonRepeat ()
	{
		repeatPositionLeft = true;
	}
	public void PositionRightButtonRepeat ()
	{
		repeatPositionRight = true;
	}
	
	public void ScaleUpButtonOff ()
	{
		repeatScaleUp = false;
		Debug.Log ("Off");
	}
	public void ScaleDownButtonOff ()
	{
		repeatScaleDown = false;
		Debug.Log ("Off");
	}

	public void RotateLeftButtonOff ()
	{
		repeatRotateLeft = false;
		Debug.Log ("Off");
	}

	public void RotateRightButtonOff ()
	{
		repeatRotateRight = false;
		Debug.Log ("Off");
	}
	public void PositionRightButtonOff ()
	{
		repeatPositionRight = false;
		RightLine.SetActive (false);
		Debug.Log ("Off");
	}
	public void PositionLeftButtonOff ()
	{
		repeatPositionLeft = false;
		LeftLine.SetActive (false);
		Debug.Log ("Off");
	}
	public void PositionUpButtonOff ()
	{
		repeatPositionUp = false;
		Debug.Log ("Off");
	}
	public void PositionDownButtonOff ()
	{
		repeatPositionDown = false;
		Debug.Log ("Off");
	}
	
	public void ScaleDownButton ()
	{
		// transform.localScale += new Vector3(-scalingSpeed, -scalingSpeed, -scalingSpeed);
		GameObject.FindWithTag ("Model").GetComponent<Rigidbody> ().mass -= 0.1f;
		GameObject.FindWithTag ("Model").transform.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
		Debug.Log (GameObject.FindWithTag ("Model").GetComponent<Rigidbody> ().mass);

	}

	public void PositionUpButton ()
	{
		GameObject.FindWithTag ("Model").transform.Translate (0, 0, -translationSpeed * Time.deltaTime);
	}

	public void PositionDownButton ()
	{

		GameObject.FindWithTag ("Model").transform.Translate (0, 0, translationSpeed * Time.deltaTime);
	}

	public void PositionRightButton ()
	{
		GameObject.FindWithTag ("Model").GetComponent<Rigidbody> ().AddForce (Vector3.left * 10, ForceMode.Force); 
		RightLine.SetActive (true);
	}

	public void PositionLeftButton ()
	{
		GameObject.FindWithTag ("Model").GetComponent<Rigidbody> ().AddForce (Vector3.right * 10, ForceMode.Force);
		LeftLine.SetActive (true);
	}

	public void AddDragForce() {
		float dragForce = GameObject.FindWithTag ("Model").GetComponent<Rigidbody> ().drag;
		if (dragForce == 0) {
			GameObject.FindWithTag ("Model").GetComponent<Rigidbody> ().drag = 1;
		} else {
			GameObject.FindWithTag ("Model").GetComponent<Rigidbody> ().drag = 0;
		}
	}

	public void ChangeScene (string a)
	{
		Application.LoadLevel (a);
	}

	public void AnyButton ()
	{
		Debug.Log ("Any");
	}
}

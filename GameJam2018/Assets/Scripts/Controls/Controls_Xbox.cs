using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Controls_Xbox : MonoBehaviour {

	public int controllerNumber = 1;
	private XboxController controller;

	void Start() {
		switch (controllerNumber) {
		case 1:
			controller = XboxController.First;
			break;
		case 2:
			controller = XboxController.Second;
			break;
		case 3:
			controller = XboxController.Third;
			break;
		case 4:
			controller = XboxController.Fourth;
			break;
		}
	}

	public float LeftAnalogHorizontal { 
		get {
			return XCI.GetAxis (XboxAxis.LeftStickX, controller);
		}
	}

	public float LeftAnalogVertical {
		get {
			return XCI.GetAxis (XboxAxis.LeftStickY, controller);
		}
	}

	public float RightAnalogHorizontal {
		get {
			return XCI.GetAxis(XboxAxis.RightStickX, controller);
		}
	}

	public float RightAnalogVertical {
		get {
			return XCI.GetAxis(XboxAxis.RightStickY, controller);
		}
	}

	public bool DidPressButton_A {
		get {
			return XCI.GetButtonDown(XboxButton.A, controller);
		}
	}

	public bool DidPressButton_B {
		get {
			return XCI.GetButtonDown (XboxButton.B, controller);
		}
	}

	public bool DidReleaseButton_B {
		get {
			return XCI.GetButtonUp (XboxButton.B, controller);
		}
	}

	public bool DidPressButton_X {
		get {
			return XCI.GetButtonDown (XboxButton.X, controller);
		}
	}

	public bool IsButton_X_HeldDown {
		get {
			return XCI.GetButton (XboxButton.X, controller);
		}
	}

	public bool DidPressButton_Y {
		get {
			return XCI.GetButtonDown (XboxButton.Y, controller);
		}
	}

	public bool IsButton_Y_HeldDown {
		get {
			return XCI.GetButton (XboxButton.Y, controller);
		}
	}

	public float RightTrigger {
		get {
			return XCI.GetAxis (XboxAxis.RightTrigger, controller);
		}
	}

	public bool DidPressRightTrigger {
		get {
			return RightTrigger > 0;
		}
	}

	public bool DidPressRightBumper {
		get {
			return XCI.GetButtonDown (XboxButton.RightBumper, controller);
		}
	}

	public bool IsRightBumperHeldDown {
		get {
			return XCI.GetButton (XboxButton.RightBumper, controller);
		}
	}

	public bool DidReleaseRightBumper {
		get {
			return XCI.GetButtonUp (XboxButton.RightBumper, controller);
		}
	}

	public float LeftTrigger {
		get {
			return XCI.GetAxis (XboxAxis.LeftTrigger, controller);
		}
	}

	public bool DidPressLeftTrigger {
		get {
			return LeftTrigger > 0;
		}
	}

	public bool DidPressLeftBumper {
		get {
			return XCI.GetButtonDown (XboxButton.LeftBumper, controller);
		}
	}

	public bool IsLeftBumperHeldDown {
		get {
			return XCI.GetButton (XboxButton.LeftBumper, controller);
		}
	}
}

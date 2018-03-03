using UnityEngine;

public class TankMovementSound : MonoBehaviour
{
    public int m_PlayerNumber = 1;         
    public float m_Speed = 12f;            
    public float m_TurnSpeed = 180f;       
    public AudioSource m_MovementAudio;    
    public AudioClip m_EngineIdling;       
    public AudioClip m_EngineDriving;      
    public float m_PitchRange = 0.2f;
	public bool m_allowReset = true;

    
    private string m_MovementAxisName;     
    private string m_TurnAxisName;         
    private Rigidbody m_Rigidbody;         
    private float m_MovementInputValue;    
    private float m_TurnInputValue;        
    private float m_OriginalPitch;
	private Vector3 m_originalPos;

	// --------------------------------------
	// Starting
	// --------------------------------------
    private void Awake()
    {
		// When the tank is turned on, make sure it's not kinematic.
        m_Rigidbody = GetComponent<Rigidbody>();
    }


    private void OnEnable ()
    {
		// Also reset the input values.
        m_Rigidbody.isKinematic = false;
        m_MovementInputValue = 0f;
        m_TurnInputValue = 0f;
    }


    private void OnDisable ()
    {
		// When the tank is turned off, set it to kinematic so it stops moving.
        m_Rigidbody.isKinematic = true;
    }


    private void Start()
    {	
		// The axes names are based on player number.
        m_MovementAxisName = "Vertical" + m_PlayerNumber;
        // m_TurnAxisName = "Mouse X";
		 m_TurnAxisName = "Horizontal" + m_PlayerNumber;
		// m_TurnAxisName = "Mouse X";

		// Store the original pitch of the audio source.
        m_OriginalPitch = m_MovementAudio.pitch;

		m_originalPos = gameObject.transform.position;
    }


	// --------------------------------------
	// Loop
	// --------------------------------------
    private void Update()
    {
        // Store the player's input and make sure the audio for the engine is playing.
		m_MovementInputValue = Input.GetAxis (m_MovementAxisName);
		m_TurnInputValue = Input.GetAxis (m_TurnAxisName);

		EngineAudio ();

		if (Input.GetKeyDown (KeyCode.R) && m_allowReset) {
			Vector3 currentposition = gameObject.transform.position;
			Vector3 resettingRotation = new Vector3 (0, 0, 0);
			float pushingY = transform.position.y + 10f;

			currentposition.y = pushingY;
			gameObject.transform.position = currentposition;
			gameObject.transform.eulerAngles = resettingRotation;
		}

		//if (Input.GetKeyDown (KeyCode.Backspace) && m_allowReset) {
		//	resettingPlayer (m_originalPos);
		//}


    }



    private void FixedUpdate()
    {
        // Move and turn the tank.
		// Adjust the rigidbodies position and orientation in FixedUpdate.
		Move ();
		Turn ();
	}


	// --------------------------------------
	// Methods
	// --------------------------------------
	private void EngineAudio()
	{
		// Play the correct audio clip based on whether or not the tank is moving and what audio is currently playing.
		// If there is no input (the tank is stationary)...
		if (Mathf.Abs (m_MovementInputValue) < 0.1f && Mathf.Abs (m_TurnInputValue) < 0.1f) {

			// ... and if the audio source is currently playing the driving clip...
			if (m_MovementAudio.clip == m_EngineDriving) {
				// ... change the clip to idling and play it.
				m_MovementAudio.clip = m_EngineIdling;
				m_MovementAudio.pitch = Random.Range (m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
				m_MovementAudio.Play();
			}

		} else {
			// Otherwise if the tank is moving and if the idling clip is currently playing...
			if (m_MovementAudio.clip == m_EngineIdling) {
				// ... change the clip to driving and play.
				m_MovementAudio.clip = m_EngineDriving;
				m_MovementAudio.pitch = Random.Range (m_OriginalPitch - m_PitchRange, m_OriginalPitch + m_PitchRange);
				m_MovementAudio.Play();
			}
		}

	}



    private void Move()
    {
        // Adjust the position of the tank based on the player's input.
		// Create a vector in the direction the tank is facing with a magnitude based on the input, speed and the time between frames.
		Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
    	
		// Apply this movement to the rigidbody's position.
		m_Rigidbody.MovePosition (m_Rigidbody.position + movement);
	}



    private void Turn()
    {
        // Adjust the rotation of the tank based on the player's input.
		// Determine the number of degrees to be turned based on the input, speed and time between frames.
		float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;

		// Make this into a rotation in the y axis.
		Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);

		// Apply this rotation to the rigidbody's rotation.
		m_Rigidbody.MoveRotation (m_Rigidbody.rotation * turnRotation);
    }


	public void resettingPlayer (Vector3 resetPosition) {
		Vector3 resettingRotation = new Vector3 (0, 180, 0);
		gameObject.transform.position = resetPosition;
		gameObject.transform.eulerAngles = resettingRotation;

	}

	void OnCollisionEnter () {
		m_Rigidbody.velocity = Vector3.zero;
	}
}
using UnityEngine;

public class Camera2DFollow : MonoBehaviour
{

    /*public Transform target;
    public float damping = 1;
    public float lookAheadFactor = 3;
    public float lookAheadReturnSpeed = 0.5f;
    public float lookAheadMoveThreshold = 0.1f;*/

	public GameObject player;

	private float pX;
	private float pY;

	private Vector2 velocity;

	public float smoothX;
	public float smoothY;

	public bool border;

	public float minX;
	public float maxX;
	public float minY;
	public float maxY;
	
    /*private float offsetZ;
    private Vector3 lastTargetPosition;
    private Vector3 currentVelocity;
    private Vector3 lookAheadPos;*/

	void Awake()  {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

    // Use this for initialization
    /*private void Start()
    {

        lastTargetPosition = target.position;
        offsetZ = (transform.position - target.position).z;
        transform.parent = null;
    }*/

	void Update()  {
		if (player == null) {
			player = GameObject.FindGameObjectWithTag ("Player");
		} else {
			SmoothCamera();
		}

		if (border == true) {
			transform.position = new Vector3(Mathf.Clamp(transform.position.x, minX, maxX), Mathf.Clamp(transform.position.y, minY, maxY), transform.position.z);
		}
	}

	void SmoothCamera()  {
		pX = Mathf.SmoothDamp (transform.position.x, player.transform.position.x, ref velocity.x, smoothX);
		pY = Mathf.SmoothDamp (transform.position.y, player.transform.position.y, ref velocity.y, smoothY);

		transform.position = new Vector3 (pX, pY, transform.position.z);
	}

    // Update is called once per frame
    /*private void Update()
    {

        // only update lookahead pos if accelerating or changed direction
        float xMoveDelta = (target.position - lastTargetPosition).x;

        bool updateLookAheadTarget = Mathf.Abs(xMoveDelta) > lookAheadMoveThreshold;

        if (updateLookAheadTarget)
        {
            lookAheadPos = lookAheadFactor*Vector3.right*Mathf.Sign(xMoveDelta);
        }
        else
        {
            lookAheadPos = Vector3.MoveTowards(lookAheadPos, Vector3.zero, Time.deltaTime*lookAheadReturnSpeed);
        }

        Vector3 aheadTargetPos = target.position + lookAheadPos + Vector3.forward*offsetZ;
        Vector3 newPos = Vector3.SmoothDamp(transform.position, aheadTargetPos, ref currentVelocity, damping);

        transform.position = newPos;

        lastTargetPosition = target.position;
    }*/
}
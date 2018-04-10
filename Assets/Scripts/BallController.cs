using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {
    [SerializeField]
    private float m_Force;
    [SerializeField]
    private float m_JumpForce;
    [SerializeField]
    private float m_MaxSpeed = 5f;
    [SerializeField]
    private float m_GroundSensitivity = 0.1f;
    [SerializeField]
    private LayerMask m_GroundLayer = 1<<10;
    private Rigidbody m_Rigidbody;
    private Renderer m_Renderer;
    private Transform m_CameraTransform;
    private AudioSource m_AudioSource_Reset;
    private bool m_IsGrounded;
    private bool m_IsJump;
    private float m_JumpTimer;
    private Vector3 m_GroundContactNormal;
	// Use this for initialization
	void Start () {
        m_CameraTransform = Camera.main.transform;
        m_Rigidbody = GetComponent<Rigidbody>();;
        m_Renderer=GetComponent<Renderer>();
        m_AudioSource_Reset=GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        //判断地面
        RaycastHit raycastHit;
        if(Physics.Raycast(transform.position, Vector3.down, out raycastHit, m_GroundSensitivity+0.5f, m_GroundLayer))
        {
            if (raycastHit.transform.tag != "NotParent")
                transform.parent = raycastHit.transform;
            m_IsGrounded = true;
            m_Rigidbody.drag = 0.5f;
            m_GroundContactNormal = raycastHit.normal;
        }
        else
        {
            transform.parent = null;
            m_IsGrounded = false;
            m_Rigidbody.drag = 0f;
            m_GroundContactNormal = Vector3.up;
        }
        //控制移动
        float horizontal=Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        var direction=Quaternion.AngleAxis(m_CameraTransform.rotation.eulerAngles.y, Vector3.up) *  new Vector3(horizontal, 0, vertical);
        direction=Vector3.ProjectOnPlane(direction, m_GroundContactNormal).normalized;
        m_Rigidbody.AddForce(direction * m_Force);

         
        //跳跃键判断
        if (Input.GetButtonDown("Jump"))
        {
            m_IsJump = true;
        }
        if (m_IsJump)
        {
            m_JumpTimer += Time.fixedDeltaTime;
            if (m_JumpTimer > 0.3f)
            {
                m_JumpTimer = 0;
                m_IsJump = false;
            }
        } 
        //跳跃
        if (m_IsJump && m_IsGrounded)
        {
            m_Rigidbody.velocity -= new Vector3(0, m_Rigidbody.velocity.y, 0);
            m_Rigidbody.AddForce(Vector3.up*m_JumpForce,ForceMode.Impulse);
            transform.parent = null;
            m_IsGrounded = false;
            m_IsJump=false;
        }
        //限制最大速度
        if(m_Rigidbody.velocity.sqrMagnitude > m_MaxSpeed * m_MaxSpeed)
        {
            float y = m_Rigidbody.velocity.y;
            m_Rigidbody.velocity -= new Vector3(0 ,y ,0);
            m_Rigidbody.velocity = m_Rigidbody.velocity.normalized * m_MaxSpeed;
            m_Rigidbody.velocity += new Vector3(0, y, 0);
        } 
	}
    public void SetActiveFalse()
    {
        m_Renderer.enabled = false;
        m_Rigidbody.isKinematic = true;
    }
    public void SetActiveTrue()
    {
        m_Renderer.enabled = true;
        m_Rigidbody.isKinematic = false;
    }
    public IEnumerator Dead()
    {
        SetActiveFalse();
        yield return new WaitForSeconds(1f);
        //复活
        m_AudioSource_Reset.Play();
        var array = CameraManager.s_Instance.CameraArray;
        for (int i = GameManager.s_Instance.CameraIndex + 1; i < array.Length; i++)
        {
            array[i].SetActive(false);
        }
        SetActiveTrue();
        transform.position = GameManager.s_Instance.SavePosition;
    }
}
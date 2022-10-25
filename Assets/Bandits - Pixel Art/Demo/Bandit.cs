using UnityEngine;
using System.Collections;

public class Bandit : MonoBehaviour {

    [SerializeField] float      m_speed;
    [SerializeField] float      m_jumpForce;

    private Animator            m_animator;
    private Rigidbody2D         m_body2d;
    private Sensor_Bandit       m_groundSensor;
    private bool                m_grounded = false;
    private bool                m_combatIdle = false;
    private bool                m_isDead = false;

    //Memanggil Variable
    void Start () {
        m_animator = GetComponent<Animator>();
        m_body2d = GetComponent<Rigidbody2D>();
        m_groundSensor = transform.Find("GroundSensor").GetComponent<Sensor_Bandit>();
    }
	
	// Update is called once per frame
	void Update () {
        //Check Player Menyentuh Tanah
        if (!m_grounded && m_groundSensor.State()) {
            m_grounded = true;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Check Player Jatuh
        if(m_grounded && !m_groundSensor.State()) {
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
        }

        //Input Movement
        float inputX = Input.GetAxis("Horizontal");

        //Merubah Arah Player
        if (inputX > 0)
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        else if (inputX < 0)
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Kecepatan Player
        m_body2d.velocity = new Vector2(inputX * m_speed, m_body2d.velocity.y);

        //Mengatur Animasi Jatuh
        m_animator.SetFloat("AirSpeed", m_body2d.velocity.y);

        //Mengatur Animasi

        //Lompat
        if (Input.GetKeyDown("space") && m_grounded) {
            m_animator.SetTrigger("Jump");
            m_grounded = false;
            m_animator.SetBool("Grounded", m_grounded);
            m_body2d.velocity = new Vector2(m_body2d.velocity.x, m_jumpForce);
            m_groundSensor.Disable(0.2f);
        }

        //Lari
        else if (Mathf.Abs(inputX) > Mathf.Epsilon)
            m_animator.SetInteger("AnimState", 2);

        //Idle
        else
            m_animator.SetInteger("AnimState", 0);
    }
}

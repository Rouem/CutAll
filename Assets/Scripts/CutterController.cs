using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutterController : MonoBehaviour
{

    public float startAngle;

    public float jumpForce;

    public Transform blade;

    public LayerMask fruitLayer;

    public Rigidbody rb { set; get; }

    private bool canJump = true;

    private bool stucked = false;

    private Vector3 startPos;

    private bool gameover = false;

    private void Awake()
    {
        if(GameManager.cutterController != null){
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
        GameManager.cutterController = this;
        Init();
    }

    public void Init()
    {

        transform.eulerAngles = new Vector3(
            startAngle, 90f, 0f
        );
        transform.position = startPos;
        rb.isKinematic = true;
        gameover = false;
        enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameover)
        {
            GameManager.uIManager.gameOver.SetActive(true);
            enabled = false;
            return;
        }
        if (canJump || rb.isKinematic)
        {
            if (Input.GetMouseButtonDown(0))
            {
                StartCoroutine(Slice());
            }
        }
        FruitsCheck();

    }

    private IEnumerator Slice()
    {
        canJump = false;
        rb.isKinematic = false;
        rb.velocity = (Vector3.up * jumpForce) + Vector3.right * 3;
        rb.AddTorque(transform.right * jumpForce, ForceMode.Impulse);
        rb.angularDrag = 0.05f;
        float timer = 0;
        while (timer <= 1f)
        {
            FruitsCheck();
            timer += 1 * Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        stucked = false;
        rb.angularDrag = 0.3f;
        canJump = true;
    }

    public void FruitsCheck()
    {
        var fruits = Physics.OverlapSphere(blade.position, 0.7f, fruitLayer);
        if (fruits != null && fruits.Length > 0)
        {
            fruits[0].GetComponent<SlicedController>().SliceObject();
            if (OnStopPoint())
                rb.angularDrag = 2f;
            else
                rb.angularDrag = 0.05f;
        }
    }

    bool OnStopPoint()
    {
        float anglePos = transform.eulerAngles.x;
        return (anglePos >= 65f && anglePos <= 85f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Solid" && !stucked)
        {
            rb.isKinematic = true;
            stucked = true;
        }
        else
        if (other.tag == "Ground")
        {
            rb.isKinematic = true;
            gameover = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Ground")
        {
            rb.isKinematic = true;
            gameover = true;
        }
    }



}

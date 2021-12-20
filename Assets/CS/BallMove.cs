using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMove : MonoBehaviour
{
    Rigidbody rb;

    Vector3 spanPoint = new Vector3(-77.0f, 21.0f, -90.0f);
    List<Vector3> spanPointList = new List<Vector3>();

    float speed = 25.0f;
    bool isGround = true;
    //public int score = 0;
    public int Score { get; set; }
    public int Stage { get; set; }

    void Start()
    {
        Score = 0;
        Stage = 1;

        rb = GetComponent<Rigidbody>();
        transform.position = spanPoint;

        spanPointList.Add(spanPoint);
        spanPointList.Add(new Vector3(-45.41f, 34.1f, -90.0f));
        spanPointList.Add(new Vector3(0.44f, 48.01f, -90.0f));
        spanPointList.Add(new Vector3(46.0f, 70.0f, -90.0f));


    }

    void Update()
    {

        //if (Input.GetButton("Vertical"))                                                                                      //transform.translate로는 콜라이더 끼리 통과할 수 도 있다. 레이케스트로 막는 방법이 있다는데 .. 
        //    transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * speed);                                //ㄴ https://kin.naver.com/qna/detail.naver?d1id=1&dirId=10403&docId=395326407
        //else if (Input.GetButton("Horizontal"))
        //    transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * speed);

        //if (Input.GetButton("Jump"))
        //    if (isGround)
        //        rb.AddForce(Vector3.up * 10 * Time.deltaTime * speed, ForceMode.Impulse);


        if (Input.GetButton("Vertical"))                                                                                       //오래 누를 수록 velocity가 꾸준히 증가한다. (가속력)
            rb.AddForce(Vector3.forward * Input.GetAxis("Vertical") * speed);                               //time.deltaTime을 곱하면 움직이지 않는다 왜? ㅜㅜ 직전프레임에 움직인 값이 없으니까?????
        else if (Input.GetButton("Horizontal"))
            rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * speed); 

        if (Input.GetButton("Jump"))
            if (isGround)
                rb.AddForce(Vector3.up * 10 * Time.deltaTime * speed, ForceMode.Impulse);                           //벽에 붙어 낑낑거릴때.. 이때도 계속 누르고 있기때문에 velocity가 증가한다. 이 속도에 속도를 더하니 슈퍼점프가 되지...
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "stage")
            isGround = true;
        //else if (collision.gameObject.tag == "Item")                                                       //콜라이더보다 트리커로 구현하는 것이 나을 듯하다.
        //{
        //    //Rigidbody itemRB = collision.collider.GetComponent<Rigidbody>();                                    //사실 이부분은 필요없다. setActive함수와 gameObject는 RigidBody와 무관하다.
        //    collision.gameObject.SetActive(false);
        //}
        else if (collision.gameObject.tag == "floor")
        {
            transform.position = spanPoint;
            rb.velocity = Vector3.zero;
        }
        else if (collision.gameObject.tag == "jumpMachine")
            rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
        else if (collision.gameObject.tag == "N2O")
            rb.AddForce(Vector3.forward * speed, ForceMode.Impulse);
    }
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "stage")
            isGround = false;
    }

    void OnTriggerEnter(Collider other)                                                             //트리거로 구현한다면 두 물체중 한 곳의 트리거가 on되어야한다.
    {                                                                                                           //ㄴ  그러나 볼의 트리거가 켜진다면 바닥과의 콜라이더가 되지 않는다. 따라서 아이템의 트리거를 켠다
        if (other.gameObject.tag == "Item")
        {
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "flag")
        {
            Stage++;
            spanPoint = spanPointList[Stage - 1];
            transform.position = spanPoint;
            rb.velocity = Vector3.zero;
        }
        else if (other.gameObject.tag == "fin")
            SceneManager.LoadScene(1);
    }
}

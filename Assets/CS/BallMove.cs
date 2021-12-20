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

        //if (Input.GetButton("Vertical"))                                                                                      //transform.translate�δ� �ݶ��̴� ���� ����� �� �� �ִ�. �����ɽ�Ʈ�� ���� ����� �ִٴµ� .. 
        //    transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * speed);                                //�� https://kin.naver.com/qna/detail.naver?d1id=1&dirId=10403&docId=395326407
        //else if (Input.GetButton("Horizontal"))
        //    transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * speed);

        //if (Input.GetButton("Jump"))
        //    if (isGround)
        //        rb.AddForce(Vector3.up * 10 * Time.deltaTime * speed, ForceMode.Impulse);


        if (Input.GetButton("Vertical"))                                                                                       //���� ���� ���� velocity�� ������ �����Ѵ�. (���ӷ�)
            rb.AddForce(Vector3.forward * Input.GetAxis("Vertical") * speed);                               //time.deltaTime�� ���ϸ� �������� �ʴ´� ��? �̤� ���������ӿ� ������ ���� �����ϱ�?????
        else if (Input.GetButton("Horizontal"))
            rb.AddForce(Vector3.right * Input.GetAxis("Horizontal") * speed); 

        if (Input.GetButton("Jump"))
            if (isGround)
                rb.AddForce(Vector3.up * 10 * Time.deltaTime * speed, ForceMode.Impulse);                           //���� �پ� �����Ÿ���.. �̶��� ��� ������ �ֱ⶧���� velocity�� �����Ѵ�. �� �ӵ��� �ӵ��� ���ϴ� ���������� ����...
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "stage")
            isGround = true;
        //else if (collision.gameObject.tag == "Item")                                                       //�ݶ��̴����� Ʈ��Ŀ�� �����ϴ� ���� ���� ���ϴ�.
        //{
        //    //Rigidbody itemRB = collision.collider.GetComponent<Rigidbody>();                                    //��� �̺κ��� �ʿ����. setActive�Լ��� gameObject�� RigidBody�� �����ϴ�.
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

    void OnTriggerEnter(Collider other)                                                             //Ʈ���ŷ� �����Ѵٸ� �� ��ü�� �� ���� Ʈ���Ű� on�Ǿ���Ѵ�.
    {                                                                                                           //��  �׷��� ���� Ʈ���Ű� �����ٸ� �ٴڰ��� �ݶ��̴��� ���� �ʴ´�. ���� �������� Ʈ���Ÿ� �Ҵ�
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

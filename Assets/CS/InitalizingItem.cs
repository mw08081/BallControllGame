using UnityEngine;

public class InitalizingItem : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * 50.0f * Time.deltaTime, Space.World);                     //space.world�� ���ٸ� local ��ǥ���� up���Ͱ� ȸ���Ѵ�.
    }

    /*
    void OntiEnter(Collision collision)                                                                    //���⼭ �ݶ��̴�üũ�� ���ϴ� ����... ����� ����� setActive(false)�� ��� ������� ������.
    {
       
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Rigidbody itemRB = GetComponent<Rigidbody>();                                 //��� �̺κ��� �ʿ����. setActive�Լ��� gameObject�� RigidBody�� �����ϴ�.

            gameObject.SetActive(false);                                                    //transform�� ���������� �տ� ���� ������ ��� �ڱ��ڽ����� �����Ѵ�.
            //Debug.Log(gameObject.name);                                                     //�׷��⿡ gameObject�� �̸��� ����Ѵٸ� Item���� ��µȴ�.


            BallMove ballMove = other.GetComponent<BallMove>();
            ballMove.Score++;                                                 //�̰ſ��� ballMove���� pulic���� �����ؼ� �ٷ� ������ �� �־���.
                                                                                    //�� �� �� ���̴� ������ �� ���⿡ ������Ƽ�� �����!!!! ������������
        }
    }
    */
}

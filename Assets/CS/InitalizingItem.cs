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
        transform.Rotate(Vector3.up * 50.0f * Time.deltaTime, Space.World);                     //space.world가 없다면 local 좌표계의 up벡터가 회전한다.
    }

    /*
    void OntiEnter(Collision collision)                                                                    //여기서 콜라이더체크를 안하는 이유... 오디오 출력후 setActive(false)할 경우 오디오가 씹힌다.
    {
       
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Rigidbody itemRB = GetComponent<Rigidbody>();                                 //사실 이부분은 필요없다. setActive함수와 gameObject는 RigidBody와 무관하다.

            gameObject.SetActive(false);                                                    //transform과 마찬가지로 앞에 값을 생략할 경우 자기자신으로 인지한다.
            //Debug.Log(gameObject.name);                                                     //그렇기에 gameObject의 이름을 출력한다면 Item으로 출력된다.


            BallMove ballMove = other.GetComponent<BallMove>();
            ballMove.Score++;                                                 //이거원래 ballMove에서 pulic으로 선언해서 바로 접근할 수 있었음.
                                                                                    //ㄴ 뭐 별 차이는 없으나 난 여기에 프로퍼티를 사용함!!!! ㅎㅎㅎㅎㅎㅎ
        }
    }
    */
}

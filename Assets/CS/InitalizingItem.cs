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
        transform.Rotate(Vector3.up * 50.0f * Time.deltaTime, Space.World);                     //space.world亜 蒸陥檎 local 疎妊域税 up困斗亜 噺穿廃陥.
    }

    /*
    void OntiEnter(Collision collision)                                                                    //食奄辞 紬虞戚希端滴研 照馬澗 戚政... 神巨神 窒径板 setActive(false)拝 井酔 神巨神亜 消微陥.
    {
       
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Rigidbody itemRB = GetComponent<Rigidbody>();                                 //紫叔 戚採歳精 琶推蒸陥. setActive敗呪人 gameObject澗 RigidBody人 巷淫馬陥.

            gameObject.SetActive(false);                                                    //transform引 原濁亜走稽 蒋拭 葵聖 持繰拝 井酔 切奄切重生稽 昔走廃陥.
            //Debug.Log(gameObject.name);                                                     //益係奄拭 gameObject税 戚硯聖 窒径廃陥檎 Item生稽 窒径吉陥.


            BallMove ballMove = other.GetComponent<BallMove>();
            ballMove.Score++;                                                 //戚暗据掘 ballMove拭辞 pulic生稽 識情背辞 郊稽 羨悦拝 呪 赤醸製.
                                                                                    //い 更 紺 託戚澗 蒸生蟹 貝 食奄拭 覗稽遁銅研 紫遂敗!!!! ぞぞぞぞぞぞ
        }
    }
    */
}

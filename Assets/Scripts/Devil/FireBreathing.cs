using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBreathing : MonoBehaviour
{
    [SerializeField]
    private Transform cowboy;
    [SerializeField]
    private float followSpeed = 5f;
    private Vector3 distance;
    private bool parents = false;
    [SerializeField]
    private Rigidbody2D rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Invoke("Destroy", 10f);
        if (parents) return;
        distance = cowboy.position - transform.position;
         FireFollow1();
    }


    private void FireFollow1()
    {
        Vector3 targetpoint = this.cowboy.position - distance.normalized; // ở đây distance là 1 điểm mới khi ta distance.normalize nó sẽ trả về 1 điểm để khi ta tính độ lớn độ này giá trị trả ra luôn bằng 1 
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetpoint, followSpeed * Time.deltaTime);// speed là khoảng cách tối đa di chuyển trong 1 khùng hình, nếu speed càng lớn thì tốc độ càng nhanh 
    }
    /* Cả hai hàm đều có chức năng di chuyển đối tượng theo hướng cowboy, nhưng có những điểm khác nhau về cách tính toán và hiệu quả.
       Ưu điểm của hàm FireFollow() là tính toán đơn giản, chỉ cần sử dụng vị trí hiện tại của cowboy làm vị trí mục tiêu, nên rất dễ hiểu và thực hiện.
       Tuy nhiên, nhược điểm của hàm này là đối tượng sẽ di chuyển theo đường thẳng trực tiếp đến vị trí cowboy, mà không hề đoán trước được hướng di chuyển của cowboy.
       Nếu cowboy di chuyển nhanh hoặc thay đổi hướng di chuyển đột ngột, đối tượng sẽ khó có thể đuổi kịp. 
       Trong khi đó, ưu điểm của hàm FireFollow1() là tính toán vị trí mục tiêu theo hướng của cowboy, 
       nhưng tính toán trước một khoảng cách nhất định, giúp đối tượng có thể đoán trước được hướng di chuyển của cowboy và di chuyển theo hướng đó. */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Terrain"))
        {
            Destroy(gameObject);
        }
        else if (collision.CompareTag("Cowboy"))
        {
            transform.SetParent(collision.transform);
            rb.bodyType = RigidbodyType2D.Kinematic;

        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}

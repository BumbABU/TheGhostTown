using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
    private EnemyManager enemyManager;
    [SerializeField]
    private Transform cowBoy;
    private void Start()
    {
        enemyManager = GetComponent<EnemyManager>();
    }
    public void FollowCowboy()
    {
        //enemyManager.Followcowboy = true;
       
        enemyManager.Speed = 5;
        Vector2 targetpoint = this.cowBoy.position - enemyManager.Distance.normalized; // ở đây distance là 1 điểm mới khi ta distance.normalize nó sẽ trả về 1 điểm để khi ta tính độ lớn độ này giá trị trả ra luôn bằng 1 
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetpoint, enemyManager.Speed * Time.deltaTime);// speed là khoảng cách tối đa di chuyển trong 1 khùng hình, nếu speed càng lớn thì tốc độ càng nhanh 
    }
}

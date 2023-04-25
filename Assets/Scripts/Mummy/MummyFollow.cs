using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyFollow : MonoBehaviour
{
    private MummyAttack mummyAttack;
    [SerializeField]
    private Transform cowBoy;
    private Vector3 distance;
    public Vector3 Distance { get { return distance; } }
    [SerializeField]
    private float distanceTofollow;
    private bool isFollowing;
    public bool IsFollowing { get { return isFollowing; } set { isFollowing = value; } }
    private float distanceY;
    [SerializeField]
    private float distanceYToUnfollow =6f;
    private MumyTakeDamage mummyTakeDamage;
    [SerializeField]
    private float followSpeed =5;

    private void Awake()
    {
        mummyTakeDamage = GetComponent<MumyTakeDamage>();
        mummyAttack = GetComponent<MummyAttack>();
    }
    private void Update()
    {
        if (mummyTakeDamage.IsDeath) return;
        if(mummyAttack.IsAttack) return;

       distanceY = Mathf.Abs(cowBoy.position.y - transform.position.y);
        distance = this.cowBoy.position - transform.position;
        
        if(distance.magnitude < distanceTofollow && !(distanceY > distanceYToUnfollow) || isFollowing && !(distanceY > distanceYToUnfollow))
        {
            FollowCowboy();
            isFollowing = true;
        }
        if(distanceY > distanceYToUnfollow)
        {
            isFollowing = false;
        }
    }
    public void FollowCowboy()
    {
        //enemyManager.Followcowboy = true;

        Vector2 targetpoint = this.cowBoy.position - distance.normalized; // ở đây distance là 1 điểm mới khi ta distance.normalize nó sẽ trả về 1 điểm để khi ta tính độ lớn độ này giá trị trả ra luôn bằng 1 
        gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, targetpoint, followSpeed * Time.deltaTime);// speed là khoảng cách tối đa di chuyển trong 1 khùng hình, nếu speed càng lớn thì tốc độ càng nhanh 
    }
}

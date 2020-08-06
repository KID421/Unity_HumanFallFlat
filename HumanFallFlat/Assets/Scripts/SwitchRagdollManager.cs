using UnityEngine;

public class SwitchRagdollManager : MonoBehaviour
{
    private Animator ani;           // 動畫控制器
    private CapsuleCollider cap;    // 父物件的碰撞器
    private Rigidbody[] rigAll;     // 父物件與所有子物件的剛體

    private void Awake()
    {
        ani = GetComponent<Animator>();             // 取得動畫控制器
        cap = GetComponent<CapsuleCollider>();      // 取得碰撞器

        GetAllRigidbody();      // 取得所有剛體
        SwitchRagdoll(true);    // 取消癱軟
    }

    private void Update()
    {
        Move();

        // 按下數字 1 啟動癱軟
        if (Input.GetKeyDown(KeyCode.S)) SwitchRagdoll(false);
    }

    /// <summary>
    /// 取得所有剛體：父物件與所有子物件
    /// </summary>
    private void GetAllRigidbody()
    {
        rigAll = GetComponentsInChildren<Rigidbody>();
    }

    /// <summary>
    /// 切換模式，布林值 true 為取消癱軟模式，false 為啟動癱軟模式
    /// </summary>
    /// <param name="switchRagdoll"></param>
    private void SwitchRagdoll(bool switchRagdoll)
    {
        // 所有剛體設為運動學 - true 避免癱軟，false 啟動癱軟
        for (int i = 0; i < rigAll.Length; i++) rigAll[i].isKinematic = switchRagdoll;

        ani.enabled = switchRagdoll;    // 父物件動畫控制器 - true 啟動，false 取消
        cap.enabled = switchRagdoll;    // 父物件膠囊碰撞器 - true 啟動，false 取消
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");
        ani.SetFloat("移動", Mathf.Abs(v) + Mathf.Abs(h));
    }
}

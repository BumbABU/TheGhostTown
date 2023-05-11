using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingPanel : MonoBehaviour
{
    public TextMeshProUGUI loadingPercentText;
    public Slider loadingSlider;

    private void OnEnable()
    {
        StartCoroutine(LoadScene());
    }

    private IEnumerator LoadScene()
    {
        yield return null;
        // câu lệnh yield return null giúp coroutine chạy mượt mà hơn
        // và được sử dụng để tạo ra một khoảng thời gian trống trước khi tiếp tục chạy.

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync("Level1");
        // LoadSceneAsync load map bất đồng bộ so với Loadscene là đồng bộ việc chạy bất đồng bộ giùm ta load map mượt mà hơn, nhất là những map lớn
        asyncOperation.allowSceneActivation = false;
        //asyncOperation.allowSceneActivation = false; dòng này là bởi vì ta ngăn nó không chạy vào map "Tilemaplv1" ngay lập tức
        // vì vậy ta set nó = false, và khi ta muốn những tài nguyên được load đến 99% thì ta có thể đổi nó thành true
        // như dòng code dưới đây .
        while (!asyncOperation.isDone) // kiểm tra xem các hoạt động bất đồng bộ đã xong hay chưa
        {
            loadingSlider.value = asyncOperation.progress;
            loadingPercentText.SetText($"LOADING SCENES : {asyncOperation.progress * 100}%");
            if (asyncOperation.progress >= 0.9f) //Thuộc tính progress trả về giá trị từ 0 đến 1, thể hiện tiến độ của quá trình tải hoặc thực hiện tác vụ bất đồng bộ.
            {
                loadingSlider.value = 1f;
                loadingPercentText.SetText("Press the space bar to continue");
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    asyncOperation.allowSceneActivation = true;
                    if (UIManager.HasInstance)
                    {
                        UIManager.Instance.ActiveGamePanel(true);
                        UIManager.Instance.ActiveLoadingPanel(false);
                    }
                    if (GameManager.HasInstance)
                    {
                        GameManager.Instance.StartGame();
                    }
                }
            }
            yield return null;
        }
    }
}

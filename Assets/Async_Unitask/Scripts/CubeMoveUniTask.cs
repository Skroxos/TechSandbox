using Cysharp.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class CubeMoveUniTask : MonoBehaviour
{
    public CancellationTokenSource cancellationTokenSource;



    private void Start()
    {
        var token = this.GetCancellationTokenOnDestroy();

      MoveCubeUniTask(token).Forget();

    }

    public async UniTaskVoid MoveCubeUniTask(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            await UniTask.Yield(PlayerLoopTiming.Update, token);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + Mathf.Sin(Time.time), gameObject.transform.position.z);
        }
    }
}

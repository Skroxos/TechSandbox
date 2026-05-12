using Cysharp.Threading.Tasks;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class CubeMoveAsync : MonoBehaviour
{
    CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

    private async Task Start()
    {
        var token = this.GetCancellationTokenOnDestroy();
        await MoveCubeAsync(token);
    }

    public async Task MoveCubeAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            await Task.Delay(1, token);
            gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + Mathf.Sin(Time.time), gameObject.transform.position.z);
        }
    }
}

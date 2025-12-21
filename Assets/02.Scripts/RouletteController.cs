using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 룰렛 회전을 제어하는 컨트롤러 클래스
/// 마우스 클릭으로 룰렛을 회전시키고, 점진적으로 속도를 감소시켜 자연스러운 정지 효과를 구현합니다.
/// </summary>
public class RouletteController : MonoBehaviour
{
    /// <summary>
    /// 룰렛의 현재 회전 속도 (초당 각도)
    /// 매 프레임마다 감소하여 자연스러운 감속 효과를 만듭니다.
    /// </summary>
    public float rotateSpeed = 0f;

    /// <summary>
    /// 룰렛이 현재 회전 중인지 여부를 나타내는 플래그
    /// true일 때는 새로운 회전 시작을 방지합니다.
    /// </summary>
    public bool isRotating = false;

    /// <summary>
    /// 룰렛 회전이 완전히 종료되었는지 여부를 나타내는 플래그
    /// true일 때만 새로운 회전을 시작할 수 있습니다.
    /// </summary>
    public bool isRotateEnded = true;

    /// <summary>
    /// 게임 시작 시 한 번 호출되는 초기화 메서드
    /// 현재는 사용하지 않지만, 필요시 초기 설정을 여기에 추가할 수 있습니다.
    /// </summary>
    void Start()
    {
        
    }

    /// <summary>
    /// 매 프레임마다 호출되는 업데이트 메서드
    /// 마우스 입력 감지, 룰렛 회전 처리, 속도 감소 로직을 처리합니다.
    /// </summary>
    void Update()
    {
        // 마우스 왼쪽 버튼 클릭 감지 및 회전 시작 조건 확인
        // 조건: 마우스 클릭 && 현재 회전 중이 아님 && 이전 회전이 완전히 종료됨
        if (Input.GetMouseButtonDown(0) && isRotating == false && isRotateEnded == true)
        {
            // 회전 상태 플래그 설정
            isRotating = true;      // 회전 시작 표시
            isRotateEnded = false;  // 회전 종료 플래그 해제

            // 랜덤한 초기 회전 속도 설정 (15도 ~ 30도 사이의 랜덤 값)
            // 이 값이 클수록 룰렛이 더 오래 회전합니다.
            rotateSpeed = Random.Range(15f, 30f);

            // Unity Random 함수 참고 정보
            // float Random.Range(float minInclusive, float maxInclusive);  // float는 양쪽 모두 포함
            // int Random.Range(int minInclusive, int maxExclusive);        // int는 최대값 제외
        }

        // 매 프레임마다 Z축(화면에 수직인 축)을 기준으로 회전 적용
        // Rotate(x, y, z): 각 축을 기준으로 주어진 각도만큼 회전
        // 현재는 Z축만 회전하므로 룰렛이 평면에서 회전하는 효과를 만듭니다.
        transform.Rotate(0, 0, rotateSpeed);

        // 회전 속도를 매 프레임마다 98%로 감소시킴 (2% 감소)
        // 이는 마찰력이나 저항을 시뮬레이션하여 자연스러운 감속 효과를 만듭니다.
        // 0.98을 곱하면 점진적으로 속도가 줄어들어 결국 0에 가까워집니다.
        rotateSpeed *= 0.98f;

        // 현재 회전 속도를 콘솔에 출력 (디버깅용)
        Debug.Log(rotateSpeed);

        // 회전 속도가 거의 0에 도달했는지 확인 (0.05도 이하)
        // 이 임계값은 룰렛이 거의 정지했다고 판단하는 기준입니다.
        if (rotateSpeed <= 0.05f)
        {
            // 회전 속도를 완전히 0으로 설정하여 정지
            rotateSpeed = 0f;

            // 회전 상태 플래그 재설정
            isRotateEnded = true;  // 회전 종료 표시
            isRotating = false;    // 회전 중 플래그 해제
        }
        else 
        {
            // 회전 속도가 아직 충분히 큰 경우, 추가 처리가 필요 없음
            // else 블록은 현재 비어있지만, 필요시 추가 로직을 구현할 수 있습니다.
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEngine.RuleTile.TilingRuleOutput;
using Unity.VisualScripting;

public static partial class GFunc
{
    [System.Diagnostics.Conditional("DEBUG_MODE")]


    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void LogWarning(object message)
    {
#if DEBUG_MODE
        Debug.LogWarning(message);
#endif
    }


    //아래의 코드는 위에서 래핑한 Log 코드와 동일하지만 뒤에 Object context매개변수로
    //글자의 색을 바꿀수 있다
    public static void Log001(object message, Object context)
    {
        Debug.Log(message, context);
    }

    [System.Diagnostics.Conditional("DEBUG_MOD")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif
    }




    //! GameObject 받아서 Text 컴포넌트 찾아서 text 필드 값 수정하는 함수
    public static void SetText(this GameObject target, string text)
    {
        Text textcomponent = target.GetComponent<Text>();
        if (textcomponent == null || textcomponent == default) { return; }

        textcomponent.text = text;
    }


    //! LoadScene 함수 래핑한다.
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    //!두 백터를 더한다.
    public static Vector2 AddVector(this Vector3 origin, Vector2 addVector)
    {
        
        Vector2 result = new Vector2(origin.x, origin.y);
        result += addVector;
        return result;
    }


    //! 현재씬의 이름을 리턴한다
    public static string GetActiveSceneName()
    {
        return SceneManager.GetActiveScene().name;
    }

    //! 컴포넌트가 존재하는지 여부를 체크하는 함수         제한자  = :
    public static bool IsValid<T>(this T target) where T : Component
    {
        if (target == null || target == default) { return false; }
        else { return true; }
    }

    //! 리스트가 유효한지 여부를 체크하는 함수            제한자  = :
    public static bool IsValid<T>(this List<T> target)  //where T : Component //앞에 주석을 풀면 제한자를 Component로 사용가능
    {
        bool isInvalid = (target == null || target == default);
        isInvalid = isInvalid || target.Count == 0; 

        if (isInvalid == true) { return false; }
        else { return true; }
    }

}

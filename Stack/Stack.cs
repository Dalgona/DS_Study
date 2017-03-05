using System;
using System.Text;

namespace Dalgona.DSStudy
{
  public class Stack<TElem>
  {
    private IList<TElem> list = new LinkedList<TElem>();

    // 스택의 맨 위에 요소를 삽입
    public void Push(TElem e)
    {
      if (IsFull)
      {
        throw new Exception("스택이 가득 찼습니다.");
      }
      else
      {
        list.AddFirst(e);
      }
    }

    // 스택의 맨 위에 있는 요소를 제거하고 그 값을 반환
    public TElem Pop()
    {
      if (IsEmpty)
      {
        throw new Exception("스택이 비어있습니다.");
      }
      else
      {
        return list.RemoveAt(0);
      }
    }

    // 스택 비우기
    public void Clear()
    {
      list.Clear();
    }

    // 스택의 맨 위에 있는 요소를 확인만 함
    public TElem Top
    {
      get
      {
        if (IsEmpty)
        {
          throw new Exception("스택이 비어있습니다.");
        }
        else
        {
          return list[0];
        }
      }
    }

    // 스택에 저장된 요소의 개수를 확인
    public int Count
    {
      get { return list.Count; }
    }

    // 스택이 비어있는지 여부를 확인
    public bool IsEmpty
    {
      get { return list.IsEmpty; }
    }

    // 스택이 가득 차 있는지 여부를 확인
    public bool IsFull
    {
      get { return list.IsFull; }
    }

    public override string ToString()
    {
      var sb = new StringBuilder("<Stack: (top->) ");
      for (int i = 0; i < Count; i++)
      {
        sb.Append(list[i]);
        sb.Append(' ');
      }
      sb.Append(">");
      return sb.ToString();
    }
  }
}

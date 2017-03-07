using System;
using System.Text;

namespace Dalgona.DSStudy
{
  public class ArrayList<TElem> : IList<TElem>
  {
    // 배열의 크기 고정
    private const int MaxArraySize = 100;

    // 데이터가 저장될 배열
    private TElem[] array = new TElem[MaxArraySize];

    public ArrayList() { }

    // 새 요소를 리스트의 맨 처음에 추가
    public void AddFirst(TElem e) => AddAt(e, 0);

    // 새 요소를 리스트의 맨 끝에 추가
    public void AddLast(TElem e) => AddAt(e, Count);

    // 새 요소를 리스트의 주어진 위치에 추가
    public void AddAt(TElem e, int index)
    {
      if (IsFull)
      {
        throw new Exception("리스트가 가득 찼습니다.");
      }
      else if (index < 0 || index > Count)
      {
        throw new IndexOutOfRangeException();
      }
      else
      {
        for (int i = Count; i > index; i--)
        {
          array[i] = array[i - 1];
        }
        array[index] = e;
        Count++;
      }
    }

    // 리스트에서 주어진 위치에 저장되어 있는
    // 요소를 삭제하고, 삭제된 요소를 반환
    public TElem RemoveAt(int index)
    {
      if (index < 0 || index >= Count)
      {
        throw new IndexOutOfRangeException();
      }
      else
      {
        var removed = this[index];
        for (int i = index; i < Count - 1; i++)
        {
          array[i] = array[i + 1];
        }
        Count--;
        return removed;
      }
    }

    // 주어진 데이터가 리스트의 요소인지를 반환
    public bool Contains(TElem e)
    {
      for (int i = 0; i < Count; i++)
      {
        if (array[i].Equals(e))
        {
          return true;
        }
      }
      return false;
    }

    // 리스트 비우기
    public void Clear()
    {
      array = new TElem[MaxArraySize];
      Count = 0;
    }

    // 리스트에 저장되어 있는 요소의 수를 반환
    public int Count { get; private set; } = 0;

    // 리스트가 비어있는지 확인
    public bool IsEmpty
    {
      get { return Count == 0; }
    }

    // 리스트가 가득 찼는지 확인
    public bool IsFull
    {
      get { return Count == MaxArraySize; }
    }

    // 리스트상의 주어진 위치에 저장되어 있는 요소를 반환
    public TElem this[int index]
    {
      get
      {
        if (index < 0 || index >= Count)
        {
          throw new IndexOutOfRangeException();
        }
        return array[index];
      }
    }

    public override string ToString()
    {
      var sb = new StringBuilder("<ArrayList: ");
      for (int i = 0; i < Count; i++)
      {
        sb.Append(array[i]);
        sb.Append(' ');
      }
      sb.Append(">");
      return sb.ToString();
    }
  }
}

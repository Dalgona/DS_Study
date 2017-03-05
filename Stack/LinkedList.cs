using System;
using System.Text;

namespace Dalgona.DSStudy
{
  // 연결 리스트 노드
  internal class ListNode<TElem>
  {
    public ListNode(TElem data)
    {
      Data = data;
    }

    public TElem Data { get; set; }

    // 다음 노드에 대한 참조
    public ListNode<TElem> Next { get; set; } = null;
  }

  public class LinkedList<TElem> : IList<TElem>
  {
    // 리스트의 맨 처음 노드에 대한 참조
    private ListNode<TElem> head = null;

    public LinkedList() { }

    // 새 요소를 리스트의 맨 처음에 추가
    public void AddFirst(TElem e)
    {
      var newNode = new ListNode<TElem>(e);
      newNode.Next = head;
      head = newNode;
      Count++;
    }

    // 새 요소를 리스트의 맨 끝에 추가
    public void AddLast(TElem e) => AddAt(e, Count);

    // 새 요소를 리스트의 주어진 위치에 추가
    public void AddAt(TElem e, int index)
    {
      if (index < 0 || index > Count)
      {
        throw new IndexOutOfRangeException();
      }
      else
      {
        if (index == 0)
        {
          AddFirst(e);
        }
        else
        {
          var newNode = new ListNode<TElem>(e);
          var node = head;
          for (int i = 0; i < index - 1; node = node.Next, i++);
          newNode.Next = node.Next;
          node.Next = newNode;
          Count++;
        }
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
        ListNode<TElem> removed;
        if (index == 0)
        {
          removed = head;
          head = removed.Next;
        }
        else
        {
          var node = head;
          for (int i = 0; i < index - 1; node = node.Next, i++);
          removed = node.Next;
          node.Next = removed.Next;
        }
        removed.Next = null;
        Count--;
        return removed.Data;
      }
    }

    // 주어진 데이터가 리스트의 요소인지를 반환
    public bool Contains(TElem e)
    {
      var node = head;
      while (node != null)
      {
        if (node.Data.Equals(e))
        {
          return true;
        }
        node = node.Next;
      }
      return false;
    }

    // 리스트 비우기
    public void Clear()
    {
      head = null;
      Count = 0;
    }

    // 리스트에 저장되어 있는 요소의 수를 반환
    public int Count { get; private set; } = 0;

    // 리스트가 비어있는지 확인
    public bool IsEmpty
    {
      get { return head == null; }
    }

    // 연결 리스트는 무한히 확장 가능하므로 가득 찬 상태가 없음
    public bool IsFull
    {
      get { return false; }
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
        else
        {
          var node = head;
          for (int i = 0; i < index; node = node.Next, i++);
          return node.Data;
        }
      }
    }

    public override string ToString()
    {
      var sb = new StringBuilder("<LinkedList: ");
      var node = head;
      while (node != null)
      {
        sb.Append(node.Data);
        sb.Append(' ');
        node = node.Next;
      }
      sb.Append(">");
      return sb.ToString();
    }
  }
}

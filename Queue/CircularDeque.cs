using System;
using System.Text;

namespace Dalgona.DSStudy
{
  // 원형 배열을 이용한 덱
  public class CircularDeque<TElem> : IDeque<TElem>
  {
    // 배열의 크기 고정
    private const int MaxArraySize = 100;

    // 요소를 저장할 배열
    private TElem[] array = new TElem[MaxArraySize];

    // 덱의 전단을 가리키는 인덱스
    private int front = 0;

    // 덱의 후단을 가리키는 인덱스
    private int rear = 0;

    // 덱의 맨 앞에 요소를 삽입
    public void AddFirst(TElem e)
    {
      if (IsFull)
      {
        throw new Exception("덱이 가득 찼습니다.");
      }
      array[front] = e;
      front = (front - 1 + MaxArraySize) % MaxArraySize;
      Count++;
    }

    // 덱의 맨 뒤에 요소를 삽입
    public void AddLast(TElem e)
    {
      if (IsFull)
      {
        throw new Exception("덱이 가득 찼습니다.");
      }
      rear = (rear + 1) % MaxArraySize;
      array[rear] = e;
      Count++;
    }

    // 덱의 맨 앞에서 요소를 삭제
    public TElem RemoveFirst()
    {
      if (IsEmpty)
      {
        throw new Exception("덱이 비어있습니다.");
      }
      front = (front + 1) % MaxArraySize;
      var value = array[front];
      array[front] = default(TElem);
      Count--;
      return value;
    }

    // 덱의 맨 뒤에서 요소를 삭제
    public TElem RemoveLast()
    {
      if (IsEmpty)
      {
        throw new Exception("덱이 비어있습니다.");
      }
      var value = array[rear];
      array[rear] = default(TElem);
      rear = (rear - 1 + MaxArraySize) % MaxArraySize;
      Count--;
      return value;
    }

    // 덱의 맨 앞에 있는 요소를 확인
    public TElem Front
    {
      get
      {
        if (IsEmpty)
        {
          throw new Exception("덱이 비어있습니다.");
        }
        return array[(front + 1) % MaxArraySize];
      }
    }

    // 덱의 맨 뒤에 있는 요소를 확인
    public TElem Rear
    {
      get
      {
        if (IsEmpty)
        {
          throw new Exception("덱이 비어있습니다.");
        }
        return array[rear];
      }
    }

    // 덱에 저장되어 있는 요소의 수
    public int Count { get; private set; } = 0;

    // 덱이 비어있는지 여부를 확인
    public bool IsEmpty
    {
      get { return front == rear; }
    }

    // 덱이 가득 차 있는지 여부를 확인
    public bool IsFull
    {
      get { return front % MaxArraySize == (rear + 1) % MaxArraySize; }
    }

    public override string ToString()
    {
      var sb = new StringBuilder("<CircularDeque: (front)");
      for (int i = front; i != rear; i = (i + 1) % MaxArraySize)
      {
        sb.Append(' ');
        sb.Append(array[(i + 1) % MaxArraySize]);
      }
      sb.Append(" (rear)>");
      return sb.ToString();
    }
  }
}

using System.Text;

namespace Dalgona.DSStudy
{
  // 리스트를 이용한 큐
  public class ListQueue<TElem> : IQueue<TElem>
  {
    private IList<TElem> list = new ArrayList<TElem>();

    // 큐의 맨 뒤에 요소를 삽입
    public void Enqueue(TElem e) => list.AddLast(e);

    // 큐의 맨 앞에서 요소를 삭제
    public TElem Dequeue() => list.RemoveAt(0);

    // 큐의 맨 앞에 있는 요소를 확인
    public TElem Front => list[0];

    // 큐에 저장되어 있는 요소의 수
    public int Count
    {
      get { return list.Count; }
    }

    // 큐가 비어있는지 여부를 확인
    public bool IsEmpty
    {
      get { return list.IsEmpty; }
    }

    // 큐가 가득 차 있는지 여부를 확인
    public bool IsFull
    {
      get { return list.IsFull; }
    }

    public override string ToString()
    {
      var sb = new StringBuilder("<ListQueue: (front)");
      for (int i = 0; i < list.Count; i++)
      {
        sb.Append(' ');
        sb.Append(list[i]);
      }
      sb.Append(" (rear)>");
      return sb.ToString();
    }
  }
}

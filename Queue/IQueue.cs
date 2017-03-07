public interface IQueue<TElem>
{
  // 큐의 맨 뒤에 요소를 삽입
  void Enqueue(TElem e);

  // 큐의 맨 앞에서 요소를 삭제
  TElem Dequeue();

  // 큐의 맨 앞에 있는 요소를 확인
  TElem Front { get; }

  // 큐에 저장되어 있는 요소의 수
  int Count { get; }

  // 큐가 비어있는지 여부를 확인
  bool IsEmpty { get; }

  // 큐가 가득 차 있는지 여부를 확인
  bool IsFull { get; }
}
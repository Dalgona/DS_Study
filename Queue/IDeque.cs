public interface IDeque<TElem>
{
  // 덱의 맨 앞에 요소를 삽입
  void AddFirst(TElem e);

  // 덱의 맨 뒤에 요소를 삽입
  void AddLast(TElem e);

  // 덱의 맨 앞에서 요소를 삭제
  TElem RemoveFirst();

  // 덱의 맨 뒤에서 요소를 삭제
  TElem RemoveLast();

  // 덱의 맨 앞에 있는 요소를 확인
  TElem Front { get; }

  // 덱의 맨 뒤에 있는 요소를 확인
  TElem Rear { get; }

  // 덱에 저장되어 있는 요소의 수
  int Count { get; }

  // 덱이 비어있는지 여부를 확인
  bool IsEmpty { get; }

  // 덱이 가득 차 있는지 여부를 확인
  bool IsFull { get; }
}
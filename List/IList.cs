using System;

namespace Dalgona.DSStudy
{
  public interface IList<TElem>
  {
    // 새 요소를 리스트의 맨 처음에 추가
    void AddFirst(TElem e);

    // 새 요소를 리스트의 맨 끝에 추가
    void AddLast(TElem e);

    // 새 요소를 리스트의 주어진 위치에 추가
    void AddAt(TElem e, int index);

    // 리스트에서 주어진 위치에 저장되어 있는 요소를 삭제
    TElem RemoveAt(int index);

    // 주어진 데이터가 리스트의 요소인지를 반환
    bool Contains(TElem e);

    // 리스트 비우기
    void Clear();

    // 리스트에 저장되어 있는 요소의 수를 반환
    int Count { get; }

    // 리스트가 비어있는지 확인
    bool IsEmpty { get; }

    // 리스트가 가득 찼는지 확인
    bool IsFull { get; }

    // 리스트상의 주어진 위치에 저장되어 있는 요소를 반환
    TElem this[int index] { get; }
  }
}

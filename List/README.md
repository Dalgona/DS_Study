# 리스트(List)

리스트란 데이터를 순차적으로 저장하는 자료 구조이다. 리스트를 이용하여 나타내기
쉬운 것들의 예로는 학생 명부, 음반의 트랙 리스트, 수열 등이 있다.

## 구현

리스트는 배열 리스트나 연결 리스트로 구현할 수 있으며, 연결 리스트는 또다시 단일
연결 리스트, 이중 연결 리스트, 원형 연결 리스트 등으로 구현할 수 있다. 여기서는
배열 리스트와 단일 연결 리스트를 구현해 볼 것이다.

### 리스트 인터페이스

배열 리스트와 연결 리스트는 내부 구현이 다르지만 아래의 `IList<TElem>`
인터페이스를 구현함으로써 일관된 사용법을 제공한다.

```cs
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
```

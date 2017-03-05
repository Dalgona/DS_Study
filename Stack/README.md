# 스택(Stack)

스택은 리스트와 마찬가지로 데이터를 순차적으로 저장하는 자료구조의 일종인데, 스택의 요소는 스택의 맨 위에만 삽입될 수 있고, 스택의 맨 위에 있는 요소만 삭제될 수 있다. 즉, 가장 나중에 삽입된 요소가 가장 먼저 삭제된다. 이러한 동작 방식을 LIFO(Last-in, First-out)이라고 한다. 접시 위에 팬케익을 차곡차곡 쌓고, 접시의 맨 위에 있는 팬케익부터 먹는 것을 생각하면 편할 것이다.

스택 자료구조는 중첩된 프로시저의 호출 및 반환이나 탐색, 수식의 연산 등에 사용된다.

## 구현

스택은 내부적으로 [리스트](https://github.com/Dalgona/DS_Study/tree/master/List)를 사용하여 구현된다. `ArrayList<TElem>`와 `LinkedList<TElem>` 이 두 가지 종류의 리스트가 구현되어 있는데, 추상적인 `IList<TElem>` 인터페이스를 통해 접근할 것이므로 무엇을 쓰든 딱히 상관은 없을 것이다. 여기서는 연결 리스트를 사용하여 구현할 것이다.

### 스택 자료구조의 명세

```cs
public class Stack<TElem>
{
  private IList<TElem> list = new LinkedList<TElem>();

  // 스택의 맨 위에 요소를 삽입
  public void Push(TElem e) { /* ... */ }

  // 스택의 맨 위에 있는 요소를 제거하고 그 값을 반환
  public TElem Pop() { /* ... */ }

  // 스택 비우기
  public void Clear() { /* ... */ }

  // 스택의 맨 위에 있는 요소를 확인만 함
  public TElem Top { get { /* ... */ } }

  // 스택에 저장된 요소의 개수를 확인
  public int Count { get { /* ... */ } }

  // 스택이 비어있는지 여부를 확인
  public bool IsEmpty { get { /* ... */ } }

  // 스택이 가득 차 있는지 여부를 확인
  public bool IsFull { get { /* ... */ } }

  public override string ToString() { /* ... */ }
}
```

위 메서드와 속성 Accessor들은 전부 `list`의 인스턴스 메서드와 속성만을 사용하여 간단하게 구현이 가능하다.

## 스택의 연산

### Push

Push는 스택의 맨 위에 요소를 추가하는 연산이다.

```
  Push(C)       Push(D)

  |  C↓ |       |  D↓ |       |     |
  |     |       |     |       |  D  |<-Top
  |     |       |  C  |<-Top  |  C  |
  |  B  |<-Top  |  B  |       |  B  |
  |  A  |       |  A  |       |  A  |
  +-----+       +-----+       +-----+
```

### Pop(+ Peek)

Pop은 스택의 맨 위에 있는 요소 하나를 꺼내는 연산이다. 꼭대기에 있는 요소를 꺼내지 않고 값만 확인하는 Peek 연산을 구현하는 경우도 있다.

```
  Pop()         Pop()         Peek()
                                  👀 "음... B가 들어있군!"
  |     |       |     |       |     |
  |  D↑ |<-Top  |     |       |     |
  |  C  |       |  C↑ |<-Top  |     |
  |  B  |       |  B  |       |  B  |<-Top
  |  A  |       |  A  |       |  A  |
  +-----+       +-----+       +-----+
```
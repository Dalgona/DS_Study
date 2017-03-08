# 큐(Queue)와 덱(Deque)

큐는 데이터를 순차적으로 저장하는 자료 구조이다. 스택과 마찬가지로, 큐에도 요소를 삽입하고 삭제하는 규칙이 있는데, 새 요소는 항상 큐의 맨 뒤에 삽입하고, 큐의 맨 앞에 있는 요소만 삭제가 가능하다. 이러한 동작 방식을 FIFO(First in, First out)이라고 한다.

실생활에서 찾아볼 수 있는 큐의 가장 대표적인 예로 매표소 앞에서 차례를 기다리며 줄을 서 있는 사람들이 있다.

덱(Deque)은 Double-ended queue의 준말로, 이름에서 알 수 있듯이 양쪽 끝에서 요소의 삽입과 삭제가 가능한 특수한 큐이다.

## 큐의 구현

큐는 내부적으로 배열, 연결 리스트, 원형 배열 등을 이용하여 구현할 수 있다. 원형 배열이란 배열의 처음과 끝을 논리적으로 이어 붙여 사용하는 것이다. 여기서는 원형 배열을 사용하여 구현해 볼 것이다.

### 큐 인터페이스

```cs
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
```

### 리스트를 이용한 큐?

큐는 리스트와 마찬가지로 데이터를 1차원 공간에 저장하는 자료구조이므로 내부적으로 리스트를 사용하여 구현할 수 있다.

```cs
public class ListQueue<TElem> : IQueue<TElem>
{
  private IList<TElem> list;

  /* IQueue<TElem> 인터페이스 구현 */

  public override string ToString() { /* ... */ }
}
```

하지만 배열 리스트를 사용하는 경우 큐의 전단에서 요소를 삭제할 때마다 배열의 모든 요소를 한 칸씩 앞으로 이동해야 한다는 문제점이 있고, 연결 리스트를 사용하는 경우 큐의 후단에 새 요소를 삽입할 때마다 리스트의 모든 노드를 방문해야 한다는 문제점이 있기 때문에 리스트를 사용하여 큐를 구현하는 것은 그다지 바람직하지 않다.

### 원형 큐

원형 큐는 내부적으로 양 쪽 끝을 이어붙여 원형의 고리 모양으로 만든 배열을 사용하여 구현된 큐이다.

```cs
public class CircularQueue<TElem> : IQueue<TElem>
{
  // 배열의 크기 고정
  private const int MaxArraySize = 100;

  // 요소를 저장할 배열
  private TElem[] array = new TElem[MaxArraySize];

  // 큐의 전단을 가리키는 인덱스
  private int front = 0;

  // 큐의 후단을 가리키는 인덱스
  private int rear = 0;

  /* IQueue<TElem> 인터페이스 구현 */

  public override string ToString() { /* ... */ }
}
```

우선 원형 큐가 비어있는 상태는 큐의 전단과 후단을 가리키는 인덱스가 같을 때로 정의한다.

```
[비어있는 상태]
                 (5)    0     1     2     3     4     5    (0)
                  ---+-----+-----+-----+-----+-----+-----+---
TElem[] array =  ... |     |     |     |     |     |     | ...
                  ---+-----+-----+-----+-----+-----+-----+---
                      ^ front, rear
```

원형 큐에 요소를 삽입할 때는 `rear`가 한 칸 앞으로 이동하고, 삭제할 때는 `front`가 한 칸 앞으로 이동한다. 큐가 가득 찬 상태는 `rear`가 배열의 끝에서 처음으로 되돌아(wrap-around) `front`의 바로 앞까지 도달했을 때로 정의한다.

```
[가득 찬 상태]
                 (5)    0     1     2     3     4     5    (0)
                  ---+-----+-----+-----+-----+-----+-----+---
TElem[] array =  ... |  C  |  D  |  E  |     |  A  |  B  | ...
                  ---+-----+-----+-----+-----+-----+-----+---
                                        ^ front
                                  ^ rear
```

원형 큐가 비어있는 상태와 가득 찬 상태를 구별하기 위해 `front`가 가리키는 칸은 항상 비워 둔다. 따라서 아래와 같은 상태는 허용되지 않는다. (즉 원형 큐의 최대 용량은 `(MaxArraySize - 1)`이다.)

```
[*허용되지 않는 상태]
                 (5)    0     1     2     3     4     5    (0)
                  ---+-----+-----+-----+-----+-----+-----+---
TElem[] array =  ... |  E  | *F  |  A  |  B  |  C  |  D  | ...
                  ---+-----+-----+-----+-----+-----+-----+---
                            ^ front, rear
```

원형 큐를 구현할 때는 전단과 후단을 가리키는 인덱스가 배열의 범위를 넘어갈 때마다 배열의 처음으로 되돌리는 처리를 해야 하는데, 이는 나머지 연산으로 쉽게 구현할 수 있다.

```
                                      (6)   (7)   (8)   (9)
         1     2     3     4     5  |  0     1     2     3
   ---+-----+-----+-----+-----+-----+-----+-----+-----+-----+---
  ... |  C  |  D  |     |     |  A  |  B  |  C  |  D  |     | ...
   ---+-----+-----+-----+-----+-----+-----+-----+-----+-----+---
             ^ rear      ^ front                (^ rear)

  rear = 8 % MaxArraySize
       => 2
```

따라서 인덱스를 한 칸 앞으로 옮기는 처리는 다음과 같이 한다.

```cs
index = (index + 1) % MaxArraySize;
```

## 덱의 구현

덱도 원형 배열을 이용하여 큐와 같은 방법으로 구현할 수 있다. 다만 덱은 양쪽 끝에서 요소의 삽입과 삭제가 둘 다 가능하다는 차이점이 있다.

### 덱 인터페이스

```cs
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
```

### 원형 덱

```cs
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

  /* IDeque<TElem> 인터페이스 구현 */

  public override string ToString() { /* ... */ }
}
```

원형 덱을 구현할 때도 앞에서 설명한 규칙이 적용된다. 다만 원형 큐에서는 `front`와 `rear` 인덱스가 앞으로만 이동하는 반면에, 덱에서는 상황에 따라 앞뒤로 이동할 수 있다. 인덱스를 뒤로 한 칸 이동시키면서 인덱스 값이 음수가 될 수도 있으므로 다음과 같이 처리를 해 주어야 한다.

```cs
index = (index - 1 + MaxArraySize) % MaxArraySize;
```

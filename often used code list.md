## 이번 PJ중에 자주 사용할 코드 뭉치 보관소


### 맵 테두리에 벽 채우기
``` csharp
for (int y = 0; y < _field.GetLength(0); y++)
        {
            for (int x = 0; x < _field.GetLength(1); x++)
            {
                _field[0, x].OnTileObject = new Wall();
                _field[_field.GetLength(0) - 1, x].OnTileObject = new Wall();
                _field[y, 0].OnTileObject = new Wall();
                _field[y, _field.GetLength(1) - 1].OnTileObject = new Wall();
            }
        }
```

### 
``` csharp

```

### 
``` csharp

```

### 
``` csharp

```

### 
``` csharp

```

### 
``` csharp

```

### 
``` csharp

```

### 
``` csharp

```

### 
``` csharp

```

### 
``` csharp

```

### 
``` csharp

```

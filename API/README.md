# Система ошибок

## Описание

В проекте используется централизованная система ошибок на основе класса `AppError`.

Каждая ошибка имеет:

- строковый ключ (`Key`) — человекочитаемый идентификатор;
- числовой код (`Code`) — уникальный код для программной обработки.

Все ошибки создаются через `AppErrorFactory` с заданными шаблонами или через `AppError`, с использованием метода `Create`, и автоматически регистрируются. Во время регистрации выполняется проверка уникальности кодов и ключей.

---

# Структура ключа

Формат:

```text
<Scope>.<Entity>[.<Property>].<Error>
```

| Часть | Описание |
|-------|----------|
| Scope | Область ошибки |
| Entity | Сущность, объект или системный компонент |
| Property | Свойство (если применимо) |
| Error | Тип ошибки |

## Примеры

```text
INTERNAL.SERVICE.NOT_FOUND

ENTITY.USER.NOT_FOUND
ENTITY.USER.EMAIL.ALREADY_EXISTS

OBJECT.USER.EMAIL.INVALID_FORMAT
OBJECT.USER.USERNAME.REQUIRED
```

---

# Структура кода

Формат:

```text
Scope_EntityType_PropertyType_Error
```

Все четыре разряда являются обязательными.

Например:

```text
2_01_03_50
```

| Часть | Описание |
|-------|----------|
| Scope | Область ошибки |
| EntityType | Тип сущности, объекта или системного компонента |
| PropertyType | Свойство (`00`, если отсутствует) |
| Error | Тип ошибки |

---

# Scope

| Код | Область |
|----:|----------|
| 1 | INTERNAL |
| 2 | ENTITY |
| 3 | OBJECT |

---

# INTERNAL

Используется для внутренних ошибок приложения.

```
1_EntityType_PropertyType_Error
```

- **EntityType** — системный компонент (`SERVICE`, `APP_ERROR`, `DATABASE` и т.д.).
- **PropertyType** — свойство компонента (`CODE`, `KEY` и т.д.). Если ошибка относится ко всему компоненту, используется `00`.
- **Error** — тип ошибки.

### Примеры

```text
1_03_00_40
```

```text
INTERNAL.SERVICE.NOT_FOUND
```

---

```text
1_01_01_50
```

```text
INTERNAL.APP_ERROR.CODE.ALREADY_EXISTS
```

---

# ENTITY

Используется для ошибок доменных сущностей.

```
2_EntityType_PropertyType_Error
```

- **EntityType** — код сущности (`USER`, `ROLE`, `PRODUCT` и т.д.).
- **PropertyType** — код свойства сущности (`USERNAME`, `EMAIL` и т.д.). Если ошибка относится ко всей сущности, используется `00`.
- **Error** — тип ошибки.

### Примеры

```text
2_01_00_40
```

```text
ENTITY.USER.NOT_FOUND
```

---

```text
2_01_03_50
```

```text
ENTITY.USER.EMAIL.ALREADY_EXISTS
```

---

# OBJECT

Используется для ошибок `Value Object`.

```
3_EntityType_PropertyType_Error
```

- **EntityType** — словарь ошибок (`UserObjectErrors`, `OrderObjectErrors` и т.д.).
- **PropertyType** — объект внутри словаря (`USER_ID`, `USERNAME`, `EMAIL` и т.д.).
- **Error** — тип ошибки.

Таким образом один словарь может содержать ошибки нескольких связанных объектов.

### Примеры

```text
3_01_01_15
```

```text
OBJECT.USER.USER_ID.TOO_SMALL
```

---

```text
3_01_03_13
```

```text
OBJECT.USER.EMAIL.INVALID_FORMAT
```

---

```text
3_01_02_10
```

```text
OBJECT.USER.USERNAME.REQUIRED
```

---

# Типы ошибок

| Код | Ошибка |
|----:|---------|
| 00 | UNKNOWN |
| 10 | REQUIRED |
| 11 | INVALID |
| 12 | INVALID_LENGTH |
| 13 | INVALID_FORMAT |
| 14 | OUT_OF_RANGE |
| 15 | TOO_SMALL |
| 16 | TOO_LARGE |
| 20 | UNAUTHORIZED |
| 21 | FORBIDDEN |
| 30 | INVALID_STATE |
| 31 | EXPIRED |
| 32 | DISABLED |
| 33 | LOCKED |
| 40 | NOT_FOUND |
| 50 | ALREADY_EXISTS |
| 51 | CONFLICT |
| 60 | IN_USE |
| 61 | LIMIT_EXCEEDED |
| 70 | EXTERNAL_SERVICE_ERROR |
| 80 | DATABASE_ERROR |
| 90 | INTERNAL_ERROR |
| 91 | NOT_IMPLEMENTED |

---

# Создание ошибок

Все ошибки создаются только через `AppErrorFactory`.

Пример:

```csharp
public static readonly AppError UserNotFound =
    AppErrorFactory.CreateNotFound("ENTITY.USER", 2_01_00);

public static readonly AppError UserEmailAlreadyExists =
    AppErrorFactory.CreateAlreadyExists("ENTITY.USER.EMAIL", 2_01_03);

public static readonly AppError EmailIsInvalidFormat =
    AppErrorFactory.CreateInvalidFormat("OBJECT.USER.EMAIL", 3_01_03);
```

---

# Регистрация

Каждый словарь ошибок содержит метод `Initialize()`, который принудительно обращается ко всем статическим полям.

Это позволяет при запуске приложения:

- зарегистрировать все ошибки;
- проверить уникальность кодов;
- проверить уникальность ключей;
- обнаружить ошибки конфигурации до начала работы приложения.

---

# Обработка

При возникновении `AppException` соответствующий `AppError` преобразуется в `BusinessException` специализированным обработчиком.

Каждый обработчик использует словарь:

```csharp
Dictionary<AppError, BusinessException>
```

что обеспечивает поиск соответствующего сообщения и HTTP-статуса за `O(1)`.
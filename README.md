# EventTrackingService

## Использование API

### 1) Insomnia



#### POST запрос для добавления события
URL: base

#### JSON
```json
{
"name": "pim",
"value": 10,
"timestamp": "2024-06-19T20:40:20.000Z"
}
```

#### GET запрос для получения summary

```URL
URL: http://localhost:5181/api/event/summary?startTime=2024-05-19T20%3A40%3A00.000Z&endTime=2024-07-19T21%3A40%3A00.000Z
```

### 2) Swagger

#### JSON

```json
{
  "name": "pim",
  "value": 10,
  "timestamp": "2024-06-19T20:40:20.000Z"
}
```

Start time: 
```
2024-05-19T20:40:00.000Z 
```
End time: 
```
2024-07-19T21:40:00.000Z
```

# Calc API document

## Response
| Parameter  | Type | Description |
| ------------- | ------------- | ------------- |
| Succ  | bool  | Is success or not |
| Code  | string | Error code |
| Message  | string | Error message |
| DateTime  | datetime | Execute date time |
| Data  | datetime | Result |

### Error Code
| Code  | Description |
| ------------- | ------------- |
| 200  | Success |
| 400  | Overflow |
| 401  | Divisor is zero |
| 402  | Unknow error |
| 500  | Exception |

## API

### Add
POST host/CalcApi/add

| Parameter  | Type |
| ------------- | ------------- |
| number1  | decimal |
| number2  | decimal |

### Subtract
POST host/CalcApi/subtract

| Parameter  | Type |
| ------------- | ------------- |
| number1  | decimal |
| number2  | decimal |

### Multiply
POST host/CalcApi/multiply

| Parameter  | Type |
| ------------- | ------------- |
| number1  | decimal |
| number2  | decimal |

### Divide
POST host/CalcApi/divide

| Parameter  | Type |
| ------------- | ------------- |
| number1  | decimal |
| number2  | decimal |

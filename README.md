# OrderOfClassProperties

此範例程式碼中 LoginViewModel 類別會有兩種不同的寫法

- 將 Errors 屬性放在 ToModel 前面
- 將 ToModel 屬性放到 Errors 前面

程式碼中不指定 Password 屬性應該要出現驗證訊息但結果不然

### 將 Errors 屬性放在 ToModel 前面

```
LoginViewModel
{
  "Email": "txstudio@outlook.com",
  "Password": null,
  "Errors": null,
  "ToModel": {
    "Email": "txstudio@outlook.com",
    "Password": null
  },
  "IsValid": false
}

LoginModel
{
  "Email": "txstudio@outlook.com",
  "Password": null
}
```

### 將 ToModel 屬性放到 Errors 前面

```
LoginViewModel
{
  "Email": "txstudio@outlook.com",
  "Password": null,
  "ToModel": {
    "Email": "txstudio@outlook.com",
    "Password": null
  },
  "Errors": [
    "Password is required !"
  ],
  "IsValid": false
}

LoginModel
{
  "Email": "txstudio@outlook.com",
  "Password": null
}
```

可以發現 case 1 雖然沒有指定 Password 但並沒有在 Errors 屬性中顯示錯誤訊息

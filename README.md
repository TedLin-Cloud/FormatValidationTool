# FormatValidationTool

格式驗證工具

-------------
## 功能
1. 新式身分證及舊式居留證檢核


## 如何使用

### class
```csharp
public class ConnList
{
    /// <summary>
    /// 新式身分證
    /// </summary>
    public void TestMethod1()
    {
        var value = "A123456789";
        var result = value.IDFormatValidation("1");
        Assert.AreEqual(result, true);
    }

    /// <summary>
    /// 舊式居留證
    /// </summary>
    public void TestMethod2()
    {
        var value = "A123456789";
        var result = value.ChkResident();
        Assert.AreEqual(result, false);
    }

    /// <summary>
    /// 新式身分證及舊式居留證檢核
    /// </summary>
    [TestMethod]
    public void TestMethod3()
    {
        var value = "A123456789";
        var result = value.ChkIDAndResident();
        Assert.AreEqual(result, true);
    }
}

public class Idmodel1
{
    [CustID(ErrorMessage = "身分證格式錯誤")]
    public string ID { get; set; } = string.Empty;
    [Resident(ErrorMessage = "舊式居留證格式錯誤")]
    public string ID { get; set; } = string.Empty;
    [CustIDAndResident(ErrorMessage = "身分證及舊式居留證格式錯誤")]
    public string ID { get; set; } = string.Empty;
}
```


| Version  | Author | Dependencies |  Last updated   | 說明 |
| ------------| ------------|------------|------------ | ------------ |
| 1.0.0  | Tedlin | net6.0| 2023/03/31 | 新增ID驗證 |
| 1.0.1  | Tedlin | net6.0| 2023/04/06 | 將驗證Function拆分 |
| 1.0.2  | Tedlin | netstandard2.0| 2023/12/13 | 改為netstandard2.0 |

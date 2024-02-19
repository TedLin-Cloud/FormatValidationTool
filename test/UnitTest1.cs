using FormatValidationTool;
using FormatValidationTool.FormatValidations;
using System.ComponentModel.DataAnnotations;

namespace FormatValidationToolTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// 新式身分證 成功
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            var value = "A123456789";
            var result = value.ChkID();
            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// 舊式居留證 失敗
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            var value = "A123456789";
            var result = value.ChkResident();
            Assert.AreEqual(result, false);
        }

        /// <summary>
        /// 一起檢核 成功
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            var value = "A123456789";
            var result = value.ChkIDAndResident();
            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// model 驗證 新式 成功
        /// </summary>
        [TestMethod]
        public void TestMethod4()
        {
            var value = new Idmodel1()
            {
                ID = "A123456789"
            };
            Assert.IsTrue(ValidateModel(value));
        }

        /// <summary>
        /// model 驗證 居留證 失敗
        /// </summary>
        [TestMethod]
        public void TestMethod5()
        {
            var value = new Idmodel2()
            {
                ID = "A123456789"
            };
            Assert.IsFalse(ValidateModel(value));
        }

        /// <summary>
        /// model 驗證 一起 成功
        /// </summary>
        [TestMethod]
        public void TestMethod6()
        {
            var value = new Idmodel3()
            {
                ID = "A123456789"
            };
            Assert.IsTrue(ValidateModel(value));
        }

        /// <summary>
        /// model 驗證 居留證 成功
        /// </summary>
        [TestMethod]
        public void TestMethod7()
        {
            var value = "FA12345689";
            var result = value.ChkResident();
            Assert.AreEqual(result, true);
        }

        private static bool ValidateModel(object model)
        {
            var validationResults = new List<ValidationResult>();
            var ctx = new ValidationContext(model, null, null);
            
            return Validator.TryValidateObject(model, ctx, validationResults, true);
        }
    }
    public class Idmodel1
    {
        [CustID(ErrorMessage = "身分證格式錯誤")]
        public string ID { get; set; } = string.Empty;
    }

    public class Idmodel2
    {
        [Resident(ErrorMessage = "身分證格式錯誤")]
        public string ID { get; set; } = string.Empty;
    }

    public class Idmodel3
    {
        [CustIDAndResident(ErrorMessage = "身分證格式錯誤")]
        public string ID { get; set; } = string.Empty;
    }
}
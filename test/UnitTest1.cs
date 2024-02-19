using FormatValidationTool;
using FormatValidationTool.FormatValidations;
using System.ComponentModel.DataAnnotations;

namespace FormatValidationToolTest
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// �s�������� ���\
        /// </summary>
        [TestMethod]
        public void TestMethod1()
        {
            var value = "A123456789";
            var result = value.ChkID();
            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// �¦��~�d�� ����
        /// </summary>
        [TestMethod]
        public void TestMethod2()
        {
            var value = "A123456789";
            var result = value.ChkResident();
            Assert.AreEqual(result, false);
        }

        /// <summary>
        /// �@�_�ˮ� ���\
        /// </summary>
        [TestMethod]
        public void TestMethod3()
        {
            var value = "A123456789";
            var result = value.ChkIDAndResident();
            Assert.AreEqual(result, true);
        }

        /// <summary>
        /// model ���� �s�� ���\
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
        /// model ���� �~�d�� ����
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
        /// model ���� �@�_ ���\
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
        /// model ���� �~�d�� ���\
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
        [CustID(ErrorMessage = "�����Ү榡���~")]
        public string ID { get; set; } = string.Empty;
    }

    public class Idmodel2
    {
        [Resident(ErrorMessage = "�����Ү榡���~")]
        public string ID { get; set; } = string.Empty;
    }

    public class Idmodel3
    {
        [CustIDAndResident(ErrorMessage = "�����Ү榡���~")]
        public string ID { get; set; } = string.Empty;
    }
}
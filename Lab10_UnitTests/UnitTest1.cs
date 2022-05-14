using Xunit;
using Lab10_Interfaces;

namespace Lab10_UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethod1()                               //тестирование конструкторов класса Student
        {
            Student a = new Student();
            Assert.Equal(new Student("NoName", 0), a);
        }
        [Fact]
        public void TestMethod2()                               //тестирование конструкторов класса Challenge
        {
            Challenge a = new Challenge();
            Assert.Equal(new Challenge(0, "NoName"), a);
        }
        [Fact]
        public void TestMethod3()                               //тестирование конструкторов класса Test
        {
            Test a = new Test();
            a.Name = "Test";
            Assert.Equal(new Test("NoName", 0), a);
        }
        [Fact]
        public void TestMethod4()                               //тестирование конструкторов класса Exam
        {
            Exam a = new Exam();
            a.Name = "Exam";
            Assert.Equal(new Exam("NoName", 0), a);
        }
        [Fact]
        public void TestMethod5()                               //тестирование конструкторов класса FinalExam
        {
            FinalExam a = new FinalExam();
            a.Name = "FinalExam";
            Assert.Equal(new FinalExam("NoName", 0), a);
        }
        [Fact]
        public void TestMethod6()                               //тестирование SortByGrade
        {
            Challenge a = new Challenge();
            Challenge b = new Challenge();
            Assert.Equal(0, (new SortByGrade()).Compare(a, b));
        }
        [Fact]
        public void TestMethod7()                               //тестирование CompareTo 
        {
            Challenge a = new Challenge();
            Challenge b = new Challenge();
            Assert.Equal(0, a.CompareTo(b));
        }
        [Fact]
        public void TestMethod8()                               //тестирование set Grade в Challenge
        {
            Challenge a = new Challenge(-1, "NoName");
            Assert.Equal(0, a.Grade);
        }
        [Fact]
        public void TestMethod9()                               //тестирование Student.Clone()
        {
            Student a = new Student();
            Student b = (Student)a.Clone();
            Assert.Equal(a.Name, b.Name);
        }

    }
}
using Xunit;
using Lab9_Classes;

namespace Lab9_UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethodObjParam()                    //констурктор с параметром, инкремент
        {
            //предусловие
            Diapason obj1 = new Diapason(1, 3, 2);
            //действие
            obj1++;
            //утверждение ожидания
            Assert.Equal(new Diapason(2, 4, 2), obj1);
        }

        [Fact]
        public void TestMethodObjUmolch()                    //конструктор по умолчанию, сложение
        {
            //предусловие
            Diapason obj1 = new Diapason();
            //действие
            obj1 = obj1 + 7;
            //утверждение ожидания
            Assert.Equal(new Diapason(7, 7, 0), obj1);
        }

        [Fact]
        public void TestMethodObjSravnenie()                 //конструктор по умолчанию, сравнение <
        {
            //предусловие
            Diapason obj1 = new Diapason();
            //утверждение ожидания
            Assert.Equal(true, obj1 < 0);
        }

        [Fact]
        public void TestMethodObjSravnenie2()                //конструктор по умолчанию, сравнение <
        {
            //предусловие
            Diapason obj1 = new Diapason();
            //утверждение ожидания
            Assert.Equal(false, obj1 < 1);
        }

        [Fact]
        public void TestMethodObjSravnenie3()                //конструктор по умолчанию, сравнение >
        {
            //предусловие
            Diapason obj1 = new Diapason();
            //утверждение ожидания
            Assert.Equal(true, obj1 > 1);
        }

        [Fact]
        public void TestMethodObjSravnenie4()                //конструктор по умолчанию, сравнение >
        {
            //предусловие
            Diapason obj1 = new Diapason();
            //утверждение ожидания
            Assert.Equal(false, obj1 > 0);
        }

        [Fact]
        public void TestMethodObjBelong()                 //конструктор по умолчанию, принадлежность
        {
            //предусловие
            Diapason obj1 = new Diapason();
            //утверждение ожидания
            Assert.Equal("принадлежит", obj1.Belong);
        }

        [Fact]
        public void TestMethodObjEx()                //конструктор по умолчанию, приведения типа int
        {
            //предусловие
            Diapason obj1 = new Diapason();
            //утверждение ожидания
            Assert.Equal(0, (int)obj1);
        }

        [Fact]
        public void TestMethodObjIm()             //конструктор по умолчанию, приведения типа double
        {
            //предусловие
            Diapason obj1 = new Diapason();
            //утверждение ожидания
            Assert.Equal(0, (double)obj1);
        }

        [Fact]
        public void TestMethodObjOtricz()               	//конструктор по умолчанию, отрицание 
        {
            //предусловие
            Diapason obj1 = new Diapason();
            //утверждение ожидания
            Assert.Equal(0, !obj1);
        }

        [Fact]
        public void TestMethodMasUmolch()                    //массив конструктор по умолчанию,
        {
            //предусловие
            DiapasonArray mas = new DiapasonArray();
            //действие
            Diapason obj = new Diapason();
            mas[0] = obj;
            //утверждение ожидания
            Assert.Equal(0, mas[1].X);
        }

        [Fact]
        public void TestMethodMas1P()                    //массив конструктор c 1 параметром
        {
            //предусловие
            DiapasonArray mas = new DiapasonArray(1);
            //действие
            Diapason obj = new Diapason();
            mas[0] = obj;
            //утверждение ожидания
            Assert.Equal(0, mas[1].X);
        }
    }
}
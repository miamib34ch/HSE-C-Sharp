using Xunit;
using Lab9_Classes;

namespace Lab9_UnitTests
{
    public class UnitTest1
    {
        [Fact]
        public void TestMethodObjParam()                    //����������� � ����������, ���������
        {
            //�����������
            Diapason obj1 = new Diapason(1, 3, 2);
            //��������
            obj1++;
            //����������� ��������
            Assert.Equal(new Diapason(2, 4, 2), obj1);
        }

        [Fact]
        public void TestMethodObjUmolch()                    //����������� �� ���������, ��������
        {
            //�����������
            Diapason obj1 = new Diapason();
            //��������
            obj1 = obj1 + 7;
            //����������� ��������
            Assert.Equal(new Diapason(7, 7, 0), obj1);
        }

        [Fact]
        public void TestMethodObjSravnenie()                 //����������� �� ���������, ��������� <
        {
            //�����������
            Diapason obj1 = new Diapason();
            //����������� ��������
            Assert.Equal(true, obj1 < 0);
        }

        [Fact]
        public void TestMethodObjSravnenie2()                //����������� �� ���������, ��������� <
        {
            //�����������
            Diapason obj1 = new Diapason();
            //����������� ��������
            Assert.Equal(false, obj1 < 1);
        }

        [Fact]
        public void TestMethodObjSravnenie3()                //����������� �� ���������, ��������� >
        {
            //�����������
            Diapason obj1 = new Diapason();
            //����������� ��������
            Assert.Equal(true, obj1 > 1);
        }

        [Fact]
        public void TestMethodObjSravnenie4()                //����������� �� ���������, ��������� >
        {
            //�����������
            Diapason obj1 = new Diapason();
            //����������� ��������
            Assert.Equal(false, obj1 > 0);
        }

        [Fact]
        public void TestMethodObjBelong()                 //����������� �� ���������, ��������������
        {
            //�����������
            Diapason obj1 = new Diapason();
            //����������� ��������
            Assert.Equal("�����������", obj1.Belong);
        }

        [Fact]
        public void TestMethodObjEx()                //����������� �� ���������, ���������� ���� int
        {
            //�����������
            Diapason obj1 = new Diapason();
            //����������� ��������
            Assert.Equal(0, (int)obj1);
        }

        [Fact]
        public void TestMethodObjIm()             //����������� �� ���������, ���������� ���� double
        {
            //�����������
            Diapason obj1 = new Diapason();
            //����������� ��������
            Assert.Equal(0, (double)obj1);
        }

        [Fact]
        public void TestMethodObjOtricz()               	//����������� �� ���������, ��������� 
        {
            //�����������
            Diapason obj1 = new Diapason();
            //����������� ��������
            Assert.Equal(0, !obj1);
        }

        [Fact]
        public void TestMethodMasUmolch()                    //������ ����������� �� ���������,
        {
            //�����������
            DiapasonArray mas = new DiapasonArray();
            //��������
            Diapason obj = new Diapason();
            mas[0] = obj;
            //����������� ��������
            Assert.Equal(0, mas[1].X);
        }

        [Fact]
        public void TestMethodMas1P()                    //������ ����������� c 1 ����������
        {
            //�����������
            DiapasonArray mas = new DiapasonArray(1);
            //��������
            Diapason obj = new Diapason();
            mas[0] = obj;
            //����������� ��������
            Assert.Equal(0, mas[1].X);
        }
    }
}
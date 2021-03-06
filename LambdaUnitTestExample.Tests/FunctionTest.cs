using System;
using Xunit;

// Note: Your project should be named LambdaUnitTestExample.
namespace LambdaUnitTestExample.Tests
{
    public class CarTest
    {
        public enum Condition
        {
            EXCELLENT,
            GOOD,
            FAIR,
            BAD
        };
        public class Car
        {
            public string Make { get; set; }
            private int _speed;
            public int Speed
            {
                get { return _speed; }
                set { _speed = (int)Math.Round((double)value / 5.0) * 5; }
            }
            public Condition Condition;


            public Car(string make, Condition condition)
            {
                Make = make;
                Condition = condition;
            }

        }

            [Fact]
            public void TestConstructor()
            {
                // Hint: Conditions is an enum.
                Car car = new Car("Chevy", (int)Condition.EXCELLENT);

                Assert.Equal("Chevy", car.Make);
                Assert.Equal(0, car.Speed);
                Assert.Equal(Condition.EXCELLENT, car.Condition);
            }
        


            [Theory]
            [InlineData(Condition.EXCELLENT)]
            [InlineData(Condition.GOOD)]
            [InlineData(Condition.FAIR)]
            [InlineData(Condition.BAD)]
            public void TestConditions(Condition c)
            {
                Assert.True(Convert.ToInt32(c) >= 0);
            }

            [Fact]
            public void TestSpeed()
            {
            // Hint: Speed is a C# Property.
            Car car = new Car("Ford", Condition.BAD);
            Assert.Equal(0, car.Speed);
            car.Speed = 25;
            Assert.Equal(25, car.Speed);
            car.Speed = 200;
            Assert.Equal(200, car.Speed);
            car.Speed = 201;
            Assert.Equal(200, car.Speed);
            car.Speed = -25;
            Assert.Equal(-25, car.Speed);
            car.Speed = -50;
            Assert.Equal(-50, car.Speed);
            car.Speed = -51;
            Assert.Equal(-50, car.Speed);
        }
        
    }
}

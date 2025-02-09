using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        public Game g;
        public GameFixture()
        {
            g= new Game();
        }
        public void roll(int number_of_pins,int value)
        {
            for(int i=0;i<number_of_pins;i++)
            {
                g.RollSinglePin(value);
            }
        }

        [Fact]
        public void TestAllStrikes()
        {
            roll(12,10);
            Assert.Equal(300,g.GetScore());
            
        }
        [Fact]
        public void TestAllZeros()
        {
            roll(20,0);
            Assert.Equal(0,g.GetScore());
        }
        [Fact]
        public void TestSpare()
        {
            g.RollSinglePin(7);
            g.RollSinglePin(3);
            g.RollSinglePin(4);
            roll(17,1);
            Assert.Equal(35,g.GetScore());
        }
        [Fact]
        public void Random()
        {
            g.RollMultiplePin(new int[]{9,0,10,1,9,3,0,7,2,8,2,0,5,9,0,10,1,6});
            Assert.Equal(102,g.GetScore());

        }
        [Fact]
        public void AllSpares()
        {
            g.RollMultiplePin(new int[]{9,1,8,2,7,3,6,4,5,5,4,6,7,3,1,9,8,2,7,3,10});
            Assert.Equal(163,g.GetScore());
        }
        [Fact]
        public void LastStrike()
        {
        g.RollMultiplePin(new int[]{8,0,1,4,6,2,9,0,10,3,0,2,0,7,0,9,0,10,1,4});
        Assert.Equal(79,g.GetScore());
        }
        [Fact]
        public void Lastspare()
        {
        g.RollMultiplePin(new int[]{2,4,4,5,2,7,9,1,5,0,4,5,1,8,5,3,10,1,9,5});
        Assert.Equal(105,g.GetScore());
        }
        [Fact]
        public void Random2()
        {
        g.RollMultiplePin(new int[]{1,2,3,5,6,3,5,2,2,3,1,5,0,6,1,6,10,9,1,10});
        Assert.Equal(91,g.GetScore());
        }
        [Fact]
        public void WithoutSpareandStrike()
        {
        g.RollMultiplePin(new int[]{3,2,2,5,1,7,5,0,3,0,2,7,3,1,6,0,1,2,0,4});
        Assert.Equal(54,g.GetScore());
        }
        [Fact]
        public void StrikesAtEnd()
        {
        g.RollMultiplePin(new int[]{3,1,3,4,2,6,4,5,10,10,10,10,10,10,10,10});
        Assert.Equal(208,g.GetScore());
        }
    }
}

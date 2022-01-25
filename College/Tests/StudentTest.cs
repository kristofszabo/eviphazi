using System;
using Xunit;
using CollegeManager;
using System.Collections.Generic;

namespace Tests
{
    public class StudentTest
    {
        [Fact]        
        public void JoinCircleTest()
        {
            Student elek = new Student("Teszt Elek", "valami@example.com", "BATMAN1");
            Student eszter = new Student("Vincs Eszter", "valami2@example.com", "JOKER02");
            Circle tesztCircle = new Circle("teszt",elek, "Ez egy teszt kör");
            Assert.Single(tesztCircle.Members);
            eszter.JoinCircle(tesztCircle);
            Assert.Equal(2, tesztCircle.Members.Count);
            Assert.Contains(elek, tesztCircle.Members);
            Assert.Contains(eszter, tesztCircle.Members);

        }
        [Fact]
        public void LeaveCircleTest()
        {
            Student elek = new Student("Teszt Elek", "valami@example.com", "BATMAN1");
            Student eszter = new Student("Vincs Eszter", "valami2@example.com", "JOKER02");
            Student jakab = new Student("Gipsz Jakab", "valami3@example.com", "ABC1234");
            Circle tesztCircle = new Circle("teszt",elek, "Ez egy teszt kör");
            eszter.JoinCircle(tesztCircle);
            jakab.JoinCircle(tesztCircle);
            Assert.Equal(3, tesztCircle.Members.Count);
            eszter.LeaveCircle(tesztCircle);
            Assert.Equal(2, tesztCircle.Members.Count);
            Assert.Contains(elek, tesztCircle.Members);
            Assert.Contains(jakab, tesztCircle.Members);
            Assert.Empty(eszter.Circles);
        }
    }
}

using MathExamination.Domain;

namespace MathExamination.Store;
public static class TasksStore
{
    public static List<MathTask> MathTasks = new()
    {
        new MathTask
        {
            Complexity = Complexity.School,
            Subject = Subject.Trygonometry,
            Description = "Find the length of the hypotenuse of a right triangle if one of the legs has a length of 5 units and the other leg has a length of 12 units.",
            Solution = "hypotenuse = sqrt(5^2 + 12^2)\r\n= sqrt(25 + 144)\r\n= sqrt(169)\r\n= 13\r\n\r\nTherefore, the length of the hypotenuse is 13 units.\r\n\r\n",
            Prompt = "To solve this task, you can use the Pythagorean theorem, which states that in a right triangle, the square of the length of the hypotenuse (the side opposite the right angle) is equal to the sum of the squares of the other two sides. In this case, the hypotenuse is the side we are trying to find, so we can write the equation as:",
        },
        new MathTask
        {
            Complexity = Complexity.Olympiad,
            Subject = Subject.Trygonometry,
            Description = "Find the length of the missing leg of a right triangle if the hypotenuse has a length of 5 units and one leg has a length of 3 units.",
            Solution = "x = sqrt(5^2 - 3^2)\r\n= sqrt(25 - 9)\r\n= sqrt(16)\r\n= 4",
            Prompt = "To find the length of the missing leg of a right triangle if the hypotenuse has a length of 5 units and one leg has a length of 3 units, you can use the Pythagorean theorem. The Pythagorean theorem states that in a right triangle, the square of the length of the hypotenuse (the side opposite the right angle) is equal to the sum of the squares of the other two sides.",
        },
        new MathTask
        {
            Complexity = Complexity.School,
            Subject = Subject.Trygonometry,
            Description = "Find the sine of an angle in a right triangle if the opposite side has a length of 5 units and the hypotenuse has a length of 13 units.",
            Solution = "sine = opposite side / hypotenuse\r\n= 5 / 13\r\n= 0.3846",
            Prompt = "To find the sine of an angle in a right triangle if the opposite side has a length of 5 units and the hypotenuse has a length of 13 units, you can use the definition of sine. The sine of an angle in a right triangle is defined as the ratio of the length of the opposite side to the length of the hypotenuse.",
        },
        new MathTask
        {
            Complexity = Complexity.Olympiad,
            Subject = Subject.Trygonometry,
            Description = "Find the cosine of an angle in a right triangle if the adjacent side has a length of 8 units and the hypotenuse has a length of 10 units.",
            Solution = "cosine = adjacent side / hypotenuse\r\n= 8 / 10\r\n= 0.8",
            Prompt = "To find the cosine of an angle in a right triangle if the adjacent side has a length of 8 units and the hypotenuse has a length of 10 units, you can use the definition of cosine. The cosine of an angle in a right triangle is defined as the ratio of the length of the adjacent side to the length of the hypotenuse.",
        },
        new MathTask
        {
            Complexity = Complexity.School,
            Subject = Subject.Trygonometry,
            Description = "Find the tangent of an angle in a right triangle if the opposite side has a length of 6 units and the adjacent side has a length of 8 units.",
            Solution = "tangent = opposite side / adjacent side\r\n= 6 / 8\r\n= 0.75",
            Prompt = "To find the tangent of an angle in a right triangle if the opposite side has a length of 6 units and the adjacent side has a length of 8 units, you can use the definition of tangent. The tangent of an angle in a right triangle is defined as the ratio of the length of the opposite side to the length of the adjacent side.",

        },
        new MathTask
        {
            Complexity = Complexity.Olympiad,
            Subject = Subject.Algebra,
            Description = "Simplify the expression 3x + 4y - 2x + y.",
            Solution = "x + 5y",
            Prompt = "We can combine like terms by adding the coefficients of the terms that have the same variables",
        },
        new MathTask
        {
            Complexity = Complexity.School,
            Subject = Subject.Algebra,
            Description = "Solve the equation 2x + 3 = 7.",
            Solution = "x = 2",
            Prompt = "We need to isolate the variable x on one side of the equation",
        },
        new MathTask
        {
            Complexity = Complexity.Olympiad,
            Subject = Subject.Algebra,
            Description = "Find the slope of the line given the points (4, 7) and (2, 3).",
            Solution = "slope = (3 - 7) / (2 - 4) = -4 / -2 = 2",
            Prompt = "The slope of a line is a measure of its steepness and is calculated by finding the ratio of the vertical change (the difference in the y-coordinates) to the horizontal change (the difference in the x-coordinates) between two points on the line.",
        },
        new MathTask
        {
            Complexity = Complexity.School,
            Subject = Subject.Algebra,
            Description = "Multiply the binomials (x + 2) and (x - 3).",
            Solution = "x^2 - x - 6",
            Prompt = "To multiply the binomials (x + 2) and (x - 3), we can use the distributive property. This states that for any two numbers a and b, and for any variables x and y, a(x + y) = ax + ay and (x + y)b = xb + yb.",
        },
        new MathTask
        {
            Complexity = Complexity.Olympiad,
            Subject = Subject.Algebra,
            Description = "Find the value of x in the equation 3x + 7 = 19.",
            Solution = "x = 4",
            Prompt = "To find the value of x in the equation 3x + 7 = 19, we can isolate the variable x on one side of the equation by subtracting 7 from both sides. ",
        },
        new MathTask
        {
            Complexity = Complexity.School,
            Subject = Subject.Stereometry,
            Description = "Calculate the volume of a rectangular prism given its length, width, and height. Rectangular prism has a length of 5 meters, a width of 3 meters, and a height of 2 meters",
            Solution = "Volume = 5 meters x 3 meters x 2 meters = 30 cubic meters",
            Prompt = "To calculate the volume of a rectangular prism, you will need to know its length, width, and height. The volume of a rectangular prism is calculated by multiplying the length by the width by the height.",
        },
        new MathTask
        {
            Complexity = Complexity.Olympiad,
            Subject = Subject.Stereometry,
            Description = "Determine the surface area of a cube given the length of its sides. The side length of the cube is 5 meters",
            Solution = "Surface Area = 6 x (5 meters)^2 = 6 x 25 = 150 square meters",
            Prompt = "To determine the surface area of a cube, you will need to know the length of its sides. The surface area of a cube is calculated by adding the areas of all of its faces.",
        },
        new MathTask
        {
            Complexity = Complexity.School,
            Subject = Subject.Stereometry,
            Description = "Find the volume of a cylinder given its radius and height. The cylinder has a radius of 3 meters and a height of 4 meters",
            Solution = "Volume = π x (3 meters)^2 x 4 meters = 3.14 x 9 x 4 = 113.04 cubic meters",
            Prompt = "To find the volume of a cylinder, you will need to know its radius and height. The volume of a cylinder is calculated by multiplying the area of its base by its height.",
        },
        new MathTask
        {
            Complexity = Complexity.Olympiad,
            Subject = Subject.Stereometry,
            Description = "Calculate the surface area of a sphere given its radius. The radius of the sphere is 5 meters",
            Solution = "Surface Area = 4π x (5 meters)^2 = 4π x 25 = 100π square meters",
            Prompt = "To calculate the surface area of a sphere, you will need to know the radius of the sphere. The surface area of a sphere is calculated using the formula:\r\n\r\nSurface Area = 4πr^2",
        },
        new MathTask
        {
            Complexity = Complexity.School,
            Subject = Subject.Stereometry,
            Description = "Determine the volume of a pyramid given the base area and height. The base area of the pyramid is 25 square meters and the height is 10 meters",
            Solution = "Volume = (25 square meters x 10 meters) / 3 = 250 / 3 = 83.333 cubic meters",
            Prompt = "To determine the volume of a pyramid, you will need to know the base area and height of the pyramid. The volume of a pyramid is calculated by multiplying the base area by the height and dividing the result by 3.",
        },
    };
}

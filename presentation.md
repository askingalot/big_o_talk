class: center, middle

# Big O
### _simplifying the complexity_

---
## who am i?

.no-bullets[
* CS degree from MTSU in 2000
* Professional developer, mostly web development
* Dabbled in management and architecture
* Currently an instructor at the Nashville Software School


* https://twitter.com/askingalot
* https://github.com/askingalot
* https://www.linkedin.com/in/andy-collins
]

---
## goals of this talk

**After this talk you should...**
1. Be able to explain the basics of Big O notation and algorithmic complexity
1. Be able to determine the order of (i.e. Big O value) of a few classes of algorithms
1. Have a solid foundation for further study

<br/>

**This talk isn't...**
1. An exhaustive list of all categories of algorithmic complexity
1. A deep dive into various algorithms
1. A discussion of space complexity

---
## agenda

1. Informal analysis
1. What is Big O?
1. Why does it matter?
1. A tour of example algorithms
1. Topics of further study

---
## how long will it run?

```cs
static void PrintRectangleStats(int length, int width) {
    var area = length * width;
    var perimeter = (length + width) * 2;
    var isSquare = length == width;

    Console.WriteLine("The area is " + area);
    Console.WriteLine("The perimeter is " + perimeter);

    if (isSquare) {
        Console.WriteLine("It is a square");
    } else {
        Console.WriteLine("It is not a square");
    }
}
```
* How many operations does this code perform?
* What the heck is an "operation"?
* How much time does it take for this code to run?

---
## how long will it run?

```cs
static void PrintSquares(List<int> numbers) {
    foreach (var num in numbers) {
        var square = num * num;
        var message = "The square of " + num + " is " + square;
        Console.WriteLine(message);
    }
}
```

---
## definitions

_**Big O notation**_ is a mathematical notation that describes the limiting behavior of a function when the argument tends towards a particular value or **infinity**.

In computer science, big O notation is used to classify **algorithms** according to how their **running time** or **space requirements** grow as the input size grows.

---

## some code

```cs
int GetFirst(List<int> numbers)
{
    return numbers[0];
}
```

---
# Examples
use the school data from data.nashville.gov

O(1)
get the first item from the list
calculate the similarity score between two schools

O(n)
find all schools in a zip code
Find the school with the most students

O(log n)
order the schools by name and search by name

O(n^2)
find the similarity score between each school

O(n log n)
find a school by name and do a similarity score between it and all the others

O(a^n)
...some sort of permutation thing...

O(n!)
...I don't know
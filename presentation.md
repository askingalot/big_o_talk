class: center, middle

# Big O
### _simplifying the complexity_

---
## Who am I?

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
## Goals of this Talk

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
## Agenda

1. What is Big O?
1. Some simple examples
1. Comparison of orders of magnitude
1. Resources and ideas for further study


---
## What is Big O?

.center.big[_An way to describe the_]

.center.bigger[**worst case**]

.center.bigger[**complexity**]

.center.big[_(in time and/or space)_]

.center.big[_of an_]

.center.bigger[**algorithm**]

???
Define these terms in reverse

Algorithm - a set of steps to be followed in order to produce some result

Complexity - how big the algorithm is...how long, how much memory. only talk about time

Worst case - as input goes to infinity

---
## Worst Case Complexity

_This function is O(n)_

```cs
public bool ContainsNumber(List<int> list, int number) {
    foreach (var n in list) {
        if (n == number) {
            return true;
        }
    }
    return false;
}
```
???
Big O of N - Order of N / this function is Order N

What's the best case? - number is the first element

Worst case, it's no in the list

What's the average case? - assume list is unordered

---
## More about Big O

.big[
* Mathematical notation
* An approximation
* Concerned with how quickly complexity increases
* Used to classify algorithms
]

???
* Mathematical notation
* An approximation - NOT EXACT
* Concerned with how quickly complexity increases - As size of input increases
* Used to classify algorithms - algorithms fall into categories

---
## Orders of Magnitude

.no-bullets.bigger[
* 0 - 9
* 10 - 99
* 100 - 999
* 1000 - 9999
]

???
Think about money
* piece of candy - a few cents
* a cup of coffee - a few dollars
* A nice shirt - a few 10's of dollars
* a weekend in a hotel - a few 100s of dollars
* a new laptop - a few 1000s of dollars


---
## O(n) - Linear Time
```cs
public void PrintList(List<string> strings) {
    foreach(var str in strings) {
        var fromTheRoofTops = str.ToUpper();
        fromTheRoofTops = fromTheRoofTops + "!!!!";
        Console.WriteLine(fromTheRoofTops);
    }
}
```

???
* Big O is an approximation
* each iteration of the loop will take the same time
* what matters is the number of times we loop


---
## O(1) - Constant Time
```cs
static int SumThree(int a, int b, int c) {
    int sum;
    sum = a = b;
    sum += c;
    return sum;
}
```

???
* no matter the size of the input
* always takes the same time

---
## Graphing Big O

### O(1)

### O(n)

---
## How long will it run?
```cs
static int SumThree(int a, int b, int c) {
    int sum;
    sum = a = b;
    sum += c;
    return sum;
}
```
* How many operations does this code perform?
* What the heck is an "operation"?
* How much time does it take for this code to run?

---
## How long will it run?

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

---
## How long will it run?

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
## Big Oh!
What is it?
* A way to specify the **relative** (e.g. _not exact_) performance of some code.
* A mathematical **notation** for describing the **order** of a piece of code.
* Used to put code into a category based on it's performance.
* Focuses on **worst case** performance (where N becomes very large).

---
## Big Oh!
What is it?
* A way to specify the **relative** (e.g. _not exact_) performance of some code.
* A mathematical **notation** for describing the **order** of a piece of code.
* Used to put code into a category based on it's performance.
* Focuses on **worst case** performance (where N becomes very large).

More formally... (_from wikipedia_)

_**Big O notation**_ is a mathematical notation that describes the limiting behavior of a function when the argument tends towards a particular value or **infinity**.

In computer science, big O notation is used to classify **algorithms** according to how their **running time** or **space requirements** grow as the input size grows.

---
## Algorithm?
What's an algorithm?
* A set of steps to solve a problem or perform a task.
* Very precise description of the steps.
* Any code can be thought of as an algorithm.
* Lots ot known algorithms for sorting, searching, traversing trees and graphs, etc...

---
## Algorithm?
What's an algorithm?
* A set of steps to solve a problem or perform a task.
* Very precise description of the steps.
* Any code can be thought of as an algorithm.
* Lots ot known algorithms for sorting, searching, traversing trees and graphs, etc...

<br/>
**For our purposes today...**
### An algorithm is some code in a C# method.

---
## Counting operations

How many operations are executed?

```cs
public void PrintList(List<string> strings) {
    foreach(var str in strings) {
        Console.WriteLine(str);
    }
}
```
---
## Counting operations

How many operations are executed?

```cs
public void PrintList(List<string> strings) {
    foreach(var str in strings) {
        Console.WriteLine(str);
    }
}
```
<br/>
What about now?

```cs
public void PrintList(List<string> strings) {
    foreach(var str in strings) {
        var fromTheRoofTops = str.ToUpper();
        fromTheRoofTops = fromTheRoofTops + "!!!!";
        Console.WriteLine(fromTheRoofTops);
    }
}
```
---
## Counting operations
How many operations are executed?

Let's break it down...
```cs
public void PrintList(List<string> strings) {
    foreach (var str in strings) { 
        Console.WriteLine(str); 
    }
}
```
---
## Counting operations
How many operations are executed?

Let's break it down...
```cs
public void PrintList(List<string> strings) {
    foreach (var str in strings) { 
        Console.WriteLine(str); 
    }
}
```
**`(1 assignment + 1 WriteLine) * N iterations = 2N Operations`**

---
## Counting operations
```cs
public void PrintList(List<string> strings) {
    foreach(var str in strings) {
        var fromTheRoofTops = str.ToUpper();
        fromTheRoofTops = fromTheRoofTops + "!!!!";
        Console.WriteLine(fromTheRoofTops);
    }
}
```
**`N * (3 assignment + 1 ToUpper + 1 concat + 1 WriteLine) = 6N`**
---
## Counting operations

### So 2N < 6N, right?

## YES!

###**But Big O _Doesn't Care_**

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
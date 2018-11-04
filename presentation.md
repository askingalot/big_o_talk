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

???
* Andy
* proud of software school
* First user group talk outside of work

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

???
* Simple introduction
* code is simple. not real world
* Ask questions. have conversation
* reading code

---
## Agenda

1. What is Big O?
1. Some simple examples
1. Comparison of orders of magnitude
1. Resources and ideas for further study

???
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

An way to describe the **worst case** **complexity** (in time and/or space) of an **algorithm**

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
* Ignore constants
* Only include most significant term
]

???
* Mathematical notation
* An approximation - NOT EXACT
* Concerned with how quickly complexity increases - As size of input increases
* Used to classify algorithms - algorithms fall into categories

We'll see this in a minute...
* Ignore constants
* Only include most significant term

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
* Big O is an approximation of the order of the number of operations
* Read code - Count operations
* each iteration of the loop will take the same time
* n gets bigger and bigger
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
## Graphing O(1)
.graph[
![O(1)](images/O1.png "O(1)")
]

???
* doesn't matter how many operations
* one O(1) function may run longer than another

---
## Most Significant Term 

.no-bullets.bigger[
* O(6) == O(1)
* O(3n) == O(n)
* O(27n + 6) == O(n)
* O(4n<sup>2</sup> + 50n + 7) == O(n<sup>2</sup>)
]

???
* Ignore constants
* Ignore less significant terms
* only the biggest number counts

---
## O(n) - Linear Time
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
* Revisit this because it's so common
* search of an unsorted list

---
## Graphing O(n)
.graph[
![O(n)](images/On.png "O(n)")
]

???
* time increases as size of input increases
---
## O(log n) - Logarithmic Time

```cs
public bool ContainsNumberBinarySearch( List<int> list, int number) {
    return innerSearch(0, list.Count - 1);

    bool innerSearch(int first, int last) {
        if (first > last) {
            return false;
        }

        var mid = (first + last) / 2;
        if (number == list[mid]) {
            return true;
        }

        if (number < list[mid]) {
            return innerSearch(first, mid - 1);
        }
        return innerSearch(mid + 1, last);
    }
}
```
???
* divide and conquer
* must be a sorted list
* Talk about this code
* Divide and conquer
* first time I ever used an inner function

---
## Graphing O(log n)
.graph[
![O(log n)](images/Ologn.png "O(log n)")
]

???
* graph is log base 2, but since the shape is the same, it doesn't matter

---
## What's this `log n` business?

_From Wikipedia_
>In mathematics, the logarithm is the inverse function to exponentiation. That means the logarithm of a given number x is the exponent to which another fixed number, the base b, must be raised, to produce that number x.

<br/>
_An even mathier definition_
>**log<sub>b</sub> x = e where b<sup>e</sup> = x**

<br/>
_Some Examples_
.no-bullets.big.left[
* **log<sub>10</sub> 10 = 1**
* **log<sub>10</sub> 100 = 2**
* **log<sub>10</sub> 1000 = 3**
]
.no-bullets.big.right[
* **log<sub>2</sub> 16 = 4**
* **log<sub>2</sub> 32 = 5**
* **log<sub>2</sub> 64 = 6**
]

???

* Logarithms are the opposite of exponents
* in big o we talk about log base 2 when we are splitting a problem in half with each iteration
* The base doesn't matter though because it turns out to be the same as multiplying by a constant factor, and constants are removed.
* Example -Searching for a name in the phone book

---
## O(n log n)
### Sorting algorithms

The best sorting algorithms have a complexity of O(n log n)

.left[
* **Mergesort**
* Heapsort
* Timsort
* Cubesort
* Quicksort*
]

.right.large-image[
![Mergesort](images/mergesort.gif "Mergesort")
]

???
* best have O(n log n)
* gif from wikipedia for merge sort
* divide and conquer
* quick sort (has *) has worse case of O(n^2) (already sorted), but best and average case of O(n log n)
---
## O(n log n) - Mergesort
.scroll[
```cs
//merge sort recurcive
public void MergeSort(int[] input,int startIndex,int endIndex) {
    if (endIndex <= startIndex) return;

    int mid = (endIndex + startIndex) / 2;
    MergeSort(input, startIndex, mid);
    MergeSort(input, (mid + 1), endIndex);
    Merge(input, startIndex, (mid + 1), endIndex);
}

public void Merge(int[] input, int left, int mid, int right) {
    //Merge procedure takes theta(n) time
    int[] temp = new int[input.Length];
    int i, leftEnd, lengthOfInput, tmpPos;
    leftEnd = mid - 1;
    tmpPos = left;
    lengthOfInput = right - left + 1;

    //selecting smaller element from left sorted array or 
    // right sorted array and placing them in temp array.
    while ((left <= leftEnd) && (mid <= right)) {
        if (input[left] <= input[mid]) {
            temp[tmpPos++] = input[left++];
        } else { 
            temp[tmpPos++]=input[mid++];
        }
    }
    //placing remaining element in temp from left sorted array
    while (left <= leftEnd) {
        temp[tmpPos++] = input[left++];
    }

    //placing remaining element in temp from right sorted array
    while (mid <= right) {
        temp[tmpPos++] = input[mid++];
    }

    //placing temp array to input
    for (i = 0; i < lengthOfInput; i++ ) {
        input[right]=temp[right];
        right--;
    }
}
```
]

???
* start by splitting array in half for each iteration O(log n)
* then merge O(n)

---
## Graphing O(n log n)
.graph[
![O(n log n)](images/Onlogn.png "O(n log n)")
]

---
## O(n<sup>2</sup>) - Quadratic Time
```cs
public static List<int> FindDuplicates(List<int> list) {
    var result = new List<int>();
    for (var i=0; i<list.Count; i++) {
        for  (var j=i+1; j<list.Count; j++) {
            if (i == j) continue;
            if (list[i] == list[j]) {
                result.Add(list[i]);
            }
        }
    }
    return result;
}
```

---
## Graphing O(n<sup>2</sup>)
.graph[
![O(n^2)](images/Onsquared.png "O(n^2)")
]

---
## O(2<sup>n</sup>) - Exponential Time
```cs
public static List<string> AllBinaryNumbers(int numDigits) {
    var result = new List<string>();
    var num = 0;

    for (var i=0; i<Math.Pow(2, numDigits); i++) {
        result.Add(
            Convert.ToString(num, 2).PadLeft(numDigits, '0')
        );
        num++;
    }
    return result;
}
```
???
* this is 2^n because each binary digit can be one or zero
* imagine brute forcing a password. only upper case letters would be 26^n

---
## Graphing O(2<sup>n</sup>)
.graph[
![O(2^n)](images/O2pown.png "O(2^n)")
]

---
## O(n!) - Factorial Time
```cs
public static List<List<int>> Permutations(List<int> list) {
    if (list.Count == 1) {
        return new List<List<int>> { list };
    }

    var result = new List<List<int>>();
    for (var i=0; i<list.Count; i++) {
        var listWithoutI = list.Where((_, idx) => idx != i).ToList();
        var permsWithoutI = Permutations(listWithoutI);

        result.AddRange(
            permsWithoutI.Select(p => {
                p.Insert(0, list[i]);
                return p;
            })
        );
    }
    return result;
}
```

---
## Graphing O(n!)
.graph[
![O(n!)](images/Onfac.png "O(n!)")
]
.center.big[
**0 <= n <= 5**
]

???
* Brute force search

* notice -  n from 0 to 5
* gets big fast

---
## Graphing O(n!)
.graph[
![O(n!)](images/Onfac1.png "O(n!)")
]
.center.big[
**0 <= n <= 6**
]

???
* n from 0 to 6

---
## Graphing O(n!)
.graph[
![O(n!)](images/Onfac2.png "O(n!)")
]
.center.big[
**0 <= n <= 7**
]

???
* n from 0 to 7

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
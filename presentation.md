class: center, middle

# Big O
### _simplifying the complexity_

---
## who am i?

* CS degree from MTSU in 2000
* Professional developer, mostly web development
* Dabbled in management and architecture
* Currently an instructor at the Nashville Software School


* https://twitter.com/askingalot
* https://github.com/askingalot
* https://www.linkedin.com/in/andy-collins

---
## agenda

1. Definitions
2. An informal approach to measuring complexity
3. A (_slightly_) more formal appraoch
4. Concrete examples

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
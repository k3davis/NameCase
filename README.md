![Icon](https://raw.github.com/k3davis/namecase/master/Icons/icon_1736321.png)
NameCase
=========

Provides a utility method to perform "best-guess" (see below) case and spacing normalization to person names. This project is a partial fork of a similar PHP function posted on [dialect.ca](https://dialect.ca/code/name-case), with various (imho) small improvements.

## Installation

via Nuget:

```
Install-Package NameCase
```

## Basic Usage

A string extension method takes your name input and returns a "best-guess" normalized string:

```c#
var name = "john smith";
var normalizedName = name.ToNameCase(); // "John Smith"
```

## Examples

| Input | Output |
| --- | --- |
| johN SMITH | John Smith |
| karen foo-nuggets | Karen Foo-Nuggets |
| BJÖRK GUÐMUNDSDÓTTIR | Björk Guðmundsdóttir |
| O'HARA, Jane | O'Hara, Jane |
| jimmy macdonald | Jimmy MacDonald |

## What do you mean by "best-guess"?

There is really no such thing as a normalized name, as there are endless possible varieties across many languages that are largely unpredictable. For example a person can be named JoAnne, Jo-Anne, Joanne, etc. according to parental preference or any other set of factors. This method is intended to work for the "majority" of normal use cases, but the output certainly is not authoritative.

If you have suggestions for improving the output, feel free to open an issue or submit a PR, with the  understanding that some combinations just can't be accounted for.

### License

IANAL but since the project from which this was derived was originally shared under GPLv3, my assumption has been that this project is also bound to that license.

### Icon

[Name](http://thenounproject.com/term/name/1736321/) by [Xela Ub](https://thenounproject.com/xela.) from [The Noun Project](http://thenounproject.com/)
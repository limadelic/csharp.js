js-sharp
========

using c# in javascript

C#
```
namespace Math
{
  public class Calculator
  {
    public int add(int a, int b) { return a + b; }
  }
}
```

Coffeescript
```
using 'Math.Calculator'

calc = new Calculator();

console.log calc.add 2, 2
```
```
 ____       __ __                                  
/\  _`\    _\ \\ \__          __           
\ \ \/\_\ /\__  _  _\        /\_\    ____  
 \ \ \/_/_\/__\ \\ \__       \/\ \  /',__\ 
  \ \ \_\ \ /\_   _  _\  __   \ \ \/\__, `\
   \ \____/ \/_/\_\\_\/ /\_\  _\ \ \/\____/
    \/___/     \/_//_/  \/_/ /\ \_\ \/___/ 
                             \ \____/      
                              \/___/       
```

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

calc = new Calculator

console.log calc.add 2, 2
```
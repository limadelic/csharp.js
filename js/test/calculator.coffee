require 'should'
require 'fibrous'
Fiber = require 'fibers'

Fiber(->
  
  require '../src/csharp'

  using 'Math.Calculator'

  console.log calc = new Calculator

  calc.Add(2, 2).should.eql 4
  calc.Div(4, 2).should.eql 2

).run()

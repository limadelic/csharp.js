require 'should'
require 'fibrous'
Fiber = require 'fibers'

Fiber(->
  
  require '../src/csharp'

  using 'Math.Calculator'

  console.log calc = new Calculator

  calc.Add(2, 2).should.equal 4

).run()

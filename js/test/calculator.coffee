require 'fibrous'
Fiber = require 'fibers'

Fiber(->
  
  require '../src/csharp'

  using 'Math.Calculator'

#describe 'A calculator', ->

  console.log calc = new Calculator

).run()
#it 'adds', -> #calc.add(2, 2).should.equal 4

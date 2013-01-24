require 'should'
require 'fibrous'
Fiber = require 'fibers'

Fiber(->
  
  require '../src/csharp'

  using 'Math.Calculator'

  calc = new Calculator

  calc.Add(2, 2).should.eql 4
  calc.Add(2, 2, 'kg').should.eql '4 kg'
  calc.Div(4, 2).should.eql 2

  minion.disconnect()

).run()
